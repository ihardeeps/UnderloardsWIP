using UnityEngine;
using System;
[System.Serializable]
public class Character : ICharacter, IEquatable<ICharacter>
{
    public const string ResourcePath = "Units/";
    public enum ID
    {
        NONE,
        OLIVER,
        THEA,
        BARRY_ALLEN,
        SUPERMAN,
        FELICITY,
        SLADE,
        MAX
    }
    [SerializeField]
    private ID id;
    [SerializeField]
    private Stats stats;
    public IStats Stats { get { return stats; } }
    public ID CurrentID { get { return id; } }
    public void Init()
    {
        stats.Init();
    }
    public void LoadDefault()
    {
        Stats.LoadDefault();
    }

    public bool Equals(ICharacter other)
    {
        return CurrentID == other.CurrentID;
    }
}
