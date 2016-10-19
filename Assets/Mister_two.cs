using UnityEngine;
using System.Collections;

public class Mister_two : MonoBehaviour {
	public Transform head;

	public Transform maze;
	public Transform background;

	bool startgame = false;

	// Use this for initialization
	void Start () {
		head.gameObject.SetActive (true);

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			startgame = true;
		}

		if (startgame) {
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 10;

			Vector3 screenPos = Camera.main.ScreenToWorldPoint (mousePos);

			RaycastHit2D hit = Physics2D.Raycast (screenPos, Vector2.zero);

			if (!hit) { /*&& hit.collider.CompareTag ("ENEMY") &&*/// !hit.collider.gameObject.GetComponent<SowaDestroy> ().destroyed) {
				Debug.Log ("you loose!!!!!!!!!!!!!!!!!!!!");
				Stop ();
			} else {

			}
		}
	}
		
	void Stop() {
		enabled = false;
		head.gameObject.SetActive (false);
		maze.gameObject.SetActive (false);
		background.gameObject.SetActive (false);
	}
}
