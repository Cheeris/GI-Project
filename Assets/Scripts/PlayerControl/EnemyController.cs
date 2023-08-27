using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float attackTime = 1;
    [SerializeField] private String targetTag = "Player";
    [SerializeField] private float attackDistance = 2;

    // private NavMeshAgent agent;
    private Animator animator;
    private Navigation aiNav;
    private float attackCounter = 0;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        // agent = getcomponent<navmeshagent>();
        animator = GetComponent<Animator>();
        animator.SetBool("IsWalkForwards", true);

        // turn on the navigation script
        aiNav = GetComponent<Navigation>();
        aiNav.enabled = true;

        // get the player object
        player = GameObject.FindGameObjectWithTag(targetTag).transform;

        attackCounter = attackTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = player.position;
        float distance = Vector3.Distance(targetPos, transform.position);
        if (distance <= attackDistance)
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
        } else
        {
            attackCounter = attackTime;  // attack when entering the min attack distance
            aiNav.enabled = true;
            animator.SetBool("IsWalkForwards", true);
        }
    }
}
