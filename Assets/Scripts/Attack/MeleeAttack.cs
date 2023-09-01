using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float attackX;
    [SerializeField] private float attackY;
    [SerializeField] private float attackZ;
    [SerializeField] private float knockbackForce;
    [SerializeField] private float coolDownTime = 1.0f;
    [SerializeField] private String targetTag;

    private Animator animator;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        // check if the target is enemy so that we can control the character
        if (targetTag.Equals("Enemy") && Input.GetKeyDown(KeyCode.J) && timer <= 0)
        {
            attack();
            animator.SetTrigger("IsAttacking");
            timer = coolDownTime;
        }
    }

    //Call attack during attack animation
    public void attack()
    {
        //Calculate the attack box
        Vector3 boxSize = new Vector3(attackX, attackY, attackZ); 

        //Calculate the box position
        Vector3 boxPosition = transform.position + transform.forward * attackZ/2.5f+ transform.up;

        //Get all the enemies in the attack box
        Collider[] hitEnemies = Physics.OverlapBox(boxPosition, boxSize, Quaternion.identity);
        foreach (Collider enemy in hitEnemies)
        {
            
            if (enemy.CompareTag(targetTag) && enemy.gameObject != gameObject)
            {
                
                Debug.Log(gameObject.name+" Attack " + enemy.name);
                
                //calculate the knock back direction
                Vector3 knockbackDir = (enemy.transform.position - transform.position).normalized;

                //Imply a knock back force to the enemy
                enemy.GetComponent<Rigidbody>().AddForce(knockbackDir * knockbackForce);

                enemy.GetComponent<HealthManager>().TakeDamage(gameObject.GetComponent<AttackManager>().getDamage());

                // set the knock back animation to the enemy
                enemy.GetComponent<Animator>().SetTrigger("IsAttacked");
                enemy.GetComponent<Animator>().SetBool("IsIdle", true);
                enemy.GetComponent<Animator>().SetBool("IsWalkForwards", false);
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 boxSize = new Vector3(attackX, attackY, attackZ); 
        Vector3 boxPosition = transform.position + transform.forward * attackZ / 2.5f + transform.up;
        Gizmos.DrawWireCube(boxPosition, boxSize);
    }
}
