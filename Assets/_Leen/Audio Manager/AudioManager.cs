using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // to access the AudioManager from other scripts
    public static AudioManager instance;

    [Header("Audio")]
    public Sound[] musicSounds;
    public Sound[] sfxSounds;
    public AudioSource musicSource;
    public AudioSource sfxSource;
    //public Sound[] playerSounds;
    //public AudioSource playerSfxSource;

    private void Awake()
    {
        // singleton pattern to ensure only one instance of AudioManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //play background music at the start
        PlayMusic("BGM");

        //if (musicSlider != null)
        //{
        //    musicSlider.onValueChanged.AddListener(MusicVolume);
        //}
        //if (sfxSlider != null)
        //{
        //    sfxSlider.onValueChanged.AddListener(SFXVolume);
        //}
    }

    public void PlayMusic(string name)
    {
        Sound s = System.Array.Find(musicSounds, sound => sound.name == name);
        if (s != null)
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Music sound not found: " + name);
        }
    }

    public void playSFX(string name)
    {
        Sound s = System.Array.Find(sfxSounds, sound => sound.name == name);
        if (s != null)
        {
            sfxSource.PlayOneShot(s.clip);
        }
        else
        {
            Debug.LogWarning("SFX sound not found: " + name);
        }
    }

    //public void playPlayerSFX(string name)
    //{
    //    Sound s = System.Array.Find(playerSounds, sound => sound.name == name);
    //    if (s != null)
    //    {
    //        playerSfxSource.PlayOneShot(s.clip);
    //    }
    //    else
    //    {
    //        Debug.LogWarning("SFX sound not found: " + name);
    //    }
    //}

    //public void ToggleMusic()
    //{         
    //    musicSource.mute = !musicSource.mute;
    //    Debug.Log("Music toggled. Mute is now: " + musicSource.mute);
    //}

    //public void ToggleSFX()
    //{
    //    sfxSource.mute = !sfxSource.mute;
    //    Debug.Log("SFX toggled. Mute is now: " + sfxSource.mute);
    //}

    //public void MusicVolume(float volume)
    //{
    //    musicSource.volume = volume;

    //    Debug.Log("Music volume set to: " + musicSlider.value );
    //}

    //public void SFXVolume(float volume)
    //{
    //    sfxSource.volume = volume;

    //    Debug.Log("SFX volume set to: " + sfxSlider.value);
    //}

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        Debug.Log("Music toggled. Mute is now: " + musicSource.mute);
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
        Debug.Log("SFX toggled. Mute is now: " + sfxSource.mute);
    }

    //public void TogglePlayerSFX()
    //{
    //    playerSfxSource.mute = !playerSfxSource.mute;
    //    Debug.Log("Player SFX toggled. Mute is now: " + playerSfxSource.mute);
    //}

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
        Debug.Log("Music volume set to: " + volume);
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
        Debug.Log("SFX volume set to: " + volume);
    }

    //public void PlayerSFXVolume(float volume)
    //{
    //    playerSfxSource.volume = volume;
    //    Debug.Log("Player SFX volume set to: " + volume);
    //}
}
