using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float attackTime = 1;
    [SerializeField] private String targetTag = "Player";
    [SerializeField] private float attackDistance = 2;
    [SerializeField] private float patrolDistance = 5;
    [SerializeField] private float speed = 2;

    private float timeToChangeDirection = 5.0f;
    private Animator animator;
    private NavMeshAgent aiNav;
    private float attackCounter = 0;
    private Transform player;
    private bool isPatrolling = true;
    private float timer;
    

    // Start is called before the first frame update
    void Start()
    {
        // choose a random direction and start patrolling
        ChangeDirection();
        timer = timeToChangeDirection;
        Debug.Log("Timer: " + timer);

        // start walking
        animator = GetComponent<Animator>();
        animator.SetBool("IsWalkForwards", true);
        animator.SetBool("IsIdle", false);

        // turn on the navigation script
        aiNav = GetComponent<NavMeshAgent>();
        aiNav.isStopped = true;

        // get the player object
        player = GameObject.FindGameObjectWithTag(targetTag).transform;

        attackCounter = attackTime;
    }

    // Update is called once per frame
    void Update()
    {
        float distance;
        if (player != null)
        {
            Vector3 targetPos = player.position;
            distance = Vector3.Distance(targetPos, transform.position);
        } else
        {
            distance = Mathf.Infinity;
        }
        
        //Debug.Log("Distance: " + distance);
        //Debug.Log("Timer: " + timer);
        //Debug.Log("IsAINav: " + aiNav.enabled);

        // Keep patrolling when it doesn't see the target
        if (isPatrolling && distance > patrolDistance)
        {
            animator.SetBool("IsWalkForwards", true);
            timer -= Time.deltaTime;
            //Debug.Log("Timer: " + timer);

            if (timer <= 0)
            {
                ChangeDirection();
            }
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // find the player and start chasing it
        if (isPatrolling && distance <= patrolDistance)
        {
            isPatrolling = false;
            aiNav.isStopped = false;
        }

        // lose the target and begin patrolling again
        if (!isPatrolling && distance > patrolDistance)
        {
            isPatrolling = true;
            aiNav.isStopped = true;
            //ChangeDirection();
        }

        // start attacking the target
        if (!isPatrolling && distance <= attackDistance)
        {
            attackCounter += Time.deltaTime;
            animator.SetBool("IsIdle", true);
            aiNav.isStopped = true;  // turn off the ai navigation
            if (attackCounter > attackTime)
            {
                animator.SetTrigger("IsAttacking");
                GetComponent<MeleeAttack>().attack();
                attackCounter = 0;
            } else
            {
                // still in cooldown time 
                animator.SetBool("IsWalkForwards", false);
                //Debug.Log("In CD time");
            }
        }

        // keep chasing the target to attack
        if (!isPatrolling && distance > attackDistance && distance <= patrolDistance)
        {
            animator.SetBool("IsIdle", false);
            attackCounter = attackTime;  // attack when entering the min attack distance
            aiNav.isStopped = false;
            animator.SetBool("IsWalkForwards", true);
        }
    }

    private void ChangeDirection()
    {
        float newX = Random.Range(-10, 10);
        float newZ = Random.Range(-10, 10);
        Vector3 newDir = new Vector3(newX, 0, newZ);
        transform.rotation = Quaternion.LookRotation(newDir);

        timer = timeToChangeDirection;

        Debug.Log("Changed Direction");
    }
}
