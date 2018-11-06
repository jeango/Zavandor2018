using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICanonController : CanonController {

	public float minDelay;
    public float maxDelay;

    private void OnEnable()
    {
        Invoke("StartShooting", Random.Range(minDelay, maxDelay));
    }

    private void OnDisable()
    {
        CancelInvoke();
        StopShooting();
    }
}
