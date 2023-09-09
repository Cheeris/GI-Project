using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class SaveCharacter2 : MonoBehaviour
{
    [SerializeField] private GameObject shownTimer;
    private GameObject parent;
    private float timer;
    public GameObject character1;
    private LineRenderer lineRenderer;
    private int indices = 36;
    private float radius = 3.5f;
    private float lineWidth = 0.1f;
    private int saveTotalTime = 3;
    private Vector3 center;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        rb = parent.GetComponent<Rigidbody>();
        timer = 0;
        shownTimer.SetActive(false);

        center = transform.parent.position;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = indices + 1;
        lineRenderer.startWidth = lineRenderer.endWidth = lineWidth;
        CreateCircle(indices, radius);
    }

    // Update is called once per frame
    void Update()
    {
        //If character 1 is inside the circle for 3 seconds, character is saved (Can be controlled and switched)
        if (timer >= saveTotalTime)
        {
            parent.GetComponent<AlienController>().isSaved = true;
            parent.GetComponent<NavMeshAgent>().enabled = true;
            parent.GetComponent<Navigation>().enabled = true;
            rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
            rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
            shownTimer.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    //Time increase if character 1 is inside the circle
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == character1)
        {
            timer += Time.deltaTime;

            float leftTime = saveTotalTime - timer;
            //int minute = (int)(leftTime)
            //float second = leftTime % 60;
            shownTimer.SetActive(true);
            shownTimer.GetComponent<TMP_Text>().text = string.Format("{0:0.00}", leftTime);

            Debug.Log(timer);
        }
        
    }
    
    //Reset the timer if saving process is interrupted
    private void OnTriggerExit(Collider other)
    {
        timer = 0;
        shownTimer.SetActive(false);
    }

    //Draw a circle to indicate the save range of the character 2
    private void CreateCircle(int indices, float radius)
    {
        float x, z;
        float angle = 20f;

        for (int i = 0; i < indices + 1; i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius + center.x;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius + center.z;

            lineRenderer.SetPosition(i, new Vector3(x, 0, z));

            angle += (360f / indices);
        }
    }
}
