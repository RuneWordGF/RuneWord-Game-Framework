using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public Button NewGameButton;
    public Button LoadGameButton;
    public Button SettingsButton;
    public Button QuitButton;

    public TextMeshProUGUI DebugOutput;

    // Start is called before the first frame update
    void Start()
    {
        DebugOutput.gameObject.SetActive(false);

        SetupButtonTexts();

        NewGameButton.onClick.AddListener(() => NewGame());
        LoadGameButton.onClick.AddListener(() => LoadGame());
        SettingsButton.onClick.AddListener(() => OpenSettings());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        Debug.Log("Saving clear data...");

        DebugOutput.gameObject.SetActive(true);

        string loadResult = "";
        Permanent.PermanentInstance.Settings.Sound.SFXLevel = 0.99f;
        loadResult += "Stored new sfxValue: " + Permanent.PermanentInstance.Settings.Sound.SFXLevel + "\n";
        Permanent.PermanentInstance.Saves.Slot2.Name = "CLEAR";
        loadResult += "Stored new name slot2: " + Permanent.PermanentInstance.Saves.Slot2.Name + "\n";

        Permanent.SavePermanent();

        DebugOutput.text += loadResult;
    }

    public void LoadGame()
    {
        Debug.Log("Attempting to load game...");

        DebugOutput.gameObject.SetActive(true);

        string loadResult = "";
        loadResult += "New data loaded, sound sfx: " + Permanent.PermanentInstance.Settings.Sound.SFXLevel + "\n";
        loadResult += "New data loaded, character name on slot2: " + Permanent.PermanentInstance.Saves.Slot2.Name + "\n";

        DebugOutput.text += loadResult;
    }

    public void OpenSettings()
    {
        Debug.Log("Saving different data...");

        DebugOutput.gameObject.SetActive(true);

        string loadResult = "";
        Permanent.PermanentInstance.Settings.Sound.SFXLevel = 0.3f;
        loadResult += "Stored new sfxValue: " + Permanent.PermanentInstance.Settings.Sound.SFXLevel + "\n";
        Permanent.PermanentInstance.Saves.Slot2.Name = "NOBODY";
        loadResult += "Stored new name slot2: " + Permanent.PermanentInstance.Saves.Slot2.Name + "\n";

        Permanent.SavePermanent();

        DebugOutput.text += loadResult;
    }

    public void SetupButtonTexts()
    {
        TextMeshProUGUI buttonText = NewGameButton.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = "New Game";
        buttonText = LoadGameButton.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = "Load Game";
        buttonText = SettingsButton.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = "Settings";
        buttonText = QuitButton.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = "Quit";
    }
}
