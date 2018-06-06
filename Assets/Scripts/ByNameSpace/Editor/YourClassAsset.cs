using UnityEngine;
using UnityEditor;
using OpenWorld.Models;

public class YourClassAsset
{
    [MenuItem("Assets/Create/YourClass")]
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<ItemDatabase>();
    }
}