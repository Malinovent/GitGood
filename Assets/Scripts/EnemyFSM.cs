using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    private EnemyState currentState = EnemyState.IDLE;

    [SerializeField] private Transform player;

    [Header("Patrol Parameters")]
    [SerializeField] private float patrolRadius;
    [SerializeField] private float patrolSpeed;
    private Vector2 initialPosition;

    [Header("Chase Parameters")]
    [SerializeField] private float chaseRadius;
    [SerializeField] private float chaseSpeed;

    [Header("Attack Parameters")]
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackSpeed;

    private void Awake()
    {
        initialPosition = this.transform.position;
    }


    public void Update()
    { 
        switch(currentState)
        {
            case EnemyState.IDLE:
                Idle();
                break;

            case EnemyState.PATROL:
                Patrol();
                break;

            case EnemyState.CHASE:
                Chase();
                break;

            case EnemyState.ATTACK:
                Attack();
                break;
        }
    }

    private void Idle()
    {
        //Action


        //Transition
        float distance = Vector2.Distance(this.transform.position, player.position);

        if(distance < chaseRadius)
        {
            currentState = EnemyState.CHASE;
        }
    }

    private void Patrol()
    {
        //Action
        this.transform.position = Vector2.MoveTowards(
            this.transform.position, initialPosition, patrolSpeed * Time.deltaTime);

        //Transition
        float dist = Vector2.Distance(this.transform.position, initialPosition);

        if(dist <= 0.1f)
        {
            this.transform.position = initialPosition;
            currentState = EnemyState.IDLE;
        }
    }

    private void Chase()
    {
        //Action
        this.transform.position = GetNextDestination(chaseSpeed);

        //Transition
        float distance = Vector2.Distance(this.transform.position, player.position);

        if (distance < attackRadius)
        {
            currentState = EnemyState.ATTACK;
        }

        if (distance > patrolRadius)
        {
            currentState = EnemyState.PATROL;
        }
    }

    private Vector2 GetNextDestination(float speed)
    {
        return Vector2.MoveTowards(this.transform.position, player.position, Time.deltaTime * speed);
    }

    private void Attack()
    {
        //Action
        this.transform.position = GetNextDestination(attackSpeed);

        //Transition
        float distance = Vector2.Distance(this.transform.position, player.position);

        if (distance > attackRadius)
        {
            currentState = EnemyState.CHASE;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, patrolRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, chaseRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRadius);
    }


}


public enum EnemyState
{
    IDLE,
    PATROL,
    CHASE,
    ATTACK
}
