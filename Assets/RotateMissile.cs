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
        if (tag == "Enemy_missile" && coll.gameObject.tag == "Actual")
        {
            GameObject spawned;
            if (coll.gameObject.transform.GetComponent<Rigidbody2D>().mass>20000)
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/BoyFatFinal"), coll.gameObject.transform.position, coll.gameObject.transform.transform.rotation);
            else
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/GirlFatFinal"), coll.gameObject.transform.position, coll.gameObject.transform.transform.rotation);
            spawned.transform.parent = coll.gameObject.transform.parent;
            spawned.transform.localScale = coll.gameObject.transform.localScale;

            Destroy(coll.gameObject);

            Debug.Log("Failure");
        }
    }
}
