public interface IAttack
{
    Attack.Type AttackType { get; }
    IDamage Damage { get; }
    ISpeed Speed { get; }
    IRange Range { get; }
    void Init();
    void LoadDefault();
}
