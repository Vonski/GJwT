using UnityEngine;
using System.Collections;

public class Mister_two : MonoBehaviour {
	public Transform head;

	// Use this for initialization
	void Start () {
		head.gameObject.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Stop ();
		}

	}

	void Stop() {
		enabled = false;
		head.gameObject.SetActive (false);
	}
}
