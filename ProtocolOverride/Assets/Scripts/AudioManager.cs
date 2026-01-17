using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Sources")]
    public AudioSource sfxSource;

    [Header("Clips")]
    public AudioClip jump;
    public AudioClip shoot;
    public AudioClip rewind;
    public AudioClip gravityFlip;
    public AudioClip ruleBreak;
    public AudioClip levelTransition;
    public AudioClip stoneHit;
    public AudioClip exitButton;

    void Start()
    {
        sfxSource = GetComponent<AudioSource>();
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip);
        sfxSource.volume = 0.6f;
    }

    public void PlayTransition()
    {
        PlaySFX(levelTransition);
    }
}
