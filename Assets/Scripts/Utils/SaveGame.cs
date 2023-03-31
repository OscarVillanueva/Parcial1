using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveGame
{
    private string savePath = Application.persistentDataPath + "/gamesave.save";

    public void SaveData(Progress progress)
    {
        BinaryFormatter binaryFormatter = new();
        using var fileStream = File.Create(savePath);
        binaryFormatter.Serialize(fileStream, progress);
    }

    public Progress LoadData()
    {
        if (!File.Exists(savePath)) return null;
        
        Progress data;

        BinaryFormatter binaryFormatter = new();
        using var fileStream = File.Open(savePath, FileMode.Open);
        data = (Progress) binaryFormatter.Deserialize(fileStream);

        return data;

    }

    public void Reset()
    {
        SaveData(new Progress(0, 3, 1));
    }

}