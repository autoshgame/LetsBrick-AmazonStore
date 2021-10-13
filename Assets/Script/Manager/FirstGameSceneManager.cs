using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstGameSceneManager : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
