using System.Collections;
using UnityEngine;

public class EnemySpell : MonoBehaviour
{
    public Transform attackPoint;
    public float cooldown;
    public GameObject spellPrefab;

    private void Start() {
        StartCoroutine(ShootEnum());
    }

    IEnumerator ShootEnum(){
        while (true)
        {
            GameObject spell = Instantiate(spellPrefab, attackPoint.position, Quaternion.identity);
            spell.GetComponent<Rigidbody>().AddForce(attackPoint.forward * 400f);
            yield return new WaitForSeconds(cooldown);
        }
    }
}