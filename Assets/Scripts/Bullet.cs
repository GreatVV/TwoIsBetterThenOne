using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float Speed = 10;
    public float LifeTime = 5;
    public float Damage = 20;

    private bool _isDead;

    void Start()
    {
        Destroy(gameObject, LifeTime);
        Rigidbody.AddForce(transform.forward * Speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        var unit = other.gameObject.GetComponent<Unit>();
        if (unit && !_isDead)
        {
            _isDead = true;
            var dealDamage = new DealDamage();
            dealDamage.Amount = Damage;
            dealDamage.UnitID = unit.UnitID;
            EventDispatcher.Instance.Enqueue(dealDamage);
            Destroy(gameObject);
        }
    }
}