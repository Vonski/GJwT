﻿using UnityEngine;
using System.Collections;

public class Kids_three : MonoBehaviour {

    public Transform p1,controller;
    public Transform boy, girl;
    public float offset;
    private float startTime;

	// Use this for initialization
	void Start ()
    {
        girl = p1.GetChild(1).GetChild(0);
        boy = p1.GetChild(0).GetChild(0);
        StartCoroutine(RespawnBurger(1f));
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        girl = p1.GetChild(1).GetChild(0);
        boy = p1.GetChild(0).GetChild(0);
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Vector3.back*10 - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z-30f);

        if (Input.GetMouseButton(0))
        {
            int tmp = (int)Random.Range(0f,100f);
            GameObject spawned;
            if (tmp<33)
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Missile/Apple"), transform.position + diff * 8f * transform.localScale.x + Vector3.Cross(diff,Vector3.back)*1.8f* transform.localScale.x, new Quaternion(0f, 0f, 0f, 0f));
            else if(tmp < 66)
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Missile/Carrot"), transform.position + diff * 8f * transform.localScale.x + Vector3.Cross(diff, Vector3.back) * 1.8f * transform.localScale.x, new Quaternion(0f, 0f, 0f, 0f));
            else
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Missile/Brokul"), transform.position + diff * 8f * transform.localScale.x + Vector3.Cross(diff, Vector3.back) * 1.8f * transform.localScale.x, new Quaternion(0f, 0f, 0f, 0f));
            if(Random.Range(0f, 100f)<50f)
                spawned.GetComponent<RotateMissile>().rot_speed = Random.Range(2f, 20f);
            else
                spawned.GetComponent<RotateMissile>().rot_speed = Random.Range(2f, 10f)*(-1);
            spawned.transform.localScale = transform.localScale/3f;
            spawned.GetComponent<Rigidbody2D>().gravityScale = 0f;
            spawned.GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(diff * 1000000f,10f);
        }

        if (startTime + offset < Time.time)
        {
            StopAllCoroutines();
            if(GameObject.FindGameObjectsWithTag("Enemy_missile").Length==0)
            {
                controller.GetComponent<ScenarioController>().currentAction++;
            }
        }
    }

    IEnumerator RespawnBurger(float waitTime)
    {
        while (true)
        {
            int tmp = (int)Random.Range(0f, 100f);
            GameObject spawned;
            if (tmp < 33)
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Missile/Pizza"), new Vector3(transform.position.x, Random.Range(-3f, 6f)), new Quaternion(0f, 0f, 0f, 0f));
            else if (tmp < 66)
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Missile/Fryty"), new Vector3(transform.position.x, Random.Range(-3f, 6f)), new Quaternion(0f, 0f, 0f, 0f));
            else
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Missile/Burger-01"), new Vector3(transform.position.x, Random.Range(-3f, 6f)), new Quaternion(0f, 0f, 0f, 0f));
            spawned.GetComponent<Rigidbody2D>().gravityScale = 0f;
            spawned.transform.localScale = transform.localScale / 3f;
            if (Random.Range(0f, 100f) < 50f)
                spawned.GetComponent<RotateMissile>().rot_speed = Random.Range(2f, 10f);
            else
                spawned.GetComponent<RotateMissile>().rot_speed = Random.Range(2f, 10f) * (-1);

            Vector3 diff;
            if (Random.Range(0f,100f)<50f)
                diff = boy.transform.position - spawned.transform.position + Vector3.up;
            else
                diff = girl.transform.position - spawned.transform.position + Vector3.up;
            diff.Normalize();
            
            spawned.GetComponent<Rigidbody2D>().velocity = diff * 4f;

            yield return new WaitForSeconds(waitTime);
        }
    }
}
