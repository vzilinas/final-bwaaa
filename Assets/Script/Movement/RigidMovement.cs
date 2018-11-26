using UnityEngine;

public class RigidMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public AudioSource audioSrc;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        rigidBody.velocity = new Vector3(moveHorizontal * 150, moveVertical * 150, 0);
        if(rigidBody.velocity.x == 0 && rigidBody.velocity.y == 0)
        {
            audioSrc.FadeOut(2f);
        }
        else
        {
            audioSrc.volume = 1f;
            audioSrc.mute = false;
        }
    }
}