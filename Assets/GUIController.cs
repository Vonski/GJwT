using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

    void Start()
    {
    }

    public void StartGame()
    {
        //GameObject.Find("GameController").GetComponent<AudioSource>().enabled = true;
        GameObject.Find("GameController").GetComponent<ScenarioController>().currentAction++;
        gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
