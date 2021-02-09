using UnityEngine;
using UnityEditor;
using Storage;

public class GameItemUtility
{
    [MenuItem("Assets/Create/GameItem")]
    static void CreateItem()
    {
        ScriptableObjectUtility.CreateAsset<GameItem>();
    }
}
