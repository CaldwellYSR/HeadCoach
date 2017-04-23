using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float xBounds;

    // Update is called once per frame
    void Update () {
        Vector3 current = transform.position;
        current.x = Mathf.Clamp(current.x, -xBounds, xBounds);
        transform.position = current;
	}

}
