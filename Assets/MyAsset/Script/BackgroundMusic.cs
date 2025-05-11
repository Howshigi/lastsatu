using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.playOnAwake = false;
    }

    private void Update()
    {
        
        if (Time.timeScale > 0f && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (Time.timeScale == 0f && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }
}