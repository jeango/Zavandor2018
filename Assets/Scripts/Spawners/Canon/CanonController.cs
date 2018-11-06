using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour {

    public float fireInterval;
    public Canon canon;
    private bool isShooting = false;
    private Coroutine fireCR;

    public void StartShooting()
    {
        StopShooting();
        isShooting = true;
        fireCR = StartCoroutine(FireCoroutine());
    }
    public void StopShooting()
    {
        isShooting = false;
        if (fireCR != null)
        {
            StopCoroutine(fireCR);
        }
    }

    private IEnumerator FireCoroutine()
    {
        while (isShooting)
        {
            canon.Fire();
            yield return new WaitForSeconds(fireInterval);
        }
    }

}
