public interface IStats
{
    IHealth Health { get; }
    IArmor Armor { get; }
    IAttack Attack { get; }
    IMove Move { get; }
    IMagic Magic { get; }
    void Init();
    void LoadDefault();
    Stats Clone();
}
