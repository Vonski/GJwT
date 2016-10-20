using UnityEngine;
using System.Collections;

public class GirlTwoMovement : MonoBehaviour {

    private Vector2 GirlStartPosition;
    private bool GirlStable = true;
    private bool GirlCaught = false;
    private bool Started = false;

    public Transform LassoRoot;
    public Transform GameController;
    public bool lerp = false;
    Vector3 dest;

    // Use this for initialization
    void Start () {
        enabled = false;
        GirlStartPosition = transform.position;
        dest = transform.parent.transform.position + new Vector3(0, -12.0f, 0);
    }

    public void OnActionStart()
    {
        if (!Started)
        {
            Started = true;
            GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Lasso"),
                transform.position + new Vector3(-1.0f, -5.5f, 0),
                new Quaternion(0f, 0f, 0f, 0f));
            LassoRoot = spawned.transform;
            GirlStartPosition = transform.position;
            dest = transform.parent.transform.position + new Vector3(0, -12.0f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!lerp)
        {
            if ((transform.position.x < GirlStartPosition.x - 2 ||
                transform.position.x > GirlStartPosition.x + 2 ||
                transform.position.y < GirlStartPosition.y - 2 ||
                transform.position.y > GirlStartPosition.y + 2) &&
                !GirlStable)
            {
                SpringJoint2D Stabilizer = gameObject.AddComponent<SpringJoint2D>();
                Stabilizer.connectedAnchor = new Vector2(transform.position.x, transform.position.y + 3.0f);
                GirlStable = true;
            }

            if (GirlCaught && GirlStable)
                if (GetComponent<Rigidbody2D>().velocity.magnitude < 0.5)
                {
                    lerp = true;
                    CleanUp();
                }
        }
    }

    void FixedUpdate()
    {
        if (lerp)
        {
            Vector3 diff = dest - transform.parent.transform.position;
            diff.Normalize();
            if (Vector3.Distance(transform.parent.transform.position, dest) > 0.3f)
            {
               
                transform.parent.transform.position += diff * 0.1f;
            }
            else
                GameController.GetComponent<ScenarioController>().currentAction++;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!GirlCaught && coll.gameObject.name == "Lasso")
            GetCaught();
    }

    public void GetCaught()
    {
        if (GirlCaught)
            return;

        GirlStable = false;
        GirlCaught = true;
        gameObject.AddComponent<Rigidbody2D>();
        SpringJoint2D Lasso = gameObject.AddComponent<SpringJoint2D>();
        Lasso.connectedAnchor = LassoRoot.position;
    }

    void CleanUp()
    {
        foreach(SpringJoint2D go in gameObject.GetComponents<SpringJoint2D>())
        {
            Destroy(go);
        }

        Destroy(gameObject.GetComponent<Rigidbody2D>());

        Destroy(LassoRoot.gameObject);
    }
}
