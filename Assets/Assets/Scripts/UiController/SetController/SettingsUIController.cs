using UnityEngine; 
using UnityEngine.UIElements; 
using UnityEngine.SceneManagement;
public class SettingsUIController : MonoBehaviour 
{ 
    private Toggle toggleVibration;
    private Toggle toggleHitSound;
    private Slider sliderHitVolume;
    private Slider sliderMusic;
    private Slider sliderDelay;
    
    private Button backButton; 
    
    private AudioSource musicSource;
    private AudioSource hitSoundSource;
    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement; 
        
        toggleVibration = root.Q<Toggle>("Toggle_Vibration");
        toggleHitSound = root.Q<Toggle>("Toggle_HitSound");
        sliderHitVolume = root.Q<Slider>("Slider_HitVolume");
        sliderMusic = root.Q<Slider>("Slider_Music");
        sliderDelay = root.Q<Slider>("Slider_Delay");
        backButton = root.Q<Button>("Btn_Back");
        // 初始化
        toggleVibration.RegisterValueChangedCallback(evt => OnVibrationChanged(evt.newValue));
        toggleHitSound.RegisterValueChangedCallback(evt => OnHitSoundChanged(evt.newValue));
        sliderHitVolume.RegisterValueChangedCallback(evt => OnHitVolumeChanged(evt.newValue));
        sliderMusic.RegisterValueChangedCallback(evt => OnMusicVolumeChanged(evt.newValue));
        sliderDelay.RegisterValueChangedCallback(evt => OnDelayChanged(evt.newValue));
        backButton.clicked += OnBack; 
    }

    private void OnDisable()
    {
        backButton.clicked -= OnBack;
        
    }

  
    private void OnBack()
    {
        Destroy(gameObject);   
        // 从PlayerPrefs获取来源场景
        string previousScene = PlayerPrefs.GetString("PreviousScene", "MainScenes");
        SceneManager.LoadScene(previousScene);
    }

    private void OnVibrationChanged(bool isOn)
    {
        PlayerPrefs.SetInt("Vibration",isOn ? 1 : 0);
    }

    private void OnHitSoundChanged(bool isOn)
    {
        hitSoundSource.mute =!isOn;
        PlayerPrefs.SetInt("HitSound",isOn ? 1 : 0);
    }

    private void OnHitVolumeChanged(float volume)
    {
        hitSoundSource.volume = volume;
        PlayerPrefs.SetFloat("HitVolume",volume);
    }

    private void OnMusicVolumeChanged(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume",volume);
    }

    private void OnDelayChanged(float delay)
    {
        PlayerPrefs.SetFloat("VibrationDelay",delay);
    }
}