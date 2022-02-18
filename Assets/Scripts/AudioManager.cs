using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;
    private AudioSource[] allAudioSources;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void OnSceneLoaded(Scene s, LoadSceneMode sceneMode)
    {
        switch (s.name)
        {
            case "Menu":
                Stop();
                Play(sounds[0].name);
                PlayDelayed(sounds[1].name, sounds[0].clip.length);
                break;
            case "Main":
                Stop();
                Play(sounds[2].name);
                PlayDelayed(sounds[3].name, sounds[2].clip.length);
                break;
            default:
                break;
        }
    }

    public void Play(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (name == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    public void PlayDelayed(string name, float delay)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (name == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.PlayDelayed(delay);
    }

    public void Stop()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }
}
