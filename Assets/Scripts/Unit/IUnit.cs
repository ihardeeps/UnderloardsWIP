using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit
{
    Unit.Type SelectedType { get; }
    IStats Stats { get; }
    void Init();
    void Load(IStats stats);
}
