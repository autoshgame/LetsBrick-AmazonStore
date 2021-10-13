using System.Collections;
using UnityEngine;

public class FirstGameGameManager : MonoBehaviour
{
    private Ball ball;
    private PlayerStat playerStat;
    private FirstGameUIManager firstGame_UIManager;
    private FirstGameSceneManager firstGame_SceneManager;

    [SerializeField] int totalTime = 420;

    bool isGamePaused = false;
    bool isGameOver = false;
    bool isGameWinner = false;

    private void Awake()
    {
        //Find GameObject in scene
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
        playerStat = GameObject.FindGameObjectWithTag("PlayerStat").GetComponent<PlayerStat>();
        firstGame_UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<FirstGameUIManager>();
        firstGame_SceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<FirstGameSceneManager>();


        //Methods to start game
        StartCoroutine(IBeginGame());

        //Set timescale to 1
        Time.timeScale = 1;
    }


    private void Start()
    {
        StartCoroutine(ICountingTimeAndGameOver());
    }


    public void ResetAfter_Health_Decreased()
    {
        StartCoroutine(IResetBallPositionAndAddForces());
    }


    IEnumerator IResetBallPositionAndAddForces()
    {
        ball.ResetBallPositionAndVelocity();


        //Play reset ball sound for 2 seconds
        FirstGameSoundManager.Instance.PlayDecreasingHeathSound();

        yield return new WaitForSecondsRealtime(2f);
        ball.AddBeginForce();
    }


    IEnumerator IBeginGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        ball.AddBeginForce();
    }


    public void RestartGame()
    {
        firstGame_SceneManager.RestartScene();
    }


    public void SetGameOver()
    {
        firstGame_UIManager.ActiveGameOverUI();
        Time.timeScale = 0;
        isGameOver = true;
        FirstGameSoundManager.Instance.PlayPlayerLoseSound();
    }


    public void SetGameWinner()
    {
        Time.timeScale = 0;
        isGameWinner = true;

        firstGame_UIManager.ActiveGamweWinnerUI();
        this.PostEvent(EventID.OnGameWinner, playerStat.Score * totalTime);
        FirstGameSoundManager.Instance.PlayPlayerWinSound();
    }


    public void PauseGame()
    {
        firstGame_UIManager.ActiveGamePausingUI();
        Time.timeScale = 0;
        isGamePaused = true;
    }


    public void ResumeGame()
    {
        firstGame_UIManager.DeactiveGamePausingUI();
        Time.timeScale = 1;
        isGamePaused = false;
    }


    IEnumerator ICountingTimeAndGameOver()
    {
        while (totalTime > 0 && !isGameWinner && !isGameOver)
        {
            yield return new WaitForSeconds(1f);
            totalTime -= 1;
            firstGame_UIManager.SetTimeUI(totalTime);
        }

        if (totalTime == 0)
        {
            SetGameOver();
        }
    }
}
