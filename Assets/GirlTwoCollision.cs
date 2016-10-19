﻿using UnityEngine;
using System.Collections;

public class GirlTwoCollision : MonoBehaviour {

    public Transform Parent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Lasso")
            Parent.GetComponent<GirlTwoMovement>().GetCaught();
    }
}