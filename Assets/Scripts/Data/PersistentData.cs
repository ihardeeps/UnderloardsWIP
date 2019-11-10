using System.Threading;
using UnityEngine;

public class PersistentData : IPersistentData
{
    private static IPersistentData instance;
    public static IPersistentData Instance { get { if (instance == null) instance = new PersistentData(); return instance; } }
    private PersistentData() { }


    private ICharacterDataList characters;
    public ICharacterDataList Characters { get { return characters; } }

    public void Init()
    {
        Characters.Init();
    }
    public void Load()
    {
        //Here we can load all the persistent data like, CharacterData, MissionData, DifficultyData, 
        //EpisodeData, FightData, RewardData, StoreData so all the required information is available here whenever asked for.
        characters = Resources.Load<CharacterDataList>(CharacterDataList.ResourcePath);
    }
    public void Clear()
    {
        throw new System.NotImplementedException();
    }
}
