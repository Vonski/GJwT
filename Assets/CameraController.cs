using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private Actions currentAction;
    public Transform controller;
    public Transform p1;
    public Transform p2;
    public Transform p3;

    // Update is called once per frame
    void Update () {

        currentAction = controller.GetComponent<ScenarioController>().currentAction;

        switch (currentAction)
        {
        case Actions.Kids1:
                transform.position = p1.transform.position + Vector3.back*10 + Vector3.up * 1.4f;
                break;
		case Actions.Kids2:
			transform.position = p1.transform.position + Vector3.back*10 + Vector3.up*1.6f;
			break;
		case Actions.Kids3:
			transform.position = p1.transform.position + Vector3.back*10 + Vector3.left*5f + Vector3.up*2f;
			break;
		case Actions.Kids4:
			transform.position = p1.transform.position + Vector3.back * 10 + Vector3.left * 5f + Vector3.up * 2f;
			break;
		case Actions.Kids5:
			transform.position = p1.transform.position + Vector3.back*10;
			break;
		case Actions.Mister1:
                transform.position = p2.transform.position + Vector3.back * 10;
                break;
		case Actions.Mister2:
			transform.position = p2.transform.position + Vector3.back * 10;
			break;
		case Actions.Mister3:
			transform.position = p2.transform.position + Vector3.back * 10;
			break;
		case Actions.Mister4:
			transform.position = p2.transform.position + Vector3.back * 10;
			break;
            case Actions.Girl1:
                transform.position = p3.transform.position + Vector3.back * 10;
                break;
            case Actions.Girl2:
                transform.position = p3.transform.position + Vector3.back * 10;
                break;
            case Actions.Girl3:
                transform.position = p3.transform.position + Vector3.back * 10;
                break;
        }

        
    }
}
