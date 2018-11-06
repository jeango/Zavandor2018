using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {

    public int maxHealth;
    public List<ObjectBehaviour> dieBehaviours;

    public UnityEvent OnDie; 

    private int currentHealth;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        OnDie.Invoke();
        foreach (var item in dieBehaviours)
        {
            item.Execute(gameObject);
        }
    }
}
