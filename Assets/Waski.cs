using UnityEngine;
using System.Collections;

public class Waski : MonoBehaviour {

    public Actions currentAction;

	// Use this for initialization
	void Start () {
        currentAction = Actions.Kids1;
	}
	
	// Update is called once per frame
	void Update () {
	    switch (currentAction)
        {
            case Actions.Kids1:
                break;
        }

        if (Input.GetMouseButtonDown(0))
            currentAction++;
	}
}
