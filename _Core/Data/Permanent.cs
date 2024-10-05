using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public static class Permanent
{
    private static string permanentDataFileName = "SavedData";

    private static PermanentData SavedPermanent;
    public static PermanentData PermanentInstance
    {
        
        get
        {
            if (SavedPermanent == null)
            {
                bool directoryExists = File.Exists(HandleSerialize.GetDataLocalPath(permanentDataFileName));

                if (directoryExists)
                {
                    SavedPermanent = HandleSerialize.GetObjectFromFile<PermanentData>(permanentDataFileName);
                }

                if (SavedPermanent == null || !directoryExists || HandleSerialize.IsAnyFieldNull<PermanentData>(SavedPermanent))
                {
                    SavedPermanent = new PermanentData();
                    HandleSerialize.SaveToJsonFile(SavedPermanent, permanentDataFileName);
                }
            }
            return SavedPermanent;
        }
        
    }

    public static void SavePermanent()
    {
        HandleSerialize.SaveToJsonFile(SavedPermanent, permanentDataFileName);
    }
}
