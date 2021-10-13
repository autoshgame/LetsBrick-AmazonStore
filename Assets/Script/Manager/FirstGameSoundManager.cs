using UnityEngine;

public class FirstGameSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip brokenBrickClip;
    [SerializeField] private AudioClip winStateClip;
    [SerializeField] private AudioClip loseStateClip;
    [SerializeField] private AudioClip decreasingHealthClip;
    public AudioSource firstGameAudioSource;

    private static FirstGameSoundManager instance;

    public static FirstGameSoundManager Instance
    {
        get
        {
            return instance;
        }
    }


    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        firstGameAudioSource = GetComponent<AudioSource>();
    }


    protected void OnDestroy()
    {
        if (Instance == this)
            instance = null;
    }


    public void PlayBrokenBrickSound()
    {
        firstGameAudioSource.PlayOneShot(brokenBrickClip);
    }


    public void PlayPlayerLoseSound()
    {
        firstGameAudioSource.PlayDelayed(5f);
        firstGameAudioSource.PlayOneShot(loseStateClip);
    }


    public void PlayPlayerWinSound()
    {
        firstGameAudioSource.PlayDelayed(3f);
        firstGameAudioSource.PlayOneShot(winStateClip);
    }


    public void PlayDecreasingHeathSound()
    {
        firstGameAudioSource.PlayOneShot(decreasingHealthClip);
    }

}
