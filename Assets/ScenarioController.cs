using UnityEngine;
using System.Collections;

public enum Actions { Init, Kids1, Kids2, Kids3, Kids4, Mister2, Mister3, Mister4, Girl1, Girl2, Girl3, Girl4, Girl5 };

public class ScenarioController : MonoBehaviour {

    public Actions currentAction;
    public Transform GirlGhost;
    public Transform armata;
    public Transform kid;

    // Use this for initialization
    void Start () {
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
                armata.GetComponent<Kids_three>().enabled = true;
                break;
		case Actions.Kids4:
			armata.GetComponent<Kids_three> ().enabled = false;
			armata.GetComponent<Kids_three> ().StopAllCoroutines ();
			armata.GetComponent<Kids_four>().enabled = true;

                break;
     
		case Actions.Mister2:
                GetComponent<Mister_two>().enabled = true;
                // GetComponent<Mister_three>().enabled = true;
                break;
		case Actions.Mister3:
			GetComponent<Mister_two>().enabled = false;
            GetComponent<Mister_three>().enabled = true;
                if(GameObject.Find("MazeWall"))
                    GameObject.Find("MazeWall").SetActive(false);
                break;
		case Actions.Mister4:
                GetComponent<Mister_three>().enabled = false;
                GetComponent<Mister_four>().enabled = true;
                break;

            case Actions.Girl1:
                GetComponent<GirlOne>().enabled = true;
                GirlGhost.GetComponent<GirlOneMovement>().enabled = true;
                break;
            case Actions.Girl2:
                GetComponent<GirlOne>().enabled = false;
                GirlGhost.GetComponent<GirlOneMovement>().enabled = false;

                //GirlGhost.GetComponent<GirlTwoMovement>().enabled = true;
                //GirlGhost.GetComponent<GirlTwoMovement>().OnActionStart();

                currentAction = Actions.Girl3;

                break;
            case Actions.Girl3:
                GirlGhost.GetComponent<GirlTwoMovement>().enabled = false;
                GirlGhost.GetComponent<GirlThree>().enabled = true;
                GirlGhost.GetComponent<GirlThree>().OnActionStart();
                break;
            case Actions.Girl4:
                GirlGhost.GetComponent<GirlThree>().enabled = false;
                GirlGhost.GetComponent<GirlFour>().enabled = true;
                GirlGhost.GetComponent<GirlFour>().OnActionStart();
                break;
        }

        /*if (Input.GetMouseButtonDown(0))
            GetComponent<ScreenShake>().shakeDuration = 2f;*/
	}
}
