using UnityEngine;
using UnityEditor;
using Storage;

public class GameItemUtility
{
    [MenuItem("Assets/Create/Game/Item")]
    static void CreateItem()
    {
        ScriptableObjectUtility.CreateAsset<GameItem>();
    }
}
