using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("heaven");
        if (tag == "Gorczyca" && coll.gameObject.tag == "Actual")
            Debug.Log("to heaven");
        if (tag == "Actual" && coll.gameObject.tag == "Gorczyca")
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.up * 5f;
            Debug.Log("Stairway to heaven");
        }
        if (tag == "Fatual" && coll.gameObject.tag == "Gorczyca")
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.down * 5f;
            Debug.Log("Highway to helln");
        }
    }
}
