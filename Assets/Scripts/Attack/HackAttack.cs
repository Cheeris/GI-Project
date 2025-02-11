using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackAttack : MonoBehaviour
{
    private GameObject character2;
    private AlienController controller;
    private QTE QTESystem;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        character2 = GameObject.Find("Character2");
        controller = character2.GetComponent<AlienController>();
        QTESystem = GameObject.Find("Canvas").GetComponent<QTE>();
        transform.position = character2.transform.position + new Vector3(0,1,0);
        velocity = character2.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * 20 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            QTESystem.enabled = true;
            Debug.Log(other.name);
            QTESystem.setHitEnemy(other.gameObject);
            // Make the enemy cannot move 
            Destroy(gameObject);
        }
    }

    public void setVelocity(Vector3 velocity)
    {
        this.velocity = velocity;
    }
}
