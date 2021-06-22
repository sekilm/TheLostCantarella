using System.Collections.Generic;

public class EnemyPositions
{
    protected List<float> x = new List<float>();
    protected List<float> y = new List<float>();

    public List<float> GetX()
    {
        return x;
    }
    
    public List<float> GetY()
    {
        return y;
    }
}