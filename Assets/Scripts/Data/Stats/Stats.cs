using UnityEngine;
using System;
[System.Serializable]
public class Stats : IStats, IClone<Stats>
{
    [SerializeField]
    private Health health;
    [SerializeField]
    private Armor armor;
    [SerializeField]
    private Attack attack;
    [SerializeField]
    private Move move;
    [SerializeField]
    private Magic magic;
    public IHealth Health { get { return health; } }
    public IArmor Armor { get { return armor; } }
    public IAttack Attack { get { return attack; } }
    public IMove Move { get { return move; } }
    public IMagic Magic { get { return magic; } }

    public void Init()
    {
        Health.Init();
        Armor.Init();
        Attack.Init();
        Move.Init();
        Move.Init();
        Magic.Init();
    }

    public void LoadDefault()
    {
        Health.LoadDefault();
        Armor.LoadDefault();
        Attack.LoadDefault();
        Move.LoadDefault();
        Move.LoadDefault();
        Magic.LoadDefault();
    }
    public Stats Clone()
    {
        Stats stats = new Stats();
        stats.health = health.Clone();
        stats.armor = armor.Clone();
        stats.attack = attack.Clone();
        stats.move = move.Clone();
        stats.magic = magic.Clone();
        return stats;
    }

}
