using UnityEngine;
using System.Collections;

public class Mister_two : MonoBehaviour {
	public Transform head;

	public Transform maze;
	public Transform kropla;

	public Texture2D cursortex;

	bool startgame = false;

	// Use this for initialization
	void Start () {
		enabled = true;
		head.gameObject.SetActive (true);

	}

	// Update is called once per frame
	void Update () {

		if (startgame == false) {

			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 10;

			Vector3 screenPos = Camera.main.ScreenToWorldPoint (mousePos);

			RaycastHit2D hit = Physics2D.Raycast (screenPos, Vector2.zero);

			if (hit && hit.collider.CompareTag("KROPLA") && Input.GetMouseButtonDown (0)) {
				startgame = true;
				Vector2 pos = new Vector2 (cursortex.width / 2f, cursortex.height / 2f);
				Cursor.SetCursor (cursortex, pos, CursorMode.ForceSoftware);
				kropla.gameObject.SetActive (false);
			}
		}


		if (startgame) {
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 10;

			Vector3 screenPos = Camera.main.ScreenToWorldPoint (mousePos);

			RaycastHit2D hit = Physics2D.Raycast (screenPos, Vector2.zero);

			if (!hit) { /*&& hit.collider.CompareTag ("ENEMY") &&*/// !hit.collider.gameObject.GetComponent<SowaDestroy> ().destroyed) {
				Stop ();
                GetComponent<ScenarioController>().currentAction++;
            } else {
				if (hit && hit.collider.CompareTag("TARGET"))
                {
                    GetComponent<ScenarioController>().currentAction++;
                    Debug.Log("You win!");

					GameObject.Find("GameController").GetComponent<ScreenShake>().shakeDuration = 2f;
					GameObject.Find("GameController").GetComponent<ScreenShake>().enabled = true;
                }
			}
		}
	}
		
	void Stop() {
		GameObject.Find("GameController").GetComponent<ScreenShake>().shakeDuration = 0.5f;
		GameObject.Find("GameController").GetComponent<ScreenShake>().enabled = true;

		Debug.Log ("Stop Mister two");
		enabled = false;
		head.gameObject.SetActive (false);
		maze.gameObject.SetActive (false);

		//Destroy (maze.gameObject);
	}
}
