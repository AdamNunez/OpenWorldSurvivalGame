using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class DataFilesInteraction
{
    public static PlayerData GetPlayerData(string playerName)
    {
        if (!PlayerDataFileExists(playerName))
            CreatePlayerDataFile(playerName);

     return LoadPlayerDataFromFile(playerName);
    }

    public static void SavePlayerData(PlayerData playerData,string playerName)
    {
        if (File.Exists(Application.persistentDataPath + "/" + playerName + ".dat"))
            File.Open(Application.persistentDataPath + "/" + playerName + ".dat", FileMode.Open);

    }

    private static bool PlayerDataFileExists(string playerName) 
    {
        return (File.Exists(Application.persistentDataPath + "/" + playerName + ".dat"));
    }

    private static void CreatePlayerDataFile(string playerName)
    {
        PlayerData playerData = new PlayerData();
        if (!File.Exists(Application.persistentDataPath + "/" + playerName + ".dat"))
          SerializeDataToFile(File.Create(Application.persistentDataPath + "/" + playerName + ".dat"), playerData);
    }

    private static PlayerData LoadPlayerDataFromFile(string playerName)
    {
        if (!File.Exists(Application.persistentDataPath + "/" + playerName + ".dat"))
            return DeserializeDataFromFile(File.Create(Application.persistentDataPath + "/" + playerName + ".dat"));

        return null;
    }

    private static void SerializeDataToFile(FileStream playerFile,PlayerData playerData)
    {
        if (playerFile == null)
            return;

        BinaryFormatter bf = new BinaryFormatter();
         bf.Serialize(playerFile, playerData);
    }

    private static PlayerData DeserializeDataFromFile(FileStream playerFile)
    {
        if (playerFile == null)
            return null;

        BinaryFormatter bf = new BinaryFormatter();
        PlayerData playerData = (PlayerData)bf.Deserialize(playerFile);

        return playerData;


    }

}
