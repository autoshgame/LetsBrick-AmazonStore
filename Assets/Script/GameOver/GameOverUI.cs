using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;

    [SerializeField] private TextMeshProUGUI totalPoints;
    private void Awake()
    {
        this.gameObject.SetActive(false);
    }


    public void SetActivation()
    {
        this.gameObject.SetActive(true);
    }


}

