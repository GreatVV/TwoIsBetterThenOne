using System;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class GlobalStateContext
{
    public GameObject BulletPrefab;
    public Unit UnitPrefab;
    public Cinemachine.CinemachineVirtualCamera VirtualCamera;
    public PlayerConfig Player1Config;
}