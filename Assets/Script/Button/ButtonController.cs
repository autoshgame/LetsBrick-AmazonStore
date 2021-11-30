using UnityEngine;


public class ButtonController : MonoBehaviour
{
    public void MoveToMenu()
    {
        FirstGameSceneManager.Instance.MoveToMainMenu();
    }


    public void Restart()
    {
        FirstGameSceneManager.Instance.RestartScene();
    }


    public void MoveToPlayScene()
    {
        FirstGameSceneManager.Instance.MoveToPlayScene();
    }


}
