using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MapLimit : ScriptableObject
{
    public int XminCameraDistance; public int XmaxCameraDistance;
    public int YminCameraDistance; public int YmaxCameraDistance;
}
