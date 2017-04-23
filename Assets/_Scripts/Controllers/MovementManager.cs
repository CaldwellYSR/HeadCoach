using UnityEngine;

public class MovementManager
{

    public Vector3 steering, velocity, position;
    public IBoid host;

    public MovementManager(IBoid host)
    {
        this.host = host;
        this.steering = new Vector3(0f, 0f, 0f);
        Debug.Log(steering);
    }

    public void seek(Vector3 target, float slowingRadius = 10f)
    {
        steering += doSeek(target, slowingRadius);
    }

    public void flee(Vector3 target)
    {
        steering -= doSeek(target);
    }

    public void evade(IBoid target)
    {
        steering -= doPursue(target);
    }

    public void pursue(IBoid target)
    {
        steering += doPursue(target);
    }

    public void update()
    {
        velocity = host.GetVelocity();

        position = host.GetPosition();

        steering = new Vector3(
            Mathf.Clamp(steering.x, -host.GetMaxVelocity(), host.GetMaxVelocity()),
            Mathf.Clamp(steering.y, -host.GetMaxVelocity(), host.GetMaxVelocity()),
            Mathf.Clamp(steering.z, -host.GetMaxVelocity(), host.GetMaxVelocity())
        );

        velocity += steering;

        velocity = new Vector3(
            Mathf.Clamp(velocity.x, -host.GetMaxVelocity(), host.GetMaxVelocity()),
            Mathf.Clamp(velocity.y, -host.GetMaxVelocity(), host.GetMaxVelocity()),
            Mathf.Clamp(velocity.z, -host.GetMaxVelocity(), host.GetMaxVelocity())
        );

        position += velocity;
    }

    public void reset()
    {
    }

    private Vector3 ScaleBy(Vector3 vector, float value)
    {
        return new Vector3(vector.x * value, vector.y * value, vector.z * value);
    }

    private Vector3 doSeek(Vector3 target, float slowingRadius = 0f)
    {
        float distance;

        Vector3 desired = target - host.GetPosition();

        distance = desired.magnitude;
        desired.Normalize();

        if (distance < slowingRadius)
        {
            desired = this.ScaleBy(desired, host.GetMaxVelocity() * distance / slowingRadius);
        }
        else
        {
            desired = this.ScaleBy(desired, host.GetMaxVelocity());
        }

        return desired - host.GetVelocity();
    }

    private Vector3 doFlee(Vector3 target)
    {
        return new Vector3(0, 0, 0);
    }

    private Vector3 doEvade(IBoid target)
    {
        return new Vector3(0, 0, 0);
    }

    private Vector3 doPursue(IBoid target)
    {
        Vector3 distance = target.GetPosition() - host.GetPosition();
        float updates = distance.magnitude / host.GetMaxVelocity();
        Vector3 tv = target.GetVelocity();
        tv = this.ScaleBy(tv, updates);
        Vector3 targetFuture = target.GetPosition() + tv;
        return doSeek(targetFuture, 10f);
    }

}
