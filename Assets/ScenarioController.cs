﻿using UnityEngine;
using System.Collections;

public enum Actions { Kids1, Kids2, Kids3, Kids4, Kids5, Mister1, Mister2, Mister3, Mister4, Girl1, Girl2, Girl3, Girl4, Girl5 };

public class ScenarioController : MonoBehaviour {

    public Actions currentAction;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    switch (currentAction)
        {
            case Actions.Kids1:
                break;
		case Actions.Mister1:
			if(GetComponent<Mister_one>().enabled == false) {
				GetComponent<Mister_two>().enabled = true;
				currentAction++;
			}
			break;
		case Actions.Mister2:
			if(GetComponent<Mister_two>().enabled == false) {
				GetComponent<Mister_three>().enabled = true;
				currentAction++;
			}
			break;
		case Actions.Mister3:
			/*GetComponent<Mister_two>().enabled = false;
			GetComponent<Mister_three>().enabled = true;
			*/
			if(GetComponent<Mister_three>().enabled == false) {
				GetComponent<Mister_four>().enabled = true;
				currentAction++;
			}

			break;
		case Actions.Mister4:
			//GetComponent<Mister_four>().enabled = true;
			break;
        }

        /*if (Input.GetMouseButtonDown(0))
            currentAction++;*/
	}
}
