using UnityEngine;
using System.Collections;

public class Raptor : MonoBehaviour {

    public Actions currentAction;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    switch (currentAction)
        {
		case Actions.Mister1:
			GetComponent<Mister_one>().enabled = true;
			break;
		case Actions.Mister2:
			GetComponent<Mister_one>().enabled = false;
			GetComponent<Mister_two>().enabled = true;
			break;
		case Actions.Mister3:
			GetComponent<Mister_two>().enabled = false;
			GetComponent<Mister_three>().enabled = true;
			break;
		case Actions.Mister4:
			GetComponent<Mister_three>().enabled = false;
			GetComponent<Mister_four>().enabled = true;
			break;
		/*case Actions.Mister5:
			GetComponent<Mister_four>().enabled = false;
		
			break;*/
        }
	}
}
