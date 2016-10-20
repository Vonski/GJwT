using UnityEngine;
using System.Collections;

public class Kids_one : MonoBehaviour {
    public Transform p1;
    private Transform boy, girl, boy_pos, girl_pos, bskak, gskak;
    int tmp;
    float time;
    bool isEnd;

    // Use this for initialization
    void Start () {
        tmp = 0;
        girl = p1.GetChild(1).GetChild(0);
        boy = p1.GetChild(0).GetChild(0);
        girl_pos = p1.GetChild(1);
        boy_pos = p1.GetChild(0);
        gskak = girl.GetChild(5);
        bskak = boy.GetChild(5);
        StartCoroutine(IsJumpingFast(1f));
        isEnd = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            boy.GetComponent<Animator>().SetBool("IsJumping",true);
            girl.GetComponent<Animator>().SetBool("IsJumping", true);
            time = Time.time;
            tmp++;
        }
        if(time+0.1f<Time.time)
        {
            boy.GetComponent<Animator>().SetBool("IsJumping", false);
            girl.GetComponent<Animator>().SetBool("IsJumping", false);
        }
        if(isEnd)
        {
            bskak.GetComponent<SpriteRenderer>().enabled = false;
            gskak.GetComponent<SpriteRenderer>().enabled = false;

            GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/AerobikBoyKadlub"), boy_pos.position, boy.transform.rotation);
            spawned.transform.parent = boy_pos;
            spawned.transform.localScale = boy.localScale;
            spawned = (GameObject)Instantiate(Resources.Load("Prefabs/AerobikGirlKadlub"), girl_pos.position, girl.transform.rotation);
            spawned.transform.parent = girl_pos;
            spawned.transform.localScale = girl.localScale;

            Destroy(boy.gameObject);
            Destroy(girl.gameObject);

            GetComponent<Points>().ghost1++;

            p1.position += Vector3.right * 16f;
            girl_pos.position += Vector3.right * 4f + Vector3.up*0.05f;
            boy_pos.position -= Vector3.right * 1f + Vector3.up * 0.02f;
            GetComponent<ScenarioController>().currentAction++;
        }
    }

    IEnumerator IsJumpingFast(float waitTime)
    {
        while (true)
        {
            if (tmp > 0)
            {
                boy.GetComponent<Animator>().SetBool("IsJumping", false);
                girl.GetComponent<Animator>().SetBool("IsJumping", false);
                isEnd = true;
                
                StopCoroutine(IsJumpingFast(0f));
            }
            tmp = 0;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
