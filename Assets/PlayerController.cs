using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,400f));

	}
}
