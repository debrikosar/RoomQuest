using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MovableObject
{
    public Vector3 objectPosition;
    public Vector3 objectRotation;

    public float objectRotationX;
    public float objectRotationY;
    public float objectRotationZ;
    public float objectRotationW;

    public MovableObject(Vector3 objectPosition, Quaternion objectRotation)
    {
        this.objectPosition = objectPosition;

        this.objectRotationX = objectRotation.x;
        this.objectRotationY = objectRotation.y;
        this.objectRotationZ = objectRotation.z;
        this.objectRotationW = objectRotation.w;
    }

}
