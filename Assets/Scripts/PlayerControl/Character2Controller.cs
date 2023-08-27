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

    // Start is called before the first frame update
    void Start()
    {
        isSaved = false;
        isInQTE = false;
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //get the movement direction
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        if (dir != Vector3.zero && isControlled && isSaved && !isInQTE)
        {
            //change the rotation of the character

            transform.rotation = Quaternion.LookRotation(dir);
            //move forwards with speed(can be modified)
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKeyDown(KeyCode.K) && isControlled)
        {
            Instantiate(HackAttackProjectile);
        }

    }

    public void setIsInQTE(bool x)
    {
        isInQTE = x;
    }
}
