using UnityEngine;
using System.Collections;

public class GirlFour : MonoBehaviour {

    bool Started = false;
    bool FirstH = true;
    bool SecondH = true;
    GameObject Johny;
    int shakes = 0;
    public bool lerp = false;
    Vector3 dest;
    public AudioClip bravo1, bravo2, bravo3, bravo4;
    AudioSource source;

    // Use this for initialization
    void Start () {
        
    }

    public void OnActionStart()
    {
        if (!Started)
        {
            Johny = (GameObject)Instantiate(Resources.Load("Prefabs/Jonhy"), transform.parent.transform.position + new Vector3(1.0f, -3.6f, 0), Quaternion.Euler(0f, 0f, 95f));
            Johny.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            Started = FirstH = true;
            dest = transform.parent.transform.position + new Vector3(0, 72.0f, 0);
            source = GetComponent<AudioSource>();
        }

    }

    // Update is called once per frame
    void Update()
    {

        if(!source.isPlaying)
        {
            if (Random.Range(0f, 100f) < 20f)
                source.clip = bravo1;
            else if (Random.Range(0f, 100f) < 40f)
                source.clip = bravo2;
            else if (Random.Range(0f, 100f) < 80f)
                source.clip = bravo3;
            else
                source.clip = bravo4;
            source.Play();
        }

        if (!lerp) { 
        if (FirstH)
            if (Input.GetKeyDown("up"))
            {
                SecondHands();
                shakes++;
            }

        if (SecondH)
        {
            if (Input.GetKeyDown("down"))
            {
                FirstHands();
                shakes++;
            }
        }

            if (Input.GetKeyDown("left"))
            {
                ThirdHands();
                shakes++;
            }

            if (shakes == 8)
        {
            lerp = true;
        }
    }
	}

    void FixedUpdate()
    {
        if (lerp)
        {
            Vector3 diff = dest - transform.parent.transform.position;
            diff.Normalize();
            if (Vector3.Distance(transform.parent.transform.position, dest) > 0.3f)
            {

                transform.parent.transform.position += diff * 0.4f;
            }
            //else
                //GameController.GetComponent<ScenarioController>().currentAction++;
        }
    }

    void FirstHands()
    {
        //FirstH = true;
        //SecondH = false;
        //Johny.transform.GetChild(0).transform.Rotate(0, 0, 90);
        Vector3 JS = Johny.transform.GetChild(0).transform.localScale;
        Transform JH = Johny.transform.GetChild(0).transform;
        Johny.transform.GetChild(0).transform.localScale = new Vector3(JS.x, -JS.y, JS.z);
        JH.position += new Vector3(0, 2, 0);
    }

    void SecondHands()
    {
        //SecondH = true;
        //FirstH = false;
        //Johny.transform.GetChild(2).transform.Rotate(0, 0, 90);
        Transform JH = Johny.transform.GetChild(2).transform;
        Vector3 JS = Johny.transform.GetChild(2).transform.localScale;
        Johny.transform.GetChild(2).transform.localScale = new Vector3(JS.x, -JS.y, JS.z);
        JH.Rotate(0, 0, 90);
        JH.position += new Vector3(0, -0.4f, 0);
    }

    void ThirdHands()
    {
        Vector3 JS = Johny.transform.GetChild(0).transform.localScale;
        Transform JH = Johny.transform.GetChild(0).transform;
        JH.position -= new Vector3(0, 2, 0);
        Johny.transform.GetChild(0).transform.localScale = new Vector3(JS.x, -JS.y, JS.z);
    }
}
