public interface ICharacter
{
    Character.ID CurrentID { get; }
    IStats Stats { get; }
    void Init();
    void LoadDefault();
}
