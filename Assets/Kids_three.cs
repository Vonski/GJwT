using UnityEngine;
using System.Collections;

public class Kids_three : MonoBehaviour {

    public Transform p1;

	// Use this for initialization
	void Start () {
        StartCoroutine(RespawnBurger(1f));
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Missile"), transform.position + diff * 5f, new Quaternion(0f, 0f, 0f, 0f));
            spawned.GetComponent<Rigidbody2D>().gravityScale = 0f;
            spawned.GetComponent<Rigidbody2D>().velocity = diff * 30;
        }
    }

    IEnumerator RespawnBurger(float waitTime)
    {
        while (true)
        {
            GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Missile"), new Vector3(-10f,Random.Range(-3f,6f)), new Quaternion(0f, 0f, 0f, 0f));
            spawned.GetComponent<Rigidbody2D>().gravityScale = 0f;

            Vector3 diff = p1.transform.position - spawned.transform.position;
            diff.Normalize();
            
            spawned.GetComponent<Rigidbody2D>().velocity = diff * 5f;

            yield return new WaitForSeconds(waitTime);
        }
    }
}
