using UnityEngine;
using System.Collections;

public class GirlThree : MonoBehaviour {

    bool Shake = false;
    bool Started = false;
    string Target = "thereisnosanta";
    int CurrentLetter = 0;
    float time = 3;
    public bool lerp = false;
    Vector3 dest;
    public Transform GameController;

	// Use this for initialization
	void Start () {
        enabled = false;
    }
	
    public void OnActionStart()
    {
        if (!Started)
        {
            transform.position = transform.parent.transform.position;
            GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/there2"), transform.position + new Vector3(1.0f,-3,0), new Quaternion(0f, 0f, 0f, 0f));
            dest = transform.parent.transform.position + new Vector3(0, -12.0f, 0);
        }
        Started = true;
    }

	// Update is called once per frame
	void Update () {
        if (!lerp)
        {
            if (Input.GetKeyDown((char.ToString(Target[CurrentLetter]))))
            {

                if (CurrentLetter == 4)
                {
                    GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/is2"), transform.position + new Vector3(1.0f, -3, 0), new Quaternion(0f, 0f, 0f, 0f));
                }
                if (CurrentLetter == 6)
                {
                    GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/no2"), transform.position + new Vector3(1.0f, -3, 0), new Quaternion(0f, 0f, 0f, 0f));
                }
                if (CurrentLetter == 8)
                {
                    GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/santa2"), transform.position + new Vector3(1.0f, -3, 0), new Quaternion(0f, 0f, 0f, 0f));
                }

                CurrentLetter++;
                if (CurrentLetter >= Target.Length)
                {
                    CurrentLetter = 0;
                    Shake = true;
                }
            }

            if (Shake)
            {
                time -= Time.deltaTime;
                if (time >= 0)
                    ShakeIt();
                else
                    Stop();
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

                transform.parent.transform.position += diff * 0.1f;
            }
            else
                GameController.GetComponent<ScenarioController>().currentAction++;
        }
    }

    void ShakeIt()
    {
        transform.position += new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.1f, 0.1f), 0);
    }

    void Stop()
    {
        //transform.parent.transform.position += new Vector3(0, -12, 0);
        //GameController.GetComponent<ScenarioController>().currentAction++;
        lerp = true;
    }
}
