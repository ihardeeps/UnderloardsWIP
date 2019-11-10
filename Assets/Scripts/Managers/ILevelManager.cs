using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelManager
{
    bool IsReady { get; }
    List<ICharacterController> PlayerUnits { get; }
    List<ICharacterController> EnemyUnits { get; }
    void Init();
    void Load();
    void Reload();
}
