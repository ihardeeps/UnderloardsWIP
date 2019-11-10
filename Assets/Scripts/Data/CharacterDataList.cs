using System.Collections.Generic;
using UnityEngine;

public class CharacterDataList : ScriptableObject, ICharacterDataList
{
    public const string ResourcePath = "Data/CharacterDataList";
    public static readonly string AssetPath = string.Concat("Assets/Resources/", ResourcePath, ".asset");

    [SerializeField]
    private List<Character> characterList;

    public ICharacter Get(Character.ID id)
    {
        //For larger list, we can sort the characterList in ascending order by Character.ID and then we can use Binary Search for performance;
        return characterList.Find(character => character.CurrentID == id);
    }
    public void Init()
    {
        foreach (ICharacter character in characterList)
        {
            character.Init();
        }
    }
    public void LoadDefault()
    {
        foreach (ICharacter character in characterList)
        {
            character.LoadDefault();
        }
    }
}
