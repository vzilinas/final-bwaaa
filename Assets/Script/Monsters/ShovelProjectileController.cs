using UnityEngine;

public class ShovelProjectileController : MonoBehaviour
{
    public float moveSpeed = 25f;
    private Rigidbody2D rb;
    private GameObject target;
    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 2f);
    }
}
