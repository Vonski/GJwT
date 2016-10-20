using UnityEngine;
using System.Collections;

public class TextController : MonoBehaviour {

    float time;
    bool isActive=false;

	// Update is called once per frame
	void Update () {
        int tmp;

        if ((tmp = (int)Random.Range(0f, 300f)) < 3 && !isActive)
        {
            transform.GetChild(tmp).gameObject.SetActive(true);
            transform.GetChild(tmp).transform.Rotate(0f,0f,Random.Range(-30f,30f));
            time = Time.time;
            isActive = true;
        }

        if(time +1f<Time.time)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(0).transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            transform.GetChild(1).transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            transform.GetChild(2).transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            isActive = false;
        }
            
	}
}
