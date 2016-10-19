using UnityEngine;
using System.Collections;

public class AerobikController : MonoBehaviour {

    public Transform controller;
    private int[] table;
    public int[] table2;
    public int tmp;
    private bool isComingBack, isStartCoroutine;
    private float rot_z;

    // Use this for initialization
    void OnEnable () {
        table = new int[5];
        table2 = new int[5];
        isComingBack = false;
        tmp = 1;
        for (int i = 0; i < 5; i++)
        {
            table[i] = (int)Random.Range(0f, 100f) % 5 + 1;
            table2[i] = table[i]+0;
        }
        isStartCoroutine = true;
        StartCoroutine(BodyMoving(0.1f));
	}
	
	// Update is called once per frame
	void Update () {
        //controller.gameObject.SetActive(false);
    }

    IEnumerator BodyMoving(float waitTime)
    {
        if (isStartCoroutine)
        {
            controller.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            isStartCoroutine = false;
        }
            
        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                if (table[i] != 0)
                {
                    tmp = table[i];
                    break;
                }
                tmp = 0;
            }

            if (tmp == 0)
            {
                StopAllCoroutines();
                controller.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.5f);
            }

            if (tmp == 1 || tmp == 3)
                rot_z = 45f;
            else if (tmp == 2 || tmp == 4)
                rot_z = -45f;
            else if (tmp == 5)
            {
                if (isComingBack)
                {
                    Vector3 tmpVec = new Vector3(-0.03f, 0.09f, 0f);
                    transform.GetChild(tmp - 1).transform.position += tmpVec;
                    isComingBack = false;
                    for (int i = 0; i < 5; i++)
                        if (table[i] != 0)
                        {
                            table[i] = 0;
                            break;
                        }
                }
                else
                {
                    Vector3 tmpVec = new Vector3(-0.03f, 0.09f, 0f);
                    transform.GetChild(tmp - 1).transform.position -= tmpVec;
                    isComingBack = true;
                }
                yield return new WaitForSeconds(waitTime);
            }

            if(tmp!=5)
                if (isComingBack)
                {
                    transform.GetChild(tmp - 1).transform.Rotate(0f, 0f, transform.rotation.z + rot_z);
                    isComingBack = false;
                    for (int i = 0; i < 5; i++)
                        if (table[i] != 0)
                        {
                            table[i] = 0;
                            break;
                        }
                }
                else
                {
                    transform.GetChild(tmp - 1).transform.Rotate(0f, 0f, transform.rotation.z - rot_z);
                    isComingBack = true;
                }

            yield return new WaitForSeconds(waitTime);
        }
    }
}
