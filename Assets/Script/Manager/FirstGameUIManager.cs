using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class FirstGameUIManager : MonoBehaviour
{
    [SerializeField] private GameOverUI gameOverUI;
    [SerializeField] private GameWinnerUI gameWinnerUI;
    [SerializeField] private GamePausingUI gamePausingUI;

    [SerializeField] private Button openPausingUIButton;

    [SerializeField] private TextMeshProUGUI timeUI;

    private void Start()
    {
        this.RegisterListener(EventID.OnGameWinner, (param) => DisplayTotalScores((int) param));
    }
    public void ActiveGameOverUI()
    {
        gameOverUI.SetActivation();
        openPausingUIButton.interactable = false;
    }


    public void ActiveGamweWinnerUI()
    {
        gameWinnerUI.SetActivation();
        openPausingUIButton.interactable = false;
    }


    public void DisplayTotalScores(int score)
    {
        gameWinnerUI.SetFinalScore(score);
    }


    public void ActiveGamePausingUI()
    {
        gamePausingUI.SetActivation();
    }


    public void DeactiveGamePausingUI()
    {
        gamePausingUI.SetDeactivation();
    }


    public void SetTimeUI(int time)
    {
        int minutes = (int)time / 60;
        int seconds = time - minutes * 60;

        //Change minute and second from int to string
        string minutesString = minutes.ToString();
        string secondsString = seconds.ToString();


        //let the time have the right format : (00 : 00)
        if (minutesString.Length == 1)
        {
            minutesString = "0" + minutesString;
        }

        if (secondsString.Length == 1)
        {
            secondsString = "0" + secondsString;
        }

        timeUI.text = minutesString + " : " + secondsString;
    }
}
