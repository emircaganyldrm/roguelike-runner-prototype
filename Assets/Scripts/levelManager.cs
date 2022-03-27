using UnityEngine;
using UnityEngine.Events;

public class levelManager : MonoBehaviour 
{
    public int level;
    public float xp;
    public float xpToLevelUp = 100;
    public UnityEvent OnLevelUp;
    public UnityEvent OnXpChanged;

    public void GiveXP(float amount)
    {
        xp += amount;
        OnXpChanged.Invoke();
        
        if (xp >= xpToLevelUp)
        {
            OnLevelUp.Invoke();
        }
    }

    public void DamageXP(float amount)
    {
        xp -= amount;
        if(xp <= 0) xp = 0;
        OnXpChanged.Invoke();

    }

    public void LevelUp()
    {
        level++;
        xpToLevelUp += 20;
        xp = 0;
        OnXpChanged.Invoke();
    }    
}