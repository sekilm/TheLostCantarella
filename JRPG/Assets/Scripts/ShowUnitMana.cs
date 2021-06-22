public class ShowUnitMana : ShowUnitStats
{
    protected override int NewStatValue()
    {
        return unit.GetComponent<UnitStats>().mana;
    }
    
    protected override int MaxStatValue()
    {
        return unit.GetComponent<UnitStats>().maxMana;
    }
    
    protected override string StatName()
    {
        return "MP  ";
    }
}
