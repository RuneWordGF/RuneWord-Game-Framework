using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Text;
using System.IO;
using System.Linq;

public static class HandleSerialize
{
    public const string DataFolder = "Saves";
    private static string DataFolderPath = Path.Combine(Application.persistentDataPath, DataFolder);

    public static string GetDataLocalPath(string fileName)
    {
        return Path.Combine(DataFolderPath, fileName + ".json");
    }

    public static T GetObjectFromFile<T>(string fileName)
    {
        string jsonOutput = GetJsonFromFile(fileName);
        return Deserialize<T>(jsonOutput);
    }

    public static string GetJsonFromFile(string fileName)
    {
        string path = GetDataLocalPath(fileName);
        StreamReader reader = new StreamReader(path);
        return reader.ReadToEnd();
    }

    public static T Deserialize<T>(string input)
    {
        try
        {
            return JsonUtility.FromJson<T>(input);
        }
        catch
        {
            return default(T);
        }
    }

    public static bool IsAnyFieldNull<T>(T input)
    {
        List<object> fields = input.GetType().GetFields().Select(field => field.GetValue(input)).ToList();
        foreach (object entry in fields)
        {
            if (entry == null)
                return true;
        }
        return false;
    }

    public static void SaveToJsonFile(object input, string fileName)
    {
        string jsonText = JsonUtility.ToJson(input);
        string path = GetDataLocalPath(fileName);

        if (!Directory.Exists(DataFolderPath))
        {
            Directory.CreateDirectory(DataFolderPath);
        }

        FileStream writer = new FileStream(path, FileMode.Create);
        writer.Write(jsonText.ToBytes(), 0, jsonText.Length);
        writer.Close();
    }

    public static byte[] ToBytes(this string input)
    {
        return Encoding.ASCII.GetBytes(input);
    }
}
