using UnityEngine;
using System.Collections;

public class SowaDestroy : MonoBehaviour {
	public bool destroyed = false;
	// Use this for initialization
	void Start () {
		destroyed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (destroyed) {
			for (int i = 0; i < transform.childCount; i++) {
				transform.GetChild (i).gameObject.transform.position += transform.GetChild (i).gameObject.transform.right * 1f * Time.deltaTime;
			}
		
		}
	}

	public void DestroySowa() {
		destroyed = true;

		GetComponent<Rigidbody2D> ().gravityScale = 2.0f;

		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild (i).gameObject.transform.Rotate(0f, 0f, Random.Range(0f, 360f));

			transform.GetChild(i).gameObject.transform.position += new Vector3(Random.Range(-2f, 2f),
				Random.Range(-2f, 2f), 0f);
		}
	}
}
