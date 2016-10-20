using UnityEngine;
using System.Collections;
using System;

public class GirlOneMovement : MonoBehaviour {

    private float offset = 0.0f;
    private Vector2 GirlStartPosition;
    public float XMovementRange = 7.0f;
    public float YMovementRange = 1.0f;
    public Transform GameController;
    public Transform p3;
    public bool lerp = false;
    Vector3 dest;

	// Use this for initialization
	void Start () {
        enabled = false;
        GirlStartPosition = transform.position;
        dest = transform.parent.transform.position + new Vector3(0, -24.0f, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (!lerp)
        {
            offset += 0.01f;

            Vector2 newPos = new Vector2(
                XMovementRange * (float)Math.Sin(offset) + GirlStartPosition.x,
                YMovementRange * (float)Math.Cos(7 * offset) + GirlStartPosition.y
            );

            transform.position = newPos;
        }
	}

    void FixedUpdate()
    {
        if (lerp)
        {
            Vector3 diff = dest - transform.parent.transform.position;
            diff.Normalize();
            if (Vector3.Distance(transform.parent.transform.position, dest) > 0.3f)
                transform.parent.transform.position += diff * 0.2f;
            else
                GameController.GetComponent<ScenarioController>().currentAction++;
        }
    }
    
}
