using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Sleeping,
    Waking,
    Walking,
    Attacking,
    FallingAsleep,
}
public class Log : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public EnemyState enemyState;

    private Animator animator;

    // On Trigger entered, select target.

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyState = EnemyState.Sleeping;
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        switch (enemyState)
        {
            case EnemyState.Sleeping:
                if (Vector3.Distance(target.position, transform.position) <= chaseRadius)
                {
                    animator.SetBool("isAwake", true);
                    enemyState = EnemyState.Waking;
                }
                break;

            case EnemyState.Waking:
                break;

            case EnemyState.Walking:
                if (Vector3.Distance(target.position, transform.position) <= chaseRadius)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                }
                else
                {
                    enemyState = EnemyState.FallingAsleep;
                    animator.SetBool("isAwake", false);
                    break;
                }
                break;

            case EnemyState.Attacking:
                // Damage the player
                break;

            case EnemyState.FallingAsleep:
                break;
        }
    }

    private void ChangeEnemyState(string eventType)
    {
        Enum.TryParse(eventType, out enemyState);
    }
}
