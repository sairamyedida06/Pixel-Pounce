using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; 
    private AudioSource sfxSource;

    private void Awake()
    {
        // Singleton logic: ensures only one manager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            sfxSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
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