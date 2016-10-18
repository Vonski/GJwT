﻿using UnityEngine;
using System.Collections;

public enum Actions { Kids1, Kids2, Kids3, Kids4, Kids5, Mister1, Mister2, Mister3, Mister4, Girl1, Girl2, Girl3, Girl4, Girl5 };

public class ScenarioController : MonoBehaviour {

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