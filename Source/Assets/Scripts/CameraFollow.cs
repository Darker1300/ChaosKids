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
        float zRot = target.rotation.eulerAngles.z;
        if (lockZRotation) transform.rotation =  Quaternion.AngleAxis(zRot, -Vector3.forward);
        if (lockPosition) transform.position = target.position + lockPositionOffset;
    }
}
