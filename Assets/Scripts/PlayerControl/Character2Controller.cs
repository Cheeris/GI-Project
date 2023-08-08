using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2Controller : MonoBehaviour
{
    public float speed;
    public bool isControlled;
    public bool isSaved;

    // Start is called before the first frame update
    void Start()
    {
        isSaved = false;
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //get the movement direction
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        if (dir != Vector3.zero && isControlled && isSaved)
        {
            //change the rotation of the character

            transform.rotation = Quaternion.LookRotation(dir);
            //move forwards with speed(can be modified)
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        //Change to another character
        if (Input.GetKeyDown("q"))
        {
            if (!isControlled && GetComponent<Character2Controller>().isSaved)
            {
                isControlled = true;
            }
            else
            {
                isControlled = false;
            }

        }



        //AI control the character
        if (!isControlled)
        {

        }


    }
}
