using UnityEngine;
using System.Collections;

public class Mister_three : MonoBehaviour {
	public Transform player;


	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnBirds(1.5f));
	}
	
	// Update is called once per frame
	void Update () {


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


			float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

			GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Bird"), startpos,new Quaternion(0f,0f,0f,0f));
			spawned.GetComponent<Rigidbody2D>().velocity = diff * 10;


			StopCoroutine(SpawnBirds(0f));

			yield return new WaitForSeconds(waitTime);
		}
	}
}
