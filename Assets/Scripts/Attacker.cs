using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    float currentSpeed = 1f;
    GameObject currentTarget;


    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawn();
    }

    private void OnDestroy()
    {
        if(FindObjectOfType<LevelController>())
            FindObjectOfType<LevelController>().AttackerKilled();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget && GetComponent<Animator>().GetBool("isAttacking"))
            GetComponent<Animator>().SetBool("isAttacking", false);
    }

    public void setMovementSpeed(float speed) {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget){ return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
}
