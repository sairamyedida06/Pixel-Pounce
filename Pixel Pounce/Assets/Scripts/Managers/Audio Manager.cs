using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; 
    private AudioSource sfxSource;


    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            sfxSource = GetComponent<AudioSource>();
        }
        else
        {
            DontDestroyOnLoad(Instance);
            
        }
    }

    public void PlayCoinSFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}