using UnityEngine;

public class RigidMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(moveHorizontal * 200, moveVertical * 200, 0);
        //rb.velocity = new Vector3(0, moveVertical * 200, moveVertical * 200);

        //rb.velocity = new Vector3(0, moveVertical, 0);
        //rb.AddForce(movement * 150.0f);
        //rb.AddForce(movement2 * 150.0f);

    }
}