using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour {

    public GameObject projectile;
    public float fireInterval;
    
    private bool isShooting = false;
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            StartCoroutine(FireCoroutine());
        }
    }

    void Fire()
    {
        Transform obj = Instantiate(projectile, transform.position, transform.rotation).transform;
        obj.gameObject.layer = gameObject.layer;
        foreach (Transform item in obj)
        {
            item.gameObject.layer = gameObject.layer;
        }
    }

    private IEnumerator FireCoroutine()
    {
        isShooting = true;
        while (Input.GetButton("Fire1"))
        {
            Fire();
            yield return new WaitForSeconds(fireInterval);
        }
        isShooting = false;
    }
}
