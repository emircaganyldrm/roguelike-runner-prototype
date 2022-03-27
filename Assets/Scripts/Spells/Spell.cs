using System.Collections;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public Transform attackPoint;
    public EnemyFinder enemyFinder;
    public GameObject spellPrefab;


    #region Stat variables

    [Header("Stats")]
    public float attackForce = 2f;
    public float cooldown = 0.5f;
    public int spellCount = 1;
    public float attackDamage = 25;

    #endregion

    private void Start()
    {
        StartCoroutine(SpellEnum());
    }

    void LaunchSpell()
    {
        for (int i = 0; i < spellCount; i++)
        {
            if (enemyFinder.FindEnemy() == Vector3.zero) return;
            var spell = Instantiate(spellPrefab, attackPoint.position, Quaternion.identity);
            
            //Move spell to the enemy then damage
            //Assigning random attack force to show shot spell count clearly
            float RandomAttackForce = Random.Range(attackForce / 2f, attackForce * 2);
            spell.GetComponent<Rigidbody>().AddForce((enemyFinder.FindEnemy() - transform.position) * RandomAttackForce);
            spell.GetComponent<FireBall>().attackDamage = this.attackDamage;
        
        }
    }

    private IEnumerator SpellEnum()
    {
        while (true)
        {
            LaunchSpell();
            yield return new WaitForSeconds(cooldown);
        }
    }
}
