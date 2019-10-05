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
                if (Vector2.Distance(target.position, transform.position) <= chaseRadius)
                {
                    animator.SetBool("isAwake", true);
                    enemyState = EnemyState.Waking;
                }
                break;

            case EnemyState.Waking:
                break;

            case EnemyState.Walking:
                if (Vector2.Distance(target.position, transform.position) <= chaseRadius)
                {
                    Vector3 movePoint = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                    Vector2 change = movePoint - transform.position;
                    transform.position = movePoint;

                    change.Normalize();
                    animator.SetFloat("moveX", change.x);
                    animator.SetFloat("moveY", change.y);

                    if(Vector2.Distance(target.position, transform.position) <= attackRadius)
                    {
                        // For better code this would damage the player
                        enemyState = EnemyState.Attacking;
                        animator.SetBool("isIdle", true);
                    }
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
                if (Vector2.Distance(target.position, transform.position) > attackRadius)
                {
                    animator.SetBool("isIdle", false);
                    enemyState = EnemyState.Walking;
                }
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
