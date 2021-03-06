using UnityEngine;

public class Enemy_Patrol : MonoBehaviour
{
    public GameObject EnenemyState;
    public GameObject[] GO;
    public float targetPosition;
    public bool localHiding;
    public float localSpeed;
    Rigidbody2D rb;

    int Enemy_Layer, Platform_Layer;
    int ObjectA;
    public AI3 localMethod;
    public SilenceMechanik SM;
    public bool done = true;

    public GameObject rayObject;
    public GameObject Point_One;
    RaycastHit2D Hit;
    RaycastHit2D hit;


    void Update()
    {
        hit = Physics2D.Linecast(rayObject.transform.position, Point_One.transform.position, 1 << LayerMask.NameToLayer("Wall"));

        RaycastCheck();

        Physics2D.IgnoreLayerCollision(Enemy_Layer, Platform_Layer, true);
        localHiding = EnenemyState.GetComponent<Hiding>().patrolState;

        if (localHiding)
        {
            if (Mathf.Round(targetPosition) > Mathf.Round(transform.position.x))
            {
                rb.velocity = new Vector3(localSpeed, 0, 0);
            }
            else if (Mathf.Round(targetPosition) < Mathf.Round(transform.position.x))
            {
                rb.velocity = new Vector3(-localSpeed, 0, 0);
            }
            else if (Mathf.Round(targetPosition) == Mathf.Round(transform.position.x))
            {
                GetNextTarget();
            }
        }
    }
    public void RaycastCheck()
    {

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Wall") && localHiding)
            {
                GetNextTarget();

                Debug.Log(hit.point + "Ne Rabotaet");
            }
        }
    }

    private void Start()
    {
        Enemy_Layer = LayerMask.NameToLayer("Enemy");
        Platform_Layer = LayerMask.NameToLayer("Platforms");
        rb = GetComponent<Rigidbody2D>();
        localMethod = GetComponent<AI3>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (done)
            CheckTag(collision);
    }
    private void OnTriggerExit2D(Collider2D collision) => done = true;

    private void CheckTag(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interaction")
        {
            SM.enemyClose = true;
            done = false;
        }
        else
            SM.enemyClose = false;
    }



    public void GetNextTarget()
    {
        ObjectA = Random.Range(0, 4);

        switch (ObjectA)
        {
            case 0:
                targetPosition = GO[0].transform.position.x;
                break;
            case 1:
                targetPosition = GO[1].transform.position.x;
                break;
            case 2:
                targetPosition = GO[2].transform.position.x;
                break;
            case 3:
                targetPosition = GO[3].transform.position.x;
                break;
            default:
                //Debug.Log("Nothing");
                break;
        }
    }
}
