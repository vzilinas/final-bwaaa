using UnityEngine;

public class PlayerFollowingMovement : MonoBehaviour
{
    public int movementSpeed = 20;
    private Transform playerTransform;
    private Transform myTransform;
    private Rigidbody2D myRigid;
    void Awake()
    {
        myTransform = transform; //cache transform data for easy access/preformance
    }

    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (playerTransform)
        {
            myTransform.position +=
                (playerTransform.position - myTransform.position).normalized * movementSpeed * Time.deltaTime;
        }

        myRigid.velocity = Vector3.zero;
    }
}
