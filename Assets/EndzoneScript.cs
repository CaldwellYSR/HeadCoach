using UnityEngine;

public class EndzoneScript : MonoBehaviour, IBoid {

    public float GetMass()
    {
        return gameObject.GetComponent<Rigidbody2D>().mass;
    }

    public float GetMaxVelocity()
    {
        return 0f;
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
