using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class Upgrades : MonoBehaviour
{
    private Spell player;

    public TextMeshProUGUI upgradeText;
    enum UpgradesEnum
    {
        spell,
        damage,
        speed,
        force
    };

    private UpgradesEnum upgrades;


    //Assigning random upgrade to the cube in panel & switching text value in Start()
    private void Start()
    {
        upgrades = (UpgradesEnum)Random.Range(0, 4);
        switch (upgrades)
        {
            case UpgradesEnum.spell:
                upgradeText.text = "+1 Spell";
                break;
            case UpgradesEnum.damage:
                upgradeText.text = "+25 Attack Damage";
                break;
            case UpgradesEnum.speed:
                upgradeText.text = "+%25 Attack Speed";
                break;
            case UpgradesEnum.force:
                upgradeText.text = "+10 Attack Force";
                break;
        }
        player = GameObject.Find("Player").GetComponent<Spell>();

    }

    //Passing values to character on collision with cube
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (upgrades)
            {
                case UpgradesEnum.spell:
                    player.spellCount++;
                    break;
                case UpgradesEnum.damage:
                    player.attackDamage += 25;
                    break;
                case UpgradesEnum.speed:
                    player.cooldown -= player.cooldown/4;
                    break;
                case UpgradesEnum.force:
                    player.attackForce += 10;
                    break;
            }
        }
    }
}
