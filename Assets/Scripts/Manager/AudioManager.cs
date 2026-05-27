using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioSource effectAudioSource;

    [Header("Background Clips")]
    [SerializeField] private AudioClip backGroundMap1Clip;
    [SerializeField] private AudioClip backGroundMap2Clip;
    [SerializeField] private AudioClip backGroundMap3Clip;
    [SerializeField] private AudioClip menuClip;

    [Header("Effect Clips")]
    [SerializeField] private AudioClip jumbClip;
    [SerializeField] private AudioClip carClip;
    [SerializeField] private AudioClip[] gameOverClip;
    [SerializeField] private AudioClip[] gameWinClip;

    private const string BGM_VOLUME_KEY = "BGMVolume";
    private const string SFX_VOLUME_KEY = "SFXVolume";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadVolume();

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusicByScene();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicByScene();
    }

    private void PlayMusicByScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Map1")
        {
            ChangeBackgroundMusic(backGroundMap1Clip);
        }
        else if (currentScene == "Map2")
        {
            ChangeBackgroundMusic(backGroundMap2Clip);
        }
        else if (currentScene == "Map3")
        {
            ChangeBackgroundMusic(backGroundMap3Clip);
        }
        else
        {
            ChangeBackgroundMusic(menuClip);
        }
    }

    private void ChangeBackgroundMusic(AudioClip newClip)
    {
        if (newClip == null) return;

        if (backgroundAudioSource.clip == newClip && backgroundAudioSource.isPlaying)
            return;

        backgroundAudioSource.clip = newClip;
        backgroundAudioSource.loop = true;
        backgroundAudioSource.Play();
    }

    public void PlayCarSound()
    {
        PlaySFX(carClip);
    }

    public void PlayJumbSound()
    {
        PlaySFX(jumbClip);
    }

    public void PlayGameOverSound()
    {
        PlayRandomSFX(gameOverClip);
    }

    public void PlayGameWinSound()
    {
        PlayRandomSFX(gameWinClip);
    }

    private void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;

        effectAudioSource.PlayOneShot(clip);
    }

    private void PlayRandomSFX(AudioClip[] clips)
    {
        if (clips == null || clips.Length == 0) return;

        int index = Random.Range(0, clips.Length);
        effectAudioSource.PlayOneShot(clips[index]);

        Debug.Log("Random sound index: " + index);
    }

    public void SetBGMVolume(float volume)
    {
        backgroundAudioSource.volume = volume;

        PlayerPrefs.SetFloat(BGM_VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float volume)
    {
        effectAudioSource.volume = volume;

        PlayerPrefs.SetFloat(SFX_VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }

    public float GetBGMVolume()
    {
        return PlayerPrefs.GetFloat(BGM_VOLUME_KEY, 1f);
    }

    public float GetSFXVolume()
    {
        return PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 1f);
    }

    private void LoadVolume()
    {
        backgroundAudioSource.volume = GetBGMVolume();
        effectAudioSource.volume = GetSFXVolume();
    }
}