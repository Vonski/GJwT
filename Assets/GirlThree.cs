using UnityEngine;
using System.Collections;

public class GirlThree : MonoBehaviour {

    bool Shake = false;
    bool Started = false;
    string Target = "thereisnosanta";
    int CurrentLetter = 0;

	// Use this for initialization
	void Start () {
        enabled = false;
    }
	
    public void OnActionStart()
    {
        if (!Started)
        {
            transform.position = transform.parent.transform.position;
            GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/there"), transform.position + new Vector3(1.0f,-3,0), new Quaternion(0f, 0f, 0f, 0f));
        }
        Started = true;
    }

	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown((char.ToString(Target[CurrentLetter])))) {

            if (CurrentLetter == 4)
            {
                GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/is"), transform.position + new Vector3(1.0f, -3, 0), new Quaternion(0f, 0f, 0f, 0f));
            }
            if (CurrentLetter == 6)
            {
                GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/no"), transform.position + new Vector3(1.0f, -3, 0), new Quaternion(0f, 0f, 0f, 0f));
            }
            if (CurrentLetter == 8)
            {
                GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/santa"), transform.position + new Vector3(1.0f, -3, 0), new Quaternion(0f, 0f, 0f, 0f));
            }

            CurrentLetter++;
            if (CurrentLetter >= Target.Length)
            {
                CurrentLetter = 0;
                Shake = true;
            }
        }


        if (Shake)
            ShakeIt();
	}

    void ShakeIt()
    {
        transform.position += new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.1f, 0.1f), 0);
    }
}
