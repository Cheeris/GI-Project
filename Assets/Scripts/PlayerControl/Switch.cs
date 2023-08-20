using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Switch : MonoBehaviour
{
    public GameObject c1;
    public GameObject c2;
    private Character1Controller c1Control;
    private Character2Controller c2Control;
    private NavMeshAgent c1NavAgent;
    private NavMeshAgent c2NavAgent;
    private Navigation c1NavScript;
    private Navigation c2NavScript;
    public Camera mainCamera;
    private CameraPosition cameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        c1Control = c1.GetComponent<Character1Controller>();
        c2Control = c2.GetComponent<Character2Controller>();
        c1NavAgent = c1.GetComponent<NavMeshAgent>();
        c2NavAgent = c2.GetComponent<NavMeshAgent>();
        c1NavScript = c1.GetComponent<Navigation>();
        c2NavScript = c2.GetComponent<Navigation>();
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
                    c1NavAgent.enabled = true;
                    c2NavAgent.enabled = false;
                    c1NavScript.enabled = true;
                    c2NavScript.enabled = false;
                    cameraPosition.currCharacter = c2;
                } else if (!c1Control.isControlled && c2Control.isControlled)
                {
                    c1Control.isControlled = true;
                    c2Control.isControlled = false;
                    c1NavAgent.enabled = false;
                    c2NavAgent.enabled = true;
                    c1NavScript.enabled = false;
                    c2NavScript.enabled = true;
                    cameraPosition.currCharacter = c1;
                }
            }
        }
    }
}
