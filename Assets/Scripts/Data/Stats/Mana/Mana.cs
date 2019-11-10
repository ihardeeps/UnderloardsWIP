[System.Serializable]
public class Mana : Data<float>, IMana, IClone<Mana>
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
    public Mana Clone()
    {
        Mana mana = new Mana();
        mana.defaultValue = defaultValue;
        mana.Init();
        return mana;
    }

}
