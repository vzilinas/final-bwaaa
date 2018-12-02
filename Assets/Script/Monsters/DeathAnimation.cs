using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    public GameObject spawnlingOnDeath;
    public GameObject objectLeftOnDeath;
    public Animator animator;
    public RuntimeAnimatorController deathAnimatorController;
    public bool isDead;
    public bool isDying = false;

    void Update()
    {
        if(!isDying && isDead)
        {
            isDead = false;
            StartCoroutine(HandleIt());
        }
        if(isDying && isDead)
        {
            LeaveCorpseOnGround();
            SpawnZombiesOnDeath();
            Destroy(gameObject);
        }
    }

    private IEnumerator HandleIt()
    {
        gameObject.GetComponent<MovementAnimationScript>().enabled = false;
        gameObject.GetComponent<RandomMovement>().moveSpeed = 0;

        animator.runtimeAnimatorController = deathAnimatorController;

        animator.StartPlayback();

        yield return new WaitForSeconds(2f);
        isDead = true;
        isDying = true;
    }
    void LeaveCorpseOnGround()
    {
        var deathPosition = new Vector3(
         gameObject.transform.position.x,
         gameObject.transform.position.y,
         0f);
        Instantiate(objectLeftOnDeath, deathPosition, new Quaternion(0f, 0f, 0f, 0f));
    }
    void SpawnZombiesOnDeath()
    {
        Vector3 spawnPosition1 =
            new Vector3(gameObject.transform.position.x - 5, gameObject.transform.position.y, 0f);
        Vector3 spawnPosition2 =
            new Vector3(gameObject.transform.position.x + 5, gameObject.transform.position.y, 0f);
        Instantiate(spawnlingOnDeath, spawnPosition2, new Quaternion(0f, 0f, 0f, 0f));
        Instantiate(spawnlingOnDeath, spawnPosition1, new Quaternion(0f, 0f, 0f, 0f));
    }
}
