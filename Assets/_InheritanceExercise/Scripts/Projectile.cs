using UnityEngine;

public class Projectile: MonoBehaviour
{
    public int damage = 1;
    public  Transform target;
    private float shotSpeed = 3.0f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, shotSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        GameObject collidedGameObject = other.gameObject;
        bool isPlayer = collidedGameObject.CompareTag("Player");
        bool hasHealth = collidedGameObject.TryGetComponent<Health>(out var health);

        if (isPlayer && hasHealth)
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}