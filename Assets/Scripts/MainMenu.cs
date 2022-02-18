using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void SetVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
