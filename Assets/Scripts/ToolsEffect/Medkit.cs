using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : Tool
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void applyEffect(GameObject target)
    {
        Debug.Log("In Medkit: applyEffect");
    }

    private void OnTriggerEnter(Collider other)
    {
        // show UI notice
    }
}
