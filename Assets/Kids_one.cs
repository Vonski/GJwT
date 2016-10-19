using UnityEngine;
using System.Collections;

public class Kids_one : MonoBehaviour {
    public Transform p1;
    int tmp;

    // Use this for initialization
    void Start () {
        tmp = 0;
        StartCoroutine(IsJumpingFast(1f));
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            p1.position += Vector3.up * 0.4f;
            tmp++;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            p1.position += Vector3.down * 0.4f;
        }
    }

    IEnumerator IsJumpingFast(float waitTime)
    {
        while (true)
        {
            if (tmp > 7)
            {
                GetComponent<Waski>().currentAction++;
                p1.position += Vector3.right * 32f;
                p1.GetChild(0).position -= Vector3.right * 5f;
                p1.GetChild(1).position -= Vector3.right * 8f;
                StopCoroutine(IsJumpingFast(0f));
            }
            tmp = 0;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
