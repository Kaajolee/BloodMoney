using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown resolutionDropdown, screenTypeDrop;

    [SerializeField]
    private Toggle vsyncToggle;

    [SerializeField]
    private AudioMixer musicMixer, masterMixer, effectsMixer;

    [SerializeField]
    private Slider masterSlider, musicSlider, effectsSlider;

    [SerializeField]
    private MenuManager menuManager;

    void Start()
    {

    }

    void Update()
    {

    }

    public void ApplySettings()
    {

        ApplyScreenType(out FullScreenMode screenMode);
        ApplyResolution(screenMode);


        ApplyVsync();


        ApplySound();

        menuManager.BackButtonPressed();
    }

    void ApplyResolution(in FullScreenMode screenMode)
    {
        switch (resolutionDropdown.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, screenMode);
                break;
            case 1:
                Screen.SetResolution(1600, 800, screenMode);
                break;
            case 2:
                Screen.SetResolution(640, 480, screenMode);
                break;
            default:
                Screen.SetResolution(Screen.width, Screen.height, screenMode);
                break;
        }
    }

    void ApplyScreenType(out FullScreenMode screenMode)
    {
        switch (screenTypeDrop.value)
        {
            case 0:
                screenMode = FullScreenMode.ExclusiveFullScreen;
                break;
            case 1:
                screenMode = FullScreenMode.FullScreenWindow;
                break;
            case 2:
                screenMode = FullScreenMode.Windowed;
                break;
            default:
                screenMode = FullScreenMode.FullScreenWindow;
                break;
        }
    }

    void ApplyVsync()
    {
        QualitySettings.vSyncCount = vsyncToggle.isOn ? 1 : 0;
    }

    void ApplySound()
    {


        masterMixer.SetFloat("Volume", Mathf.Log10(Mathf.Max(masterSlider.value, 0.0001f)) * 20);
        musicMixer.SetFloat("Volume", Mathf.Log10(Mathf.Max(musicSlider.value, 0.0001f)) * 20);
        effectsMixer.SetFloat("Volume", Mathf.Log10(Mathf.Max(effectsSlider.value, 0.0001f)) * 20);

    }
}
