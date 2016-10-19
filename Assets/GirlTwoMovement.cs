using UnityEngine;
using System.Collections;

public class GirlTwoMovement : MonoBehaviour {

    private Vector2 GirlStartPosition;
    private bool GirlStable = true;
    private bool GirlCaught = false;
    private bool Started = false;

    public Transform LassoRoot;
    public Transform GameController;

    // Use this for initialization
    void Start () {
        enabled = false;
    }

    public void OnActionStart()
    {
        if (!Started)
        {
            Started = true;
            GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Lasso"),
                transform.position + new Vector3(-1.0f, -4.0f, 0),
                new Quaternion(0f, 0f, 0f, 0f));
            LassoRoot = spawned.transform;
            GirlStartPosition = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
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
                GameController.GetComponent<Nietup>().currentAction++;
                CleanUp();
            }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!GirlCaught && coll.gameObject.name == "Lasso")
            GetCaught();
    }

    public void GetCaught()
    {
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
