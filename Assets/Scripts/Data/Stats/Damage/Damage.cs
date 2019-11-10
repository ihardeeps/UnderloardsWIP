[System.Serializable]
public class Damage : Data<float>, IDamage, IStatModifier, IClone<Damage>
{
    public void Init()
    {
        LoadDefault();
    }
    public void Boost(float factor)
    {
        currentValue *= factor;
    }

    public void Impair(float factor)
    {
        currentValue /= factor;
    }
    public void LoadDefault()
    {
        SetDefault();
    }

    public Damage Clone()
    {
        Damage damage = new Damage();
        damage.defaultValue = defaultValue;
        damage.Init();
        return damage;
    }
}
