/*
* Chris Smith
* Prototype 2
* Manages entity cleanup and damage 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 20;
    public float bottomBound = -5;

    /*
     private HealthSystem healthSystemScript;

        void Start()
        {
            healthSystemScript = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
        }
     */

    // Update is called once per frame
    void Update()
    {
        //Food goes out of bounds
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }

        //Animal goes out of bounds
        if (transform.position.z < bottomBound)
        {
            //Debug.Log("Game Over!");
            //Get health system script and call TakeDamage()
            //healthSystemScript.TakeDamage();
            GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
