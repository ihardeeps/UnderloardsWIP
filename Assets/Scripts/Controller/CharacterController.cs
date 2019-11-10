using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour, ICharacterController
{
    private bool ready;
    private float tempFloat1, tempFloat2;
    private int tempIndex1, tempIndex2;
    private ILevelManager LevelManagerRef;
    private ICharacterController target;
    private IUnit unit;
    public IUnit Unit { get { return unit; } }
    public bool IsReady { get { return ready; } }
    public bool IsAlive { get { return !Unit.Stats.Health.IsDepleted; } }
    public ICharacterController Target { get { return target; } }
    public Vector3 Position { get { return transform.position; } }
    private void GetAPotentialTarget()
    {
        switch (unit.SelectedType)
        {
            case global::Unit.Type.PLAYER:
                target = Closest(LevelManagerRef.EnemyUnits.FindAll(AliveOnes));
                break;
            case global::Unit.Type.ENEMY:
                target = Closest(LevelManagerRef.PlayerUnits.FindAll(AliveOnes));
                break;
        }
    }
    private bool LowRangeOnes(ICharacterController controller)
    {
        return Unit.Stats.Attack.Range.Max >= controller.Unit.Stats.Attack.Range.Max;
    }
    private bool AliveOnes(ICharacterController controller)
    {
        return controller.IsAlive;
    }
    private ICharacterController Closest(List<ICharacterController> controllers)
    {
        if (controllers == null || controllers.Count <= 0) return null;
        tempIndex1 = tempIndex2 = 0;
        tempFloat1 = float.MaxValue;
        for (; tempIndex1 < controllers.Count; tempIndex1++)
        {
            if (!controllers[tempIndex1].IsAlive) continue;

            tempFloat2 = Vector3.Distance(Position, controllers[tempIndex1].Position);
            if (tempFloat2 < tempFloat1)
            {
                tempIndex2 = tempIndex1;
                tempFloat1 = tempFloat2;
            }
        }
        return controllers[tempIndex2];
    }
    public void Init(ILevelManager levelManager)
    {
        LevelManagerRef = levelManager;
        ready = true;
        StartCoroutine("DelayedUpdateBehaviour");
    }
    public void Load(ICharacter character, Unit.Type type)
    {
        switch (type)
        {
            case global::Unit.Type.PLAYER:
                unit = new PlayerUnit();
                break;
            case global::Unit.Type.ENEMY:
                unit = new EnemyUnit();
                break;
        }
        unit.Load(character.Stats.Clone());
        unit.Init();
    }
    public void Attack(ICharacterController target)
    {
        target.TakeDamage(Unit.Stats.Attack.Damage);
    }
    public void TakeDamage(IDamage damage)
    {
        Unit.Stats.Health.Reduce(damage);
        if (Unit.Stats.Health.IsDepleted)
            Die();
    }
    private void Die()
    {
        StartCoroutine("DelayedDeath");
    }
    private IEnumerator DelayedDeath()
    {
        //Do some fancy VFX/SFX
        yield return null;
        LevelManager.OnUnitDiedEvent(Unit);
        gameObject.SetActive(false);
    }
    private IEnumerator DelayedUpdateBehaviour()
    {
        //Wait until yourself is not ready
        while (!IsReady) yield return null;
        //Wait until you find a potential target;
        while (Target == null)
        {
            GetAPotentialTarget();
            yield return null;
        }
        //Wait if the target controller is not ready;
        while (!Target.IsReady) yield return null;
        //Move towards the target;
        while (Vector3.Distance(Position, Target.Position) > Unit.Stats.Attack.Range.Max)
        {
            //If other unit kills the target before this one reaches there. get it out of here!
            if (!Target.IsAlive) break;

            transform.position = Vector3.MoveTowards(Position, Target.Position, Unit.Stats.Move.Speed.Value * Time.deltaTime);
            yield return null;
        }
        tempFloat1 = 0;
        //Keep attacking until dead
        while (Target.IsAlive)
        {
            Attack(Target);
            //Doing this because Attack speed can be buffed/debuffed during the fight.
            while (tempFloat1 > Unit.Stats.Attack.Speed.Value)
            {
                tempFloat1 += Time.deltaTime;
                yield return null;
            }
            yield return null;
        }
        target = null;

        //Target died, find a new target
        StopCoroutine("DelayedUpdateBehaviour");
        StartCoroutine("DelayedUpdateBehaviour");
    }
    private void OnEnable()
    {
        //StartCoroutine("DelayedUpdateBehaviour");
    }
    private void OnDisable()
    {
        StopCoroutine("DelayedUpdateBehaviour");
    }
}
