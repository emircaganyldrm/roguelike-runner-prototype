using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [Header("Health Properties")]
    private float health = 100;
    public float maxHealth=100;

    public UnityEvent OnKilled;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Kill();
    }

    public void Heal(float amount)
    {
        health += amount;
    }

    public void Kill()
    {
        OnKilled.Invoke();
        Destroy(gameObject);
    }

    public void IncreaseMaxHealth(float amount)
    {
        maxHealth += amount;
    }
}
