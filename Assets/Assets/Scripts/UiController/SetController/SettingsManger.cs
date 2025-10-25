using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    public bool VibrationEnabled { get; private set; }
    public bool HitSoundEnabled { get; private set; }
    public float HitVolume { get; private set; }
    public float MusicVolume { get; private set; }
    public float Delay { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadSettings();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadSettings()
    {
        VibrationEnabled = PlayerPrefs.GetInt("Vibration", 1) == 1;
        HitSoundEnabled = PlayerPrefs.GetInt("HitSound", 1) == 1;
        HitVolume = PlayerPrefs.GetFloat("HitVolume", 0.8f);
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.8f);
        Delay = PlayerPrefs.GetFloat("Delay", 0.1f);
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetInt("Vibration", VibrationEnabled ? 1 : 0);
        PlayerPrefs.SetInt("HitSound", HitSoundEnabled ? 1 : 0);
        PlayerPrefs.SetFloat("HitVolume", HitVolume);
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
        PlayerPrefs.SetFloat("Delay", Delay);
        PlayerPrefs.Save();
    }

    public void SetVibration(bool value) { VibrationEnabled = value; SaveSettings(); }
    public void SetHitSound(bool value) { HitSoundEnabled = value; SaveSettings(); }
    public void SetHitVolume(float value) { HitVolume = value; SaveSettings(); }
    public void SetMusicVolume(float value) { MusicVolume = value; SaveSettings(); }
    public void SetDelay(float value) { Delay = value; SaveSettings(); }
}