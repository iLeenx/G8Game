using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    //public Slider playerSfxSlider;

    private void Start()
    {
        musicSlider.value = AudioManager.instance.musicSource.volume;
        sfxSlider.value = AudioManager.instance.sfxSource.volume;
        //playerSfxSlider.value = AudioManager.instance.playerSfxSource.volume;
    }

    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.instance.ToggleSFX();
    }

    public void TogglePlayerSFX()
    {
        //AudioManager.instance.TogglePlayerSFX();
    }

    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(musicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(sfxSlider.value);
    }

    public void PlayerSFXVolume()
    {
        //AudioManager.instance.PlayerSFXVolume(playerSfxSlider.value);
    }
}
