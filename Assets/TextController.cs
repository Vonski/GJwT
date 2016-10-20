using UnityEngine;
using System.Collections;

public class TextController : MonoBehaviour {

    public AudioClip keep1, keep2, keep3, hurry1, hurry2, doit1, doit2;
    AudioSource source;

    float time;
    bool isActive=false;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () {
        int tmp;

        if ((tmp = (int)Random.Range(0f, 300f)) < 3 && !isActive)
        {
            transform.GetChild(tmp).gameObject.SetActive(true);
            transform.GetChild(tmp).transform.Rotate(0f,0f,Random.Range(-30f,30f));
            if (tmp == 0)
            {
                if(Random.Range(0f,100f)<33f)
                    source.clip = keep1;
                else if (Random.Range(0f, 100f) < 66f)
                    source.clip = keep2;
                else
                    source.clip = keep3;
                source.Play();
            }
            else if (tmp == 2)
            {
                if (Random.Range(0f, 100f) < 50f)
                    source.clip = hurry1;
                else
                    source.clip = hurry2;
                source.Play();
            }
            else
            {
                if (Random.Range(0f, 100f) < 50f)
                    source.clip = doit1;
                else
                    source.clip = doit2;
                source.Play();
            }
            time = Time.time;
            isActive = true;
        }

        if(time +1f<Time.time && !source.isPlaying)
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
