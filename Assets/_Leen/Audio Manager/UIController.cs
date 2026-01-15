using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public Button musicButton;
    public Button sfxButton;

    //public Slider playerSfxSlider;

    private void Start()
    {
        musicSlider.value = AudioManager.instance.musicSource.volume;
        sfxSlider.value = AudioManager.instance.sfxSource.volume;
        //playerSfxSlider.value = AudioManager.instance.playerSfxSource.volume;

        UpdateMusicButtonColor();
        UpdateSFXButtonColor();
    }

    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
        UpdateMusicButtonColor();
    }

    public void ToggleSFX()
    {
        AudioManager.instance.ToggleSFX();
        UpdateSFXButtonColor();
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

    private void UpdateMusicButtonColor()
    {
        Color color;

        if (AudioManager.instance.musicSource.mute)
        {
            ColorUtility.TryParseHtmlString("#AEA484", out color);
        }
        else
        {
            ColorUtility.TryParseHtmlString("#FFFFFF", out color);
        }

        musicButton.image.color = color;
    }
    private void UpdateSFXButtonColor()
    {
        Color color;

        if (AudioManager.instance.sfxSource.mute)
        {
            ColorUtility.TryParseHtmlString("#AEA484", out color);
        }
        else
        {
            ColorUtility.TryParseHtmlString("#FFFFFF", out color);
        }

        sfxButton.image.color = color;
    }

}
