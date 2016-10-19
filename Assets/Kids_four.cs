using UnityEngine;
using System.Collections;

public class Kids_four : MonoBehaviour {

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
            int tmp = (int)Random.Range(0f, 100f);
            GameObject spawned;
            if (tmp < 33)
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Missile/Apple"), transform.position + diff * 8f * transform.localScale.x + Vector3.Cross(diff, Vector3.back) * 1.8f * transform.localScale.x, new Quaternion(0f, 0f, 0f, 0f));
            else if (tmp < 66)
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Missile/Carrot"), transform.position + diff * 8f * transform.localScale.x + Vector3.Cross(diff, Vector3.back) * 1.8f * transform.localScale.x, new Quaternion(0f, 0f, 0f, 0f));
            else
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Missile/Brokul"), transform.position + diff * 8f * transform.localScale.x + Vector3.Cross(diff, Vector3.back) * 1.8f * transform.localScale.x, new Quaternion(0f, 0f, 0f, 0f));
            spawned.transform.localScale = transform.localScale / 3f;
            spawned.GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(diff * 1000000f, 20f);
        }
            
    }
}
