﻿using UnityEngine;
using System.Collections;

public class GirlOneCollisionScript : MonoBehaviour {

    public Transform GameController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Missile")
            GameController.GetComponent<ScenarioController>().currentAction++;
    }
}
