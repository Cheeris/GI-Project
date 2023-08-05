using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    private GameObject currCharacter;
    // Start is called before the first frame update
    void Start()
    {
        currCharacter = character1;
    }

    // Update is called once per frame
    void Update()
    {
        //Let the camera's position fixed
        transform.position = new Vector3(currCharacter.transform.position.x, currCharacter.transform.position.y + 15, currCharacter.transform.position.z -10);
        transform.rotation = Quaternion.Euler(new Vector3(45, 0, 0));
        //Let the camera look at the character
        transform.LookAt(currCharacter.transform.position);
        if (Input.GetKeyDown("q"))
        {
            if (currCharacter == character1)
            {
                currCharacter = character2;
            } else
            {
                currCharacter = character1;
            }
        }
    }
}
