using UnityEngine;
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
        {
            gameObject.transform.parent.transform.parent.transform.position += new Vector3(0, -12.0f, 0);
            GameController.GetComponent<ScenarioController>().currentAction++;
        }
    }
}
