using UnityEngine;
using System.Collections;

public class Cleaner : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -6f || transform.position.y > 8f || transform.position.x>47f || transform.position.x<27f)
            Destroy(gameObject);
	}
}
