using UnityEngine;
using System.Collections;

public class Nietup : MonoBehaviour {

    public Actions currentAction;
    //public Transform StoneGun;
    public Transform GirlGhost;

	// Use this for initialization
	void Start () {
        currentAction = Actions.Mister4;
	}
	
	// Update is called once per frame
	void Update () {
	    switch (currentAction)
        {
            case Actions.Girl1:
                GetComponent<GirlOne>().enabled = true;
                GirlGhost.GetComponent<GirlOneMovement>().enabled = true;
                break;
            case Actions.Girl2:
                GetComponent<GirlOne>().enabled = false;
                GirlGhost.GetComponent<GirlOneMovement>().enabled = false;

                GirlGhost.GetComponent<GirlTwoMovement>().enabled = true;
                GirlGhost.GetComponent<GirlTwoMovement>().OnActionStart();
                break;
            case Actions.Girl3:
                GirlGhost.GetComponent<GirlTwoMovement>().enabled = false;
                GetComponent<GirlThree>().enabled = true;
                GetComponent<GirlThree>().OnActionStart();
                break;
        }

        if (Input.GetMouseButtonDown(0))
            currentAction++;
	}
}
