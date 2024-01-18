using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 50;
    private int currentHealth;

     BaseEnemy enemy; //TODO: Remove circular dependency later
     HitTarget hitTarget; //TODO: Remove circular dependency later

    private void Awake()
    {
        enemy = gameObject.GetComponent<BaseEnemy>();
        hitTarget = gameObject.GetComponent<HitTarget>();
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(0, currentHealth);

        if (currentHealth == 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    private void Die()
    {
        enemy.DisableColliderPhysics();//TODO: Remove circular dependency late
        hitTarget.GainDestroyScore(); //TODO: Remove circular dependency late

        enemy.Destroy(); //TODO: Remove circular dependency late
        
        Destroy(gameObject,1f);
    }
}

