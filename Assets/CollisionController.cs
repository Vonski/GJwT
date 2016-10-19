using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (tag == "Player" && coll.gameObject.tag == "Gorczyca")
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.up * 5f;
            Debug.Log("Stairway to heaven");
        }
    }
}
