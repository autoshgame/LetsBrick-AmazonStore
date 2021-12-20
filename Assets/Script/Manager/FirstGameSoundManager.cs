using UnityEngine;

public class FirstGameSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip brokenBrickClip;
    [SerializeField] private AudioClip winStateClip;
    [SerializeField] private AudioClip loseStateClip;
    [SerializeField] private AudioClip decreasingHealthClip;
    private AudioSource firstGameAudioSource;

    private static FirstGameSoundManager instance;  //instance is the one, without the second

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
        firstGameAudioSource.PlayDelayed(5f);   //5f is the duration of the following audio clip
        firstGameAudioSource.PlayOneShot(loseStateClip);
    }


    public void PlayPlayerWinSound()
    {
        firstGameAudioSource.PlayDelayed(3f);   //3f is the duration of the following audio clip
        firstGameAudioSource.PlayOneShot(winStateClip);
    }


    public void PlayDecreasingHeathSound()
    {
        firstGameAudioSource.PlayOneShot(decreasingHealthClip);
    }

}
