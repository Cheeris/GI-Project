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
    private Navigation aiNav;
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

        // turn on the navigation script
        aiNav = GetComponent<Navigation>();
        aiNav.enabled = false;

        // get the player object
        player = GameObject.FindGameObjectWithTag(targetTag).transform;

        attackCounter = attackTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = player.position;
        float distance = Vector3.Distance(targetPos, transform.position);
        //Debug.Log("Distance: " + distance);
        //Debug.Log("Timer: " + timer);
        //Debug.Log("IsAINav: " + aiNav.enabled);

        // Keep patrolling when it doesn't see the target
        if (isPatrolling && distance > patrolDistance)
        {
            timer -= Time.deltaTime;
            //Debug.Log("Timer: " + timer);

            if (timer <= 0)
            {
                ChangeDirection();
            }
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }

        // find the player and start chasing it
        if (isPatrolling && distance <= patrolDistance)
        {
            isPatrolling = false;
            aiNav.enabled = true;
        }

        // lose the target and begin patrolling again
        if (!isPatrolling && distance > patrolDistance)
        {
            isPatrolling = true;
            aiNav.enabled = false;
            //ChangeDirection();
        }

        // start attacking the target
        if (!isPatrolling && distance <= attackDistance)
        {
            attackCounter += Time.deltaTime;
            if (attackCounter > attackTime)
            {
                aiNav.enabled = false;  // turn off the ai navigation
                animator.SetTrigger("IsAttacking");  
                attackCounter = 0;
            } else
            {
                aiNav.enabled = false;
                animator.SetBool("IsWalkForwards", false);
            }
        }

        // keep chasing the target to attack
        if (!isPatrolling && distance > attackDistance && distance <= patrolDistance)
        {
            attackCounter = attackTime;  // attack when entering the min attack distance
            aiNav.enabled = true;
            animator.SetBool("IsWalkForwards", true);
        }
    }

    private void ChangeDirection()
    {
        float newX = Random.Range(0, 10);
        float newZ = Random.Range(0, 10);
        Vector3 newDir = new Vector3(newX, 0, newZ);
        transform.rotation = Quaternion.LookRotation(newDir);

        timer = timeToChangeDirection;

        Debug.Log("Changed Direction");
    }
}
