using UnityEngine;
using System.Collections;

public class Kids_four : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Shot");
            GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Missile"),transform.position+diff*5f,new Quaternion(0f,0f,0f,0f));
            spawned.GetComponent<Rigidbody2D>().velocity = diff * 30;
        }
            
    }
}
