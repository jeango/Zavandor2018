using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public int damage;

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject obj;
        Rigidbody2D rb = col.attachedRigidbody;
        if (!rb)
            obj = col.gameObject;
        else
            obj = rb.gameObject;
        Health health = obj.GetComponent<Health>();
        if (health)
        {
            health.TakeDamage(damage);
        }
    }
}
