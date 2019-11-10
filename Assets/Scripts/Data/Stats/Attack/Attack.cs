using UnityEngine;
[System.Serializable]
public class Attack : IAttack, IStatModifier, IClone<Attack>
{
    [System.Flags]
    public enum Type
    {
        INSTANT_HIT = 1 << 0,
        PROJECTILE = 1 << 1,
    }
    [SerializeField]
    private Type attackType;
    [SerializeField]
    private Damage damage;
    [SerializeField]
    private Speed speed;
    [SerializeField]
    private Range range;
    public IDamage Damage { get { return damage; } }
    public ISpeed Speed { get { return speed; } }
    public IRange Range { get { return range; } }
    public Type AttackType { get { return attackType; } }
    public void Init()
    {
        LoadDefault();
    }

    public void Boost(float factor)
    {
        damage.Boost(factor);
        speed.Boost(factor);
    }

    public void Impair(float factor)
    {
        damage.Impair(factor);
        speed.Impair(factor);
    }
    public void LoadDefault()
    {
        Damage.LoadDefault();
        Speed.LoadDefault();
    }

    public Attack Clone()
    {
        Attack attack = new Attack();
        attack.damage = damage.Clone();
        attack.range = range.Clone();
        attack.speed = speed.Clone();
        return attack;
    }
}
