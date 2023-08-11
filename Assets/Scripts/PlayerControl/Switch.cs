using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject c1;
    public GameObject c2;
    private Character1Controller c1Control;
    private Character2Controller c2Control;
    public Camera mainCamera;
    private CameraPosition cameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        c1Control = c1.GetComponent<Character1Controller>();
        c2Control = c2.GetComponent<Character2Controller>();
        cameraPosition = mainCamera.GetComponent<CameraPosition>();
    }

    // Update is called once per frame
    void Update()
    {
        //Change to another character
        if (Input.GetKeyDown("q"))
        {
            if (c2Control.isSaved && !c2Control.isInQTE)
            {
                if (c1Control.isControlled && !c2Control.isControlled)
                {
                    c1Control.isControlled = false;
                    c2Control.isControlled = true;
                    cameraPosition.currCharacter = c2;
                } else if (!c1Control.isControlled && c2Control.isControlled)
                {
                    c1Control.isControlled = true;
                    c2Control.isControlled = false;
                    cameraPosition.currCharacter = c1;
                }
            }
        }
    }
}
