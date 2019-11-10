using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterController
{
    bool IsReady { get; }
    bool IsAlive { get; }
    Vector3 Position { get; }
    IUnit Unit { get; }
    ICharacterController Target { get; }
    void Init(ILevelManager levelManager);
    void Load(ICharacter character, Unit.Type type);
    void Attack(ICharacterController target);
    void TakeDamage(IDamage attack);

}
