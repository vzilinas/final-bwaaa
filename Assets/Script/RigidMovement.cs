using UnityEngine;

public class RigidMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public AudioSource audio;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector3(moveHorizontal * 150, moveVertical * 150, 0);
        if(rigidbody.velocity.x == 0 && rigidbody.velocity.y == 0)
        {
            audio.FadeOut(2f);
        }
        else
        {
            audio.volume = 1f;
            audio.mute = false;
        }
    }
}