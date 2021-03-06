using UnityEngine;
using System.Collections;

public class Mister_three : MonoBehaviour {
	public Transform player;
	public Transform pan;

	public Texture2D cursortex;

	int points = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnBirds(1.5f));
		Vector2 pos = new Vector2 (cursortex.width/2f, cursortex.height/2f);
		Cursor.SetCursor (cursortex, pos, CursorMode.ForceSoftware);
		pan.gameObject.SetActive (true);

	}
	
	// Update is called once per frame

	void Update() {
		if (Input.GetMouseButtonDown(0)){
			Vector3 mousePos = Input.mousePosition;
	        mousePos.z = 10;

			Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);

	        RaycastHit2D hit = Physics2D.Raycast(screenPos,Vector2.zero);

			if(hit && hit.collider.CompareTag("ENEMY") && !hit.collider.gameObject.GetComponent<SowaDestroy>().destroyed)
	        {
				points++;
	            print (hit.collider.name);
				//Destroy(hit.collider.gameObject);
	        
				hit.collider.gameObject.GetComponent<SowaDestroy> ().DestroySowa();

				GameObject.Find("GameController").GetComponent<ScreenShake>().shakeDuration = 0.01f;
				GameObject.Find("GameController").GetComponent<ScreenShake>().enabled = true;
			}
		}

		if (points >= 8) {
			Stop ();
            GetComponent<ScenarioController>().currentAction++;
            GetComponent<ScenarioController>().currentAction++;
        }
	}

	IEnumerator SpawnBirds(float waitTime)
	{
		while (true)
		{
			int direction = Random.Range (0, 2);

			Vector3 startpos;
			if(direction == 1)
				startpos = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 
			Random.Range(Camera.main.pixelHeight/2f, Camera.main.pixelHeight), Camera.main.nearClipPlane));
			else
				startpos = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 
					Random.Range(Camera.main.pixelHeight/2f, Camera.main.pixelHeight), Camera.main.nearClipPlane));
			Vector3 diff = player.position - startpos;;
			/*if(direction == 1)
				diff = player.position - startpos;
			else
				diff = startpos - player.position;*/
			diff.Normalize();

			Quaternion quat = Quaternion.Euler(0f, 0f, -50f);

			GameObject spawned;// = (GameObject)Instantiate(Resources.Load("Prefabs/SowaKadlub"), startpos, quat);

			//float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
			//transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 30f);

			spawned = (GameObject)Instantiate(Resources.Load("Prefabs/SowaKadlub"), 
				startpos, new Quaternion(0f, 0f, 0f, 0f));

			spawned.GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(diff * 100000f, Random.Range(10f, 25f));

			//spawned.GetComponent<Rigidbody2D>().velocity = diff * 10;
			float scalevalue = Random.Range(-0.2f, 0.3f);
			spawned.transform.localScale += new Vector3(scalevalue, scalevalue, 1);
			spawned.GetComponent<Rigidbody2D> ().gravityScale *= Random.Range (0.8f, 1.2f);

			waitTime *= Random.Range (0.6f, 1.5f);

			StopCoroutine(SpawnBirds(0f));

			yield return new WaitForSeconds(waitTime);
		}
	}

	public void Stop() {
		enabled = false;
		StopAllCoroutines ();
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}

}
