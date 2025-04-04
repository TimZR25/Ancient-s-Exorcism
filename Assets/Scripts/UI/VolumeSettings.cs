using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : UI
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    [SerializeField] private UI _uiToReturn;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Return();
        }
    }

    public void Init()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = _musicSlider.value;
        _audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = _sfxSlider.value;
        _audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void LoadVolume()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        _sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMusicVolume();
        SetSFXVolume();
    }

    public void Return()
    {
        Hide();
        _uiToReturn.Show();
    }
}
