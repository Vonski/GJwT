using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private int currentAction;
    public Transform controller;
    public Transform p1;
    public Transform p2;
    public Transform p3;

    // Update is called once per frame
    void Update () {

        currentAction = controller.GetComponent<ScenarioController>().currentAction;

        switch (currentAction)
        {
            case 1:
                transform.position = p1.transform.position + Vector3.back*10;
                break;
            case 6:
                transform.position = p2.transform.position + Vector3.back * 10;
                break;
            case 11:
                transform.position = p3.transform.position + Vector3.back * 10;
                break;
        }
    }
}
