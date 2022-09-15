using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target = null;
    public bool lockZRotation = false;
    public bool lockPosition = false;
    public Vector3 lockPositionOffset = new Vector3(0f, 0f, 0f);

    void Update()
    {
        if (target == null) return;
        if (lockZRotation) transform.rotation = Quaternion.LookRotation(Vector3.forward, target.transform.up);
        if (lockPosition) transform.position = target.position + target.TransformVector(lockPositionOffset);
    }
}
