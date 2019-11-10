public interface ICharacterDataList
{
    ICharacter Get(Character.ID id);
    void Init();
    void LoadDefault();
}
