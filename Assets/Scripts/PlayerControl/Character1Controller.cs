using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1Controller : MonoBehaviour
{
    public float speed;
    public bool isControlled;
    public GameObject character2;
 
    // Start is called before the first frame update
    void Start()
    {
        
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
        }

        //AI control the character
        if (!isControlled)
        {

        }

        
    }
}
