using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

    void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        GameObject.Find("GameController").GetComponent<ScenarioController>().currentAction++;
        gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
