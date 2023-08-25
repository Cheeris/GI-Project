using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float attackRange;
    [SerializeField] private float knockbackForce;
    [SerializeField] private String targetTag;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            attack();
            animator.SetTrigger("IsAttacking");
        }
    }

    //Call attack during attack animation
    public void attack()
    {
        //Calculate the attack box
        Vector3 boxSize = new Vector3(attackRange * 2, 2.0f, 1.5f); 

        //Calculate the box position
        Vector3 boxPosition = transform.position + transform.forward * attackRange+ transform.up;

        //Get all the enemies in the attack box
        Collider[] hitEnemies = Physics.OverlapBox(boxPosition, boxSize / 2, Quaternion.identity);
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
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 boxSize = new Vector3(attackRange * 2, 2.0f, 1.5f); 
        Vector3 boxPosition = transform.position + transform.forward * attackRange + transform.up;
        Gizmos.DrawWireCube(boxPosition, boxSize);
    }
}
