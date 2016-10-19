using UnityEngine;
using System.Collections;

public class RotateMissile : MonoBehaviour {

    public float rot_speed;
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(Vector3.forward*rot_speed);
	}
}
