using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;

public class AudioVolumeController : MonoBehaviour
{
    [Header("FMOD VCA")]
    [SerializeField] private string musicVcaName = "Music";
    [SerializeField] private string sfxVcaName = "SFX";

    [Header("UI Sliders")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private VCA VcaMusicControler;
    private VCA VcaSFXController;

    private float musicVolume = 0.5f;
    private float sfxVolume = 0.5f;

    private void Start()
    {
        // Инициализация FMOD buses
        VcaMusicControler = RuntimeManager.GetVCA("vca:/" + musicVcaName);
        VcaSFXController = RuntimeManager.GetVCA("vca:/" + sfxVcaName); 

        // Загрузка сохраненных значений громкости
        LoadVolumes();

        // Настройка слайдеров
        if (musicSlider != null)
        {
            musicSlider.value = musicVolume;
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }

        if (sfxSlider != null)
        {
            sfxSlider.value = sfxVolume;
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        VcaMusicControler.setVolume(musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        VcaSFXController.setVolume(sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    private void LoadVolumes()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

        VcaMusicControler.setVolume(musicVolume);
        VcaSFXController.setVolume(sfxVolume);
    }
    
    private void OnApplicationQuit()
    {
        SaveVolumes();
    }

    private void SaveVolumes()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.Save();
    }
}
