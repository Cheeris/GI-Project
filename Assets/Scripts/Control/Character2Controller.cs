using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2Controller : MonoBehaviour
{
    public float speed;
    public bool isControlled;
    public bool isSaved;
    public bool isInQTE;
    [SerializeField] private GameObject HackAttackProjectile;
    private MeleeAttack meleeAttack;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        meleeAttack = GetComponent<MeleeAttack>();
        isSaved = false;
        isInQTE = false;
        animator = GetComponent<Animator>();
        animator.SetBool("IsIdle", true);
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //get the movement direction
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        if (isControlled && isSaved)
        {
            if (!meleeAttack.isAttackable())
            {
                meleeAttack.setAttackable(true);
            }
            //TODO: Add cd to the hack attack
            if (Input.GetKeyDown(KeyCode.K))
            {
                Instantiate(HackAttackProjectile);
            }
            if (dir != Vector3.zero && !isInQTE)
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

    public void setIsInQTE(bool x)
    {
        isInQTE = x;
    }
}
