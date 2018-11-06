using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour {

    public GameObject projectile;

    public void Fire()
    {
        GameObject obj = Poolable.Instantiate(projectile, transform.position, transform.rotation);
        foreach (Transform item in obj.GetComponentsInChildren<Transform>())
        {
            item.gameObject.layer = gameObject.layer;
        }

    }
}
