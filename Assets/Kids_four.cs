using UnityEngine;
using System.Collections;

public class Kids_four : MonoBehaviour {
	public Transform controller;
	public Transform boy, girl;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Vector3.back * 10 - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 30f);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Missile/Missile"), transform.position + diff * 8f * transform.localScale.x + Vector3.Cross(diff, Vector3.back) * 1.8f * transform.localScale.x, new Quaternion(0f, 0f, 0f, 0f));
            spawned.transform.localScale = transform.localScale;
            spawned.GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(diff * 1000000f, 13f);
        }

		if ((boy.GetChild(0).position.y > 20f && girl.GetChild(0).position.y > 20f)
			|| (boy.GetChild(0).position.y <= -10f && girl.GetChild(0).position.y <= -10f)) {

			controller.GetComponent<ScenarioController>().currentAction++;
			enabled = false;
		}
            
    }
}
