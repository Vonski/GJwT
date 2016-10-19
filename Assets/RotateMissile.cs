using UnityEngine;
using System.Collections;

public class RotateMissile : MonoBehaviour {

    public float rot_speed;
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(Vector3.forward*rot_speed);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(tag=="Enemy_missile" || coll.gameObject.tag== "Enemy_missile")
            GetComponent<Rigidbody2D>().gravityScale = 2f;
        if ((tag == "Enemy_missile" && coll.gameObject.tag == "Player") || (tag == "Player" && coll.gameObject.tag == "Enemy_missile"))
            Debug.Log("Failure");
    }
}
