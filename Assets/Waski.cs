using UnityEngine;
using System.Collections;

public class Waski : MonoBehaviour {

    public Actions currentAction;
    public Transform armata;
    public Transform kid;

	// Use this for initialization
	void Start () {
        currentAction = Actions.Kids1;
    }
	
	// Update is called once per frame
	void Update () {
        
        switch (currentAction)
        {
            case Actions.Kids1:
                GetComponent<Kids_one>().enabled = true;
                break;
            case Actions.Kids2:
                GetComponent<Kids_one>().enabled = false;
                GetComponent<Kids_two>().enabled = true;
                break;
            case Actions.Kids3:
                GetComponent<Kids_two>().enabled = false;
                break;
            case Actions.Kids4:
                armata.GetComponent<Kids_four>().enabled = true;
                break;
            case Actions.Kids5:
                armata.GetComponent<Kids_four>().enabled = false;
                kid.GetComponent<Kids_five>().enabled = true;
                break;
        }

        if (Input.GetMouseButtonDown(0))
            currentAction++;
	}
}
