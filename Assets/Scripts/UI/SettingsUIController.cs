using UnityEngine; 
using UnityEngine.UIElements; 
using UnityEngine.SceneManagement;
public class SettingsUIController : MonoBehaviour 
{ 
    private Toggle vibrationToggle, hitSoundToggle; 
    private Slider hitVolumeSlider, musicSlider, delaySlider;
    private Button backButton; 
    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement; 
        vibrationToggle = root.Q<Toggle>("Toggle_Vibration");
        hitSoundToggle = root.Q<Toggle>("Toggle_HitSound"); 
        hitVolumeSlider = root.Q<Slider>("Slider_HitVolume");
        musicSlider = root.Q<Slider>("Slider_Music"); 
        delaySlider = root.Q<Slider>("Slider_Delay");
        backButton = root.Q<Button>("Btn_Back");
        // 初始化 UI 状态
        vibrationToggle.value = SettingsManager.Instance.VibrationEnabled; 
        hitSoundToggle.value = SettingsManager.Instance.HitSoundEnabled; 
        hitVolumeSlider.value = SettingsManager.Instance.HitVolume; 
        musicSlider.value = SettingsManager.Instance.MusicVolume;
        delaySlider.value = SettingsManager.Instance.Delay; 
        // 注册事件
        vibrationToggle.RegisterValueChangedCallback(evt => SettingsManager.Instance.SetVibration(evt.newValue));
        hitSoundToggle.RegisterValueChangedCallback(evt => SettingsManager.Instance.SetHitSound(evt.newValue));
        hitVolumeSlider.RegisterValueChangedCallback(evt => SettingsManager.Instance.SetHitVolume(evt.newValue));
        musicSlider.RegisterValueChangedCallback(evt => SettingsManager.Instance.SetMusicVolume(evt.newValue));
        delaySlider.RegisterValueChangedCallback(evt => SettingsManager.Instance.SetDelay(evt.newValue)); 
        
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
    
}