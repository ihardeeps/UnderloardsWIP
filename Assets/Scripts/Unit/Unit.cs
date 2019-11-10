using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : IUnit
{
    public enum Type { PLAYER, ENEMY }
    private IStats stats;

    protected Unit.Type type;
    public Unit.Type SelectedType { get { return type; } }
    public IStats Stats { get { return stats; } }

    public virtual void Init()
    {

    }
    public void Load(IStats stats)
    {
        this.stats = stats;
    }
}
