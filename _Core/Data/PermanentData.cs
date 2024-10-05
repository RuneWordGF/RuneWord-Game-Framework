using System.Collections.Generic;

using static Permanent;

[System.Serializable]
public class PermanentData
{
    [System.Serializable]
    public class SoundConfiguration
    {
        public float SFXLevel = 0.5f;
        public float MusicLevel = 0.5f;
    }

    [System.Serializable]
    public class Configuration
    {
        public SoundConfiguration Sound = new SoundConfiguration();
    }

    [System.Serializable]
    public class GameSave
    {
        public int Money = 0;

        public List<int> Items = new List<int>();
        public List<int> PartyCharacters = new List<int>();
    }

    [System.Serializable]
    public class Slot
    {
        public string Name = "unset";
        public int Time = 0;
        public GameSave Save = new GameSave();
    }

    [System.Serializable]
    public class SavedData
    {
        public Slot Slot1 = new Slot();
        public Slot Slot2 = new Slot();
        public Slot Slot3 = new Slot();
    }

    public Configuration Settings = new Configuration();
    public SavedData Saves = new SavedData();
}
