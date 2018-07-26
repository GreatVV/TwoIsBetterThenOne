using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10;
    public float LifeTime = 5;

    void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    public void Update()
    {
        transform.position = transform.position + transform.forward * Speed * Time.deltaTime;
    }
}