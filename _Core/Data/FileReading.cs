using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileReading
{
    private static string DataFolder = "Data";
    private static string DataFolderPath = Path.Combine(Application.persistentDataPath, DataFolder);

    public static void SetDataFolder(string newFolder)
    {
        string newPath = Path.Combine(Application.persistentDataPath, newFolder);
        if (!Directory.Exists(newPath))
        {
            Debug.LogError("You are about to set a working directory that does not exists; operation cancelled.");
            return;
        }

        DataFolderPath = newPath;
        DataFolder = newFolder;
    }

    public static string GetDataLocalPath(string fileNameAndType)
    {
        return Path.Combine(DataFolderPath, fileNameAndType);
    }

    public static string GetDataFromFile(string fileName, string extension = "txt")
    {
        string path = GetDataLocalPath(fileName + "." + extension);
        StreamReader reader = new StreamReader(path);
        string result = reader.ReadToEnd();
        reader.Close();
        return result;
    }
}
