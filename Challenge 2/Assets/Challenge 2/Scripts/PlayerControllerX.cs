/*
* Chris Smith
* Challenge 2
* Allows player to spawn dogs
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool canShoot;
    public float shotTime;

    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            //initiate cooldown
            canShoot = false;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            StartCoroutine("Cooldown");
        }
    }

    //delays shots by shotTime
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(shotTime);
        canShoot = true;
    }
}
