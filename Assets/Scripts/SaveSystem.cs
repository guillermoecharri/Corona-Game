using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveHiscores(Hiscores hiscores)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filepath = Application.persistentDataPath + "/hiscore.sav";
        FileStream fileStream = new FileStream(filepath, FileMode.Create);
        SaveData data = new SaveData(hiscores);
        formatter.Serialize(fileStream, data); //convert the data to binary and send it to the stream's filepath.
        fileStream.Close();
    }

    public static SaveData LoadHiscores()
    {
        string filepath = Application.persistentDataPath + "/hiscore.sav";
        if (File.Exists(filepath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(filepath, FileMode.Open);
            SaveData data = formatter.Deserialize(fileStream) as SaveData; //covert the data from binary
            fileStream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save data was not found at " + filepath);
            Debug.Log("Creating a new save.");
            SaveData data = new SaveData();

            return data;
        }
    }

    public static void SavePlayerSkin(PlayerSkin playerSkin)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filepath = Application.persistentDataPath + "/skin.sav";
        FileStream fileStream = new FileStream(filepath, FileMode.Create);
        SaveData data = new SaveData(playerSkin);
        formatter.Serialize(fileStream, data); //convert the data to binary and send it to the stream's filepath.
        fileStream.Close();
    }

    public static SaveData LoadPlayerSkin()
    {
        string filepath = Application.persistentDataPath + "/skin.sav";
        if (File.Exists(filepath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(filepath, FileMode.Open);
            SaveData data = formatter.Deserialize(fileStream) as SaveData; //covert the data from binary
            fileStream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save data was not found at " + filepath);
            Debug.Log("Creating a new save.");
            SaveData data = new SaveData();

            return data;
        }
    }
}
