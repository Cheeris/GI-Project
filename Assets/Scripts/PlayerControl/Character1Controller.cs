using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1Controller : MonoBehaviour
{
    public float speed;
    public bool isControlled;
    public GameObject character2;
    private Animator animator;
 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //get the movement direction
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        if (dir != Vector3.zero && isControlled)
        {
            //change the rotation of the character

            transform.rotation = Quaternion.LookRotation(dir);
            //move forwards with speed(can be modified)
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            // play the animation of walking forwards
            animator.SetBool("IsWalkForwards", true);
            
        } else
        {
            // play the animation of idle
            animator.SetBool("IsWalkForwards", false);
        }

        //AI control the character
        if (!isControlled)
        {

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
