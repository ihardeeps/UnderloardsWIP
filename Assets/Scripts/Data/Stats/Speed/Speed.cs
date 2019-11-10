[System.Serializable]
public class Speed : Data<float>, ISpeed, IStatModifier, IClone<Speed>
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

    public Speed Clone()
    {
        Speed speed = new Speed();
        speed.defaultValue = defaultValue;
        speed.Init();
        return speed;
    }
}
