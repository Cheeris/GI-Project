using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool isControlled;

    private Animator animator;
    private MeleeAttack meleeAttack;
    // Start is called before the first frame update
    void Start()
    {
        meleeAttack = GetComponent<MeleeAttack>();
        animator = GetComponent<Animator>();
        animator.SetBool("IsIdle", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("IsIdle") == false)
        {
            Debug.Log(gameObject.name + " is IDLE!");
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //get the movement direction
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        if (isControlled)
        {
            if (!meleeAttack.isAttackable())
            {
                meleeAttack.setAttackable(true);
            }
            
            if (dir != Vector3.zero)
            {
                //change the rotation of the character

                transform.rotation = Quaternion.LookRotation(dir);
                //move forwards with speed(can be modified)
                transform.Translate(Vector3.forward * Time.deltaTime * speed);

                // play the animation of walking forwards
                animator.SetBool("IsWalkForwards", true);

            }
            else
            {
                // play the animation of idle
                animator.SetBool("IsWalkForwards", false);
            }
        } else
        {
            if (meleeAttack.isAttackable())
            {
                meleeAttack.setAttackable(false);
            }
        }

        
    }


    private void OnTriggerStay(Collider other)
    {
        Tool tool = other.gameObject.GetComponent<Tool>();
        //Debug.Log("IN character 1");
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Pickup");
            tool.applyEffect(this.gameObject);
            Destroy(other.gameObject);
        }
    }

}
