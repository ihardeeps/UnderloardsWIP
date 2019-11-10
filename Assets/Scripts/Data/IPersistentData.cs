public interface IPersistentData
{
    ICharacterDataList Characters { get; }
    void Init();
    void Load();
    void Clear();
}
