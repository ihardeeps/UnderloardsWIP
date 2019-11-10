[System.Serializable]
public class Magic : Data<float>, IMagic
{
    public void Init()
    {
        LoadDefault();
    }
    public void LoadDefault()
    {
        SetDefault();
    }
    public Magic Clone()
    {
        Magic magic = new Magic();
        magic.defaultValue = defaultValue;
        magic.Init();
        return magic;
    }
}
