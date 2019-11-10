[System.Serializable]
public class Armor : Data<float>, IArmor, IClone<Armor>
{
    public IRegen Regen => throw new System.NotImplementedException();

    public void Init()
    {
        LoadDefault();
    }
    public void LoadDefault()
    {
        SetDefault();
    }
    public Armor Clone()
    {
        Armor armor = new Armor();
        armor.defaultValue = defaultValue;
        armor.Init();
        return armor;
    }

}
