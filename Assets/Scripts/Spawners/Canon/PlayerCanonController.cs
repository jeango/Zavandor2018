using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanonController : CanonController {

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartShooting();
        }
        if (Input.GetButtonUp("Fire1") && !Input.GetButton("Fire1"))
        {
            StopShooting();
        }
    }
}
