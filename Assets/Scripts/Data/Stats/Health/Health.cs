[System.Serializable]
public class Health : Data<float>, IHealth, IClone<Health>
{
    public bool IsDepleted { get { return currentValue <= 0; } }
    public float Percentage
    {
        get { return currentValue / defaultValue * 100; }
    }
    public IRegen Regen => throw new System.NotImplementedException();

    public Health Clone()
    {
        Health health = new Health();
        health.defaultValue = defaultValue;
        health.Init();
        return health;
    }

    public void Init()
    {
        LoadDefault();
    }

    public void LoadDefault()
    {
        SetDefault();
    }

    public void Reduce(IDamage damage)
    {
        currentValue -= damage.Value;
    }

    public void Increase(IRegen regeneration)
    {
        currentValue += regeneration.Value;
    }

    public void Replenish()
    {
        LoadDefault();
    }
}
