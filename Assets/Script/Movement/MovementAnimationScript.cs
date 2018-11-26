using System.Collections;
using UnityEngine;

public class MovementAnimationScript : MonoBehaviour {
    public Animator animator;
    public RuntimeAnimatorController frontController;
    public RuntimeAnimatorController backController;
    public RuntimeAnimatorController rightController;
    public RuntimeAnimatorController leftController;
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(HandleIt());
    }
    private IEnumerator HandleIt()
    {
        var prevPos = this.transform.position;
        yield return new WaitForSeconds(0.1f);
        var actualPos = this.transform.position;

        if (actualPos.x - prevPos.x < 0 && leftController != null)
        {
            animator.runtimeAnimatorController = leftController;
        }
        if (actualPos.x - prevPos.x > 0 && rightController != null)
        {
            animator.runtimeAnimatorController = rightController;
        }
        if (actualPos.x == prevPos.x || leftController == null || rightController == null)
        {
            if (actualPos.y - prevPos.y < 0)
            {
                animator.runtimeAnimatorController = frontController;
            }
            if (actualPos.y - prevPos.y > 0)
            {
                animator.runtimeAnimatorController = backController;
            }
        }
        if (actualPos.x == prevPos.x && actualPos.y == prevPos.y)
        {
            animator.StartPlayback();
        }
        else
        {
            animator.StopPlayback();
        }
    }

}
