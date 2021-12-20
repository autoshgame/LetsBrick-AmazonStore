using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.SetActive(false);
    }


    public void SetActivation()
    {
        this.gameObject.SetActive(true);
    }


}

