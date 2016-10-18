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
                transform.position = p1.transform.position + Vector3.back*10;
                break;
            case Actions.Mister1:
                transform.position = p2.transform.position + Vector3.back * 10;
                break;
            case Actions.Girl1:
                transform.position = p3.transform.position + Vector3.back * 10;
                break;
        }

        
    }
}
