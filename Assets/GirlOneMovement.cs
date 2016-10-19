using UnityEngine;
using System.Collections;
using System;

public class GirlOneMovement : MonoBehaviour {

    private float offset = 0.0f;
    private Vector2 GirlStartPosition;
    public float XMovementRange = 7.0f;
    public float YMovementRange = 1.0f;
    public Transform GameController;

	// Use this for initialization
	void Start () {
        enabled = false;
        GirlStartPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        offset += 0.01f;

        Vector2 newPos = new Vector2(
            XMovementRange * (float)Math.Sin(offset) + GirlStartPosition.x,
            YMovementRange * (float)Math.Cos(7*offset) + GirlStartPosition.y
        );

        transform.position = newPos;
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Missile")
            GameController.GetComponent<Nietup>().currentAction++;
    }
}
