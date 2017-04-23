using UnityEngine;

public class OffensePlayerController : MonoBehaviour, IBoid {

    public float maxVelocity;
    public GameObject goalline;
    private IBoid defense;
    private IBoid endzone; 
    private MovementManager steering;

    // Use this for initialization
    void Start () {
        GameObject defender = GameObject.FindGameObjectWithTag("defense");
        defense = defender.GetComponent<DefensePlayerController>();
        endzone = goalline.GetComponent<EndzoneScript>();
        steering = new MovementManager(this);
	}
	
	// Update is called once per frame
	void Update () {

        steering.seek(endzone.GetPosition());
        //steering.evade(defense);
		
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0;
    }

}
