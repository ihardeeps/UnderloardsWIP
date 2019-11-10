using UnityEditor;
using UnityEngine;

public class EditorTool : Editor
{
    [MenuItem("Data/Create Character Data List")]
    public static void CreateCharacterDataList()
    {
        CharacterDataList data = ScriptableObject.CreateInstance<CharacterDataList>();
        AssetDatabase.CreateAsset(data, CharacterDataList.AssetPath);
    }
}
