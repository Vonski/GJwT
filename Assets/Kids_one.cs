using UnityEngine;
using System.Collections;

public class Kids_one : MonoBehaviour {
    public Transform p1;
    private Transform boy, girl, boy_pos, girl_pos, bskak, gskak;
    int tmp;
    float time;
    bool isEnd,lerp;
    Vector3 dest, destb, destg;

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
        lerp = false;
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
        if(time+0.1f<Time.time && !isEnd && !lerp)
        {
            boy.GetComponent<Animator>().SetBool("IsJumping", false);
            girl.GetComponent<Animator>().SetBool("IsJumping", false);
        }
        if(isEnd)
        {
            bskak.GetComponent<SpriteRenderer>().enabled = false;
            gskak.GetComponent<SpriteRenderer>().enabled = false;

            boy.transform.position = new Vector3(boy.transform.position.x, -1f,0f);
            girl.transform.position = new Vector3(girl.transform.position.x, -1.24f, 0f);

            GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/AerobikBoyKadlub"), boy.position, boy.transform.rotation);
            spawned.transform.parent = boy_pos;
            spawned.transform.localScale = boy.localScale;
            spawned = (GameObject)Instantiate(Resources.Load("Prefabs/AerobikGirlKadlub"), girl.position, girl.transform.rotation);
            spawned.transform.parent = girl_pos;
            spawned.transform.position += Vector3.up * 0.2f;
            spawned.transform.localScale = girl.localScale;

            Destroy(boy.gameObject);
            Destroy(girl.gameObject);

            GetComponent<Points>().ghost1++;

            lerp = true;
            isEnd = false;

            dest = p1.position + Vector3.right * 16f;
            destg = girl_pos.position + Vector3.right * 16f - Vector3.right * 4f;
            destb = girl_pos.position + Vector3.right * 16f - Vector3.right * 8f + Vector3.up * 0.15f;
        }
    }

    void FixedUpdate()
    {
        if (lerp)
        {
            Vector3 diff = dest - p1.transform.position;
            diff.Normalize();
            if (Vector3.Distance(p1.transform.position, dest) > 0.3f)
                p1.transform.position += diff*0.4f;
            else if (Vector3.Distance(girl_pos.transform.position, destg) > 0.3f)
            {
                diff = destg - girl_pos.position;
                diff.Normalize();

                girl_pos.transform.position += diff * 0.4f;
            }
            else if (Vector3.Distance(boy_pos.transform.position, destb) > 0.3f)
            {
                diff = destb - boy_pos.position;
                diff.Normalize();

                boy_pos.transform.position += diff * 0.4f;
            }
            else
            {
                enabled = false;
                GetComponent<ScenarioController>().currentAction++;
            }
                

        }
    }

    IEnumerator IsJumpingFast(float waitTime)
    {
        while (true)
        {
            if (tmp > 7)
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
