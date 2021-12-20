using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameWinnerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;


    private void Awake()
    {
        this.gameObject.SetActive(false);
    }


    public void SetActivation()
    {
        this.gameObject.SetActive(true);
    }


    public void SetFinalScore(int score)
    {
        finalScoreText.text = " Your Score : " + (score).ToString();
    }
}
