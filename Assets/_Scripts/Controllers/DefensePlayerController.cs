using UnityEngine;

public class DefensePlayerController : MonoBehaviour, IBoid {

    public float maxVelocity;
    public IBoid target;
    private MovementManager steering;

    // Use this for initialization
    void Start () {
        GameObject ballCarrier = GameObject.FindGameObjectWithTag("offense");
        target = ballCarrier.GetComponent<OffensePlayerController>();
        steering = new MovementManager(this);
	}
	
	// Update is called once per frame
	void Update () {

        steering.pursue(target);

        steering.update();

        gameObject.transform.position = steering.position + steering.velocity;

	}

    public float GetMass()
    {
        return gameObject.GetComponent<Rigidbody2D>().mass;
    }

    public float GetMaxVelocity()
    {
        return maxVelocity;
    }

    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }

    public Vector3 GetVelocity()
    {
        return gameObject.GetComponent<Rigidbody2D>().velocity;
    }
}
