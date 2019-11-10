using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour, ILevelManager
{
    public static System.Action<IUnit> OnUnitDiedEvent;

    private bool ready = false;
    private int playerKillCount, enemyKillCount;
    private List<ICharacterController> playerUnits;
    private List<ICharacterController> enemyUnits;
    [Header("This is temporary. All fight info should be coming through FightData.")]
    public List<Character.ID> playerUnitsToSpawn;
    public List<Character.ID> enemyUnitsToSpawn;
    public Renderer playerSpawnArea, enemySpawnArea;
    public bool IsReady { get { return ready; } }
    public List<ICharacterController> PlayerUnits { get { return playerUnits; } }
    public List<ICharacterController> EnemyUnits { get { return enemyUnits; } }

    public void Init()
    {
        InitPlayerUnits();
        InitEnemyUnits();
        ready = true;
    }
    public void Load()
    {
        LoadPlayerUnits();
        LoadEnemyUnits();
    }
    private void LoadUnits(List<Character.ID> charIDs, Unit.Type type)
    {
        foreach (Character.ID id in charIDs)
        {
            ICharacter character = PersistentData.Instance.Characters.Get(id);
            GameObject characterObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(string.Format("{0}{1}", Character.ResourcePath, id)), transform);
            ICharacterController characterController = characterObject.GetComponent<CharacterController>();
            switch (type)
            {
                case Unit.Type.PLAYER:
                    playerUnits.Add(characterController);
                    characterObject.transform.position = GetRandomPointInArea(playerSpawnArea);
                    break;
                case Unit.Type.ENEMY:
                    enemyUnits.Add(characterController);
                    characterObject.transform.position = GetRandomPointInArea(enemySpawnArea);
                    break;
            }
            characterController.Load(character, type);
        }
    }
    private void LoadPlayerUnits()
    {
        playerUnits = new List<ICharacterController>();
        LoadUnits(playerUnitsToSpawn, Unit.Type.PLAYER);
    }
    private void LoadEnemyUnits()
    {
        enemyUnits = new List<ICharacterController>();
        LoadUnits(enemyUnitsToSpawn, Unit.Type.ENEMY);
    }
    private void InitUnits(List<ICharacterController> units)
    {
        foreach (ICharacterController controller in units)
        {
            controller.Init(this);
        }
    }
    private void InitPlayerUnits()
    {
        playerKillCount = 0;
        InitUnits(PlayerUnits);
    }
    private void InitEnemyUnits()
    {
        enemyKillCount = 0;
        InitUnits(EnemyUnits);
    }
    private Vector3 GetRandomPointInArea(Renderer renderer)
    {
        Vector3 value = Vector3.zero;
        value.x = Random.Range(-renderer.bounds.extents.x, renderer.bounds.extents.x) + renderer.transform.position.x;
        value.z = Random.Range(-renderer.bounds.extents.y, renderer.bounds.extents.y) + renderer.transform.position.z;
        return value;
    }
    public void Reload()
    {
        throw new System.NotImplementedException();
    }

    private void OnUnitDied(IUnit unit)
    {
        switch (unit.SelectedType)
        {
            case Unit.Type.PLAYER:
                playerKillCount++;
                break;
            case Unit.Type.ENEMY:
                enemyKillCount++;
                break;
        }
        if(playerKillCount >= PlayerUnits.Count)
        {
            Debug.Log("Player loses");
        }
        else if (enemyKillCount >= EnemyUnits.Count)
        {
            Debug.Log("Enemy loses");
        }
    }
    private void Awake()
    {
        OnUnitDiedEvent += OnUnitDied;
    }
    private void OnDestory()
    {
        OnUnitDiedEvent -= OnUnitDied;
    }
}
