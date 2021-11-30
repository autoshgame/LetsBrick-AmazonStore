using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstGameSceneManager : MonoBehaviour
{
    private static FirstGameSceneManager instance;

    public static FirstGameSceneManager Instance
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
    }


    protected void OnDestroy()
    {
        if (Instance == this)
            instance = null;
    }


    public void RestartScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }


    public void MoveToPlayScene()
    {
        SceneManager.LoadSceneAsync(1);
    }


    public void MoveToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
