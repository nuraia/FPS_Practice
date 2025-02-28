using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingPage : Page
{
    [Header("Setting Reference")]
    [SerializeField] private TextMeshProUGUI subtitleText;
    [SerializeField] private Toggle subtitleToggle;
    [SerializeField] private Slider volumnSlider;

    private const string Volume_Key = "musicVolumn";
    private const string Subtitle_Key = "musicVolumn";

    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        LoadPreferences();
        InitializeListeners();

    }
    private void InitializeListeners()
    {
        subtitleToggle.onValueChanged.AddListener(OnSubtitleToggled);
        volumnSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void LoadPreferences()
    {
        volumnSlider.value = PlayerPrefs.GetFloat(Volume_Key, 1);
        subtitleToggle.isOn = PlayerPrefs.GetInt(Subtitle_Key, 0) == 1;
        SubtittleMessageDispaly(subtitleToggle.isOn);
    }
    private void OnSubtitleToggled(bool isEnable)
    {
        SubtittleMessageDispaly(isEnable);
        PlayerPrefs.GetInt(Subtitle_Key, isEnable ? 1 : 0);
    }
 
    private void SubtittleMessageDispaly(bool Enable)
    {

        subtitleText.text = Enable ? "Subtittles **" : "";
    }

    private void OnVolumeChanged(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat(Volume_Key, value);
    }
     void OnDestroy()
    {
        subtitleToggle.onValueChanged.RemoveListener(OnSubtitleToggled);
        volumnSlider.onValueChanged.RemoveListener(OnVolumeChanged);
    }
}
