using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    private GameObject currCharacter;
    private Vector3 distance;
    private Vector3 ve;
    // Start is called before the first frame update
    void Start()
    {
        currCharacter = character1;
        distance = new Vector3(0, 15, -10);
    }

    // Update is called once per frame
    void Update()
    {
        //Let the camera move smoothly
        transform.position = Vector3.SmoothDamp(transform.position, currCharacter.transform.position + distance, ref ve, 0.1f);
        transform.rotation = Quaternion.Euler(new Vector3(60, 0, 0));
        
        if (Input.GetKeyDown("q"))
        {
            if (currCharacter == character1 && character2.GetComponent<Character2Controller>().isSaved)
            {
                currCharacter = character2;
            } else
            {
                currCharacter = character1;
            }
        }
    }
}
