using Unity.Mathematics;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject explosionPrefab;
    public bool isEnemySpell;
    public float attackDamage;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isEnemySpell && (other.gameObject.layer == LayerMask.NameToLayer("Enemy")))
        {
            other.gameObject.GetComponent<HealthSystem>().TakeDamage(attackDamage);
            other.gameObject.GetComponent<Animator>().SetTrigger("TakeDamage");
            var explosion = Instantiate(explosionPrefab, transform.position, quaternion.identity);
            Destroy(explosion, 2f);
            Destroy(gameObject);

        }else if (isEnemySpell && other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<levelManager>().DamageXP(attackDamage);
            Destroy(gameObject);
        }
    }
}
