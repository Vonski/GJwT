using UnityEngine;
using System.Collections;

public class ScenarioController : MonoBehaviour {

    public int currentAction;

	// Use this for initialization
	void Start () {
        currentAction = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    switch (currentAction)
        {
            case 1:
                break;
        }

        if (Input.GetMouseButtonDown(0))
            currentAction++;
	}
}
