using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour {

    public string targetTag;
    public int rotationSpeed;
    public Vector3 localForwardVector;

    private Transform target;

	// Use this for initialization
	void Start () {
        target = GameObject.FindWithTag(targetTag).transform;
	}

    private void Update()
    {
        RotateToTarget();
    }

    void RotateToTarget()
    {
        Vector3 directionToTarget = target.position - transform.position;
        Vector3 currentWorldDirection = transform.TransformDirection(localForwardVector);
        float angleToTarget = Vector3.Angle(currentWorldDirection, directionToTarget);
        float rotationAngle = Mathf.Min(angleToTarget, rotationSpeed * Time.deltaTime);
        Vector3 rotationAxis = Vector3.Cross(currentWorldDirection, directionToTarget);
        if (angleToTarget == 180f)
            rotationAxis = new Vector3(-currentWorldDirection.z, currentWorldDirection.y, currentWorldDirection.x);
        rotationAxis.Normalize();
        Debug.DrawRay(transform.position, directionToTarget, Color.blue);
        Debug.DrawRay(transform.position, currentWorldDirection, Color.yellow);
        Debug.DrawRay(transform.position, rotationAxis, Color.red);
        transform.Rotate(rotationAxis, rotationAngle, Space.World);
    }

}
