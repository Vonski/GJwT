using UnityEngine;
using System.Collections;

public class Mister_three : MonoBehaviour {
	public Transform player;
	public Texture2D cursortex;

	int points = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnBirds(1.5f));
		Vector2 pos = new Vector2 (cursortex.width/2f, cursortex.height/2f);
		Cursor.SetCursor (cursortex, pos, CursorMode.ForceSoftware);

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
			}
		}

		if (points >= 6) {
			Stop ();
		}
	}

	IEnumerator SpawnBirds(float waitTime)
	{
		while (true)
		{
			Vector3 startpos = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 
			Random.Range(Camera.main.pixelHeight/2f, Camera.main.pixelHeight), Camera.main.nearClipPlane));
			Vector3 diff = player.position - startpos;
			//Vector3 diff = startpos - player.position;
			diff.Normalize();


			//float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
			//transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
			Quaternion quat = Quaternion.Euler(0f, 0f, -50f);

			GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/SowaKadlub"), startpos, quat);
			spawned.GetComponent<Rigidbody2D>().velocity = diff * 10;
			spawned.GetComponent<Rigidbody2D> ().gravityScale *= Random.Range (0.7f, 1.5f);

			waitTime *= Random.Range (0.8f, 1.5f);

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
