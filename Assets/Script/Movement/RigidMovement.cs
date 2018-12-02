using UnityEngine;

public class RigidMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public AudioSource audioSrc;
    public float movementSpeed = 150;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(BuffManager.playerMovementDebuff)
        {
            movementSpeed = movementSpeed * 0.75f;
            BuffManager.debuffCounter += 1;
            BuffManager.playerMovementDebuff = false;
        }
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        rigidBody.velocity = new Vector3(moveHorizontal * movementSpeed, moveVertical * movementSpeed, 0);
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