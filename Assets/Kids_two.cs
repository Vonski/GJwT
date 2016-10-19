using UnityEngine;
using System.Collections;

public class Kids_two : MonoBehaviour {

    public Transform hangman;
    public Transform p1;
    private Transform boy, girl, boy_pos, girl_pos;
    public int[] table;
    private int currentIndex;
    public float time;

    // Use this for initialization
    void Start () {
        hangman.GetComponent<AerobikController>().enabled = true;
        girl = p1.GetChild(1).GetChild(0);
        boy = p1.GetChild(0).GetChild(0);
        girl_pos = p1.GetChild(1);
        boy_pos = p1.GetChild(0);
        currentIndex = 0;
        table = new int[5];
    }

    // Update is called once per frame
    void Update () {
        if(hangman.GetComponent<AerobikController>().tmp==0)
        {
            hangman.GetComponent<AerobikController>().enabled = false;
            for (int i = 0; i < 5; i++)
                table[i] = hangman.GetComponent<AerobikController>().table2[i];
        }

        if (currentIndex < table.Length)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
                if (table[currentIndex] == 1)
                {
                    boy.GetComponent<Animator>().SetBool("LeftArm",true);
                    girl.GetComponent<Animator>().SetBool("LeftArm", true);

                    time = Time.time;
                    currentIndex++;
                    return;
                }

            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
                if (table[currentIndex] == 2)
                {
                    boy.GetComponent<Animator>().SetBool("RightArm", true);
                    girl.GetComponent<Animator>().SetBool("RightArm", true);

                    time = Time.time;
                    currentIndex++;
                    return;
                }

            if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
                if (table[currentIndex] == 3)
                {
                    boy.GetComponent<Animator>().SetBool("LeftLeg", true);
                    girl.GetComponent<Animator>().SetBool("LeftLeg", true);

                    time = Time.time;
                    currentIndex++;
                    return;
                }

            if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
                if (table[currentIndex] == 4)
                {
                    boy.GetComponent<Animator>().SetBool("RightLeg", true);
                    girl.GetComponent<Animator>().SetBool("RightLeg", true);

                    time = Time.time;
                    currentIndex++;
                    return;
                }

            if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
                if (table[currentIndex] == 5)
                {
                    boy.GetComponent<Animator>().SetBool("Head", true);
                    girl.GetComponent<Animator>().SetBool("Head", true);

                    time = Time.time;
                    currentIndex++;
                    return;
                }

            if (Input.anyKeyDown)
            {
                Debug.Log("Failure");
                p1.position += Vector3.right * 24f + Vector3.down*2f;

                GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/BoyMcKadlub"), boy.transform.position + Vector3.up * 0.08f, boy.transform.rotation);
                spawned.transform.parent = boy_pos;
                spawned.transform.localScale = boy.localScale/3;
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/GirlMcKadlub"), girl.transform.position + Vector3.up * 0.24f, girl.transform.rotation);
                spawned.transform.parent = girl_pos;
                spawned.transform.localScale = girl.localScale/3;

                Destroy(boy.gameObject);
                Destroy(girl.gameObject);

                girl_pos.position += Vector3.up * 0.55f;
                boy_pos.position += Vector3.right * 5f + Vector3.up * 0.15f;
                
                GetComponent<ScenarioController>().currentAction++;
            }
        }
        else
        {
            GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/BoyMcKadlub"), boy.transform.position + Vector3.up * 0.08f, boy.transform.rotation);
            spawned.transform.parent = boy_pos;
            spawned.transform.localScale = boy.localScale / 3;
            spawned = (GameObject)Instantiate(Resources.Load("Prefabs/GirlMcKadlub"), girl.transform.position + Vector3.up * 0.24f, girl.transform.rotation);
            spawned.transform.parent = girl_pos;
            spawned.transform.localScale = girl.localScale / 3;

            Destroy(boy.gameObject);
            Destroy(girl.gameObject);

            girl_pos.position += Vector3.up * 0.55f;
            boy_pos.position += Vector3.right * 5f + Vector3.up * 0.15f;

            GetComponent<ScenarioController>().currentAction++;
        }

        if (time + 0.3f < Time.time)
        {
            boy.GetComponent<Animator>().SetBool("LeftArm", false);
            boy.GetComponent<Animator>().SetBool("RightArm", false);
            boy.GetComponent<Animator>().SetBool("LeftLeg", false);
            boy.GetComponent<Animator>().SetBool("RightLeg", false);
            boy.GetComponent<Animator>().SetBool("Head", false);
            girl.GetComponent<Animator>().SetBool("LeftArm", false);
            girl.GetComponent<Animator>().SetBool("RightArm", false);
            girl.GetComponent<Animator>().SetBool("LeftLeg", false);
            girl.GetComponent<Animator>().SetBool("RightLeg", false);
            girl.GetComponent<Animator>().SetBool("Head", false);
        }

    }
}
