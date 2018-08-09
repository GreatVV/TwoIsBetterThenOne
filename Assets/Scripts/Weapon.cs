using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform SpawnBulletTrasnform;

    public Vector3 Direction => transform.forward;
    public Vector3 SpawnBulletPosition => SpawnBulletTrasnform.position;
}