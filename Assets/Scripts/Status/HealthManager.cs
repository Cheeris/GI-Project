using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int health;

    private HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = gameObject.transform.Find("HealthBarCanvas").gameObject.transform.Find("HealthBar").gameObject.GetComponent<HealthBar>();
        healthbar.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int Damage)
    {
        health -= Damage;
        healthbar.SetHealth(health);
        //gameObject.transform.GetChild(2).gameObject.GetComponent<HealthBar>().SetHealth(health);
        //Debug.Log(gameObject.transform.FindChild("HealthBar").gameObject.name);
    }
}
