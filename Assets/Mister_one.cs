using UnityEngine;
using System.Collections;

public class Mister_one : MonoBehaviour {
	public Transform player;

    // Use this for initialization
    void Start () {
		
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Stop ();
		}

    }

	void Stop() {
		enabled = false;
	}
}
