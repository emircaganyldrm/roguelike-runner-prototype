using UnityEngine;
using UnityEngine.UI;

public class levelBar : MonoBehaviour
{
    public levelManager _levelManager;
    private Slider slider;
    
    private void Start() {
        slider = GetComponent<Slider>();
    }
    public void UpdateBar()
    {
        slider.maxValue = _levelManager.xpToLevelUp;
        slider.value = _levelManager.xp;
    }
}
