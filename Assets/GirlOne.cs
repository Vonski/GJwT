using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GirlOne : MonoBehaviour
{

    private List<GameObject> Missiles = new List<GameObject>();

    public Transform Girl;

    // Use this for initialization
    void Start()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) &&
            Vector2.Distance(Girl.position, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition)) > 2)
        {
            GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Missile"), (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), new Quaternion(0f, 0f, 0f, 0f));
            spawned.gameObject.name = "Missile";
            Missiles.Add(spawned);
            spawned.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 9.0f);
        }
    }

    void OnDisable()
    {
        foreach (GameObject Missile in Missiles)
        {
            Destroy(Missile);
        }
    }
}
