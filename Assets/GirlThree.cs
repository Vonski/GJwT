using UnityEngine;
using System.Collections;

public class GirlThree : MonoBehaviour {

    private bool Shake = false;

	// Use this for initialization
	void Start () {
        enabled = false;
	}
	
    public void OnActionStart()
    {

    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("w"))
           Shake = true;

        if (Shake)
            ShakeIt();
	}

    void ShakeIt()
    {
        Debug.Log("I shake");
        transform.position += new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.1f, 0.1f), 0);
    }
}
