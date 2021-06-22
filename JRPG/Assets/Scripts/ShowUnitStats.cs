using UnityEngine;
using UnityEngine.UI;

public abstract class ShowUnitStats : MonoBehaviour
{
    public GameObject unit;
    public Text text;

    void Update()
    {
        if (unit)
        {
            int newValue = NewStatValue();
            int maxValue = MaxStatValue();
            string statName = StatName();

            text.text = statName + newValue + " / " + maxValue;
        }
    }
    
    protected abstract int NewStatValue();
    protected abstract int MaxStatValue();
    protected abstract string StatName();

    public void ChangeUnit(GameObject newUnit)
    {
        unit = newUnit;
    }

}
