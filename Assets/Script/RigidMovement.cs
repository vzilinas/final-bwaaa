using UnityEngine;

public class RigidMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Animator animator;
    public RuntimeAnimatorController frontController;
    public RuntimeAnimatorController backController;
    public RuntimeAnimatorController rightController;
    public RuntimeAnimatorController leftController;
    public AudioSource audio;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveHorizontal < 0)
        {
            animator.runtimeAnimatorController = leftController;
        }
        if (moveHorizontal > 0)
        {
            animator.runtimeAnimatorController = rightController;
        }
        if (moveHorizontal == 0)
        {
            if (moveVertical < 0)
            {
                animator.runtimeAnimatorController = frontController;
            }
            if (moveVertical > 0)
            {
                animator.runtimeAnimatorController = backController;
            }
        }
        rigidbody.velocity = new Vector3(moveHorizontal * 150, moveVertical * 150, 0);
        if(rigidbody.velocity.x == 0 && rigidbody.velocity.y == 0)
        {
            animator.StartPlayback();
            audio.FadeOut(2f);
        }
        else
        {
            animator.StopPlayback();
            audio.volume = 1f;
            audio.mute = false;
        }
    }
}