using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class FileCreation
{
    public const string DataFolder = "Output";
    private static string DataFolderPath = Path.Combine(Application.persistentDataPath, DataFolder);

    public static void CreatePNG(byte[] data, string fileName)
    {
        string path = Path.Combine(DataFolderPath, fileName + ".png");

        if (!Directory.Exists(DataFolderPath))
        {
            Directory.CreateDirectory(DataFolderPath);
        }

        FileStream writer = new FileStream(path, FileMode.Create);
        writer.Write(data, 0, data.Length);
        writer.Close();
    }
}
