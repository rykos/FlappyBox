using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class FileController : MonoBehaviour
{
    private string localPath;

    private void Awake()
    {
        localPath = Application.persistentDataPath;
        LoadPlayer();
    }

    public void SavePlayer()
    {
        string savePath = localPath + "/playerSave.bin";
        PlayerModel pm = PlayerController.PlayerModel;
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = new FileStream(savePath, FileMode.Create))
        {
            bf.Serialize(fs, pm);
        }
    }

    public void LoadPlayer()
    {
        string savePath = localPath + "/playerSave.bin";
        BinaryFormatter bf = new BinaryFormatter();
        PlayerModel pm = null;
        try
        {
            using (FileStream fs = new FileStream(savePath, FileMode.Open))
            {
                pm = ((PlayerModel)bf.Deserialize(fs));
            }
        }
        catch { }
        PlayerController.PlayerModel = pm ?? new PlayerModel();
    }

    private void OnApplicationQuit()
    {
        SavePlayer();
    }
}
