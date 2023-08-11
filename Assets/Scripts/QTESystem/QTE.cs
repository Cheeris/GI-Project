using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor.UI;
using System.Threading;

public class QTE : MonoBehaviour
{
    public float limitedTime;
    public GameObject character2;
    private List<KeyCode> QTEOrder = new List<KeyCode>();
    private KeyCode[] keys = { KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.D };
    private System.Random rd = new System.Random();
    private State state;
    private float timer;
    private Character2Controller controller;
    
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > limitedTime)
        {
            state = State.fail;
        }
        //if QTE does not end, keep checking the key pressed is correct
        if (state == State.inProgress)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (QTEOrder[0] == KeyCode.A)
                {
                    QTEOrder.RemoveAt(0);
                    Debug.Log("Correct, " + QTEOrder);
                }
                else
                {
                    state = State.fail;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (QTEOrder[0] == KeyCode.S)
                {
                    QTEOrder.RemoveAt(0);
                    Debug.Log("Correct, " + QTEOrder);
                }
                else
                {
                    state = State.fail;
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (QTEOrder[0] == KeyCode.D)
                {
                    QTEOrder.RemoveAt(0);
                    Debug.Log("Correct, " + QTEOrder);
                }
                else
                {
                    state = State.fail;
                }
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                if (QTEOrder[0] == KeyCode.W)
                {
                    QTEOrder.RemoveAt(0);
                    Debug.Log("Correct, " + QTEOrder);
                }
                else
                {
                    
                    state = State.fail;
                }
            }
            else if (QTEOrder.Count == 0)
            {
                state = State.successful;
            }
        } 
        //If QTE is successful, do damage to the enemy or make enemy attack other enemies
        else if (state == State.successful)
        {
            //TODO: Cause damage to the enemy or make the enemy attack other enemies
            Debug.Log("Successful");
            controller.setIsInQTE(false);
            enabled = false;
        } 
        //If QTE fails, cause damage to character 2 and end the QTE
        else if (state == State.fail)
        {
            //TODO: Cause damage to character 2
            Debug.Log("Fail");
            controller.setIsInQTE(false);
            enabled = false;
        }

    }

    private void OnEnable()
    {
        timer = 0;
        controller = character2.GetComponent<Character2Controller>();
        controller.setIsInQTE(true);
        state = State.inProgress;
        QTEOrder.Clear();
        for (int i = 0; i < 5; i++)
        {
            int rdNumber = rd.Next(0, 4);
            QTEOrder.Add(keys[rdNumber]);
            Debug.Log(keys[rdNumber]);
        }
    }

    private enum State
    {
        successful,
        fail,
        inProgress
    }
}
