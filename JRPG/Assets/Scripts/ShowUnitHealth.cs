public class ShowUnitHealth : ShowUnitStats
{
    protected override int NewStatValue()
    {
        return unit.GetComponent<UnitStats>().health;
    }

    protected override int MaxStatValue()
    {
        return unit.GetComponent<UnitStats>().maxHealth;
    }

    protected override string StatName()
    {
        return "HP  ";
    }
}
