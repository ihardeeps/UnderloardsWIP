public interface IArmor
{
    float Value { get; }
    IRegen Regen { get; }
    void Init();
    void LoadDefault();
}
