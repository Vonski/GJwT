using UnityEngine;
using System.Collections;

public class Kids_one : MonoBehaviour {
    public Transform player;
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
            player.position += Vector3.up * 0.2f;
            tmp++;
        }
        if (Input.GetKeyUp(KeyCode.Space))
            player.position += Vector3.down * 0.2f;
    }

    IEnumerator IsJumpingFast(float waitTime)
    {
        while (true)
        {
            if (tmp > 1)
            {
                GetComponent<Waski>().currentAction++;
                StopCoroutine(IsJumpingFast(0f));
            }
            tmp = 0;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
