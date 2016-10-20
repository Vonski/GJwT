using UnityEngine;
using System.Collections;

public class GirlFour : MonoBehaviour {

    bool Started = false;
    bool FirstH = false;
    bool SecondH = false;
    GameObject Johny;

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
        }

    }

    // Update is called once per frame
    void Update () {
        if (FirstH)
        if (Input.GetKeyDown("up"))
        {
                SecondHands();
        }

        if (SecondH)
        {
            if (Input.GetKeyDown("down"))
            {
                FirstHands();
            }
        }
	}

    void FirstHands()
    {
        FirstH = true;
        SecondH = false;
        Johny.transform.GetChild(0).transform.Rotate(0, 0, 90);
    }

    void SecondHands()
    {
        SecondH = true;
        FirstH = false;
        Johny.transform.GetChild(2).transform.Rotate(0, 0, 90);
    }
}
