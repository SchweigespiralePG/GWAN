using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;

public class SettingManager : MonoBehaviour
{
    public Toggle fullscreenToggle;

    public Dropdown resolutionDropDown;
    public Dropdown textureQualityDropdown;
    public Dropdown antialiasingDropdown;
    public Dropdown vSyncDropdown;
    public Slider masterVolumeSlider;
    public Slider BGMVolumeSlider;
    public Slider FXVolumeSlider;
    public Button SaveButton;

    public GameSettings gameSettings;
    public AudioMixer MasterMixer;
    public Resolution[] resolutions;

    private void Start()
    {
        LoadSettings();
    }
    void OnEnable()
    {
        gameSettings = new GameSettings();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resolutionDropDown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        antialiasingDropdown.onValueChanged.AddListener(delegate { OnAntialiasingChange(); });
        vSyncDropdown.onValueChanged.AddListener(delegate { OnVsyncChange(); });
        BGMVolumeSlider.onValueChanged.AddListener(delegate { BGMMasterMixer(); });
        FXVolumeSlider.onValueChanged.AddListener(delegate { FXMasterMixer(); });
        masterVolumeSlider.onValueChanged.AddListener(delegate { OnMasterMixer(); });
        SaveButton.onClick.AddListener(delegate { SaveSettings(); });

        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
        {
            resolutionDropDown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
    }

    public void OnFullscreenToggle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }
    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropDown.value].width, resolutions[resolutionDropDown.value].height, Screen.fullScreen);
        gameSettings.resolutionIndex = resolutionDropDown.value;
    }
    public void OnTextureQualityChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
    }
    public void OnAntialiasingChange()
    {
        QualitySettings.antiAliasing = gameSettings.antialiasing = (int)Mathf.Pow(2f, antialiasingDropdown.value);
    }
    public void OnVsyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.vSync = vSyncDropdown.value;
    }
    public void OnMasterMixer()
    {
        gameSettings.MasterVolume = masterVolumeSlider.value;
        MasterMixer.SetFloat("MasterVolume", masterVolumeSlider.value);
    }
    public void FXMasterMixer()
    {
        gameSettings.FXVolume = FXVolumeSlider.value;
        MasterMixer.SetFloat("FXVolume", FXVolumeSlider.value);
    }
    public void BGMMasterMixer()
    {
        gameSettings.BGMVolume = BGMVolumeSlider.value;
        MasterMixer.SetFloat("BGMVolume", BGMVolumeSlider.value);
    }
    public void SaveSettings()
    {
        Debug.Log("Save");
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }
    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
        masterVolumeSlider.value = gameSettings.MasterVolume;
        FXVolumeSlider.value = gameSettings.FXVolume;
        BGMVolumeSlider.value = gameSettings.BGMVolume;
        antialiasingDropdown.value = gameSettings.antialiasing;
        vSyncDropdown.value = gameSettings.vSync;
        textureQualityDropdown.value = gameSettings.textureQuality;
        resolutionDropDown.value = gameSettings.resolutionIndex;
        fullscreenToggle.isOn = gameSettings.fullscreen;
        Screen.fullScreen = gameSettings.fullscreen;

        resolutionDropDown.RefreshShownValue();
    }
}
