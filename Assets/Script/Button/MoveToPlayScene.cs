using UnityEngine;
using UnityEngine.UI;

public class MoveToPlayScene : MonoBehaviour
{
    private Button targetButton;

    private void Awake()
    {
        targetButton = GetComponent<Button>();
    }


    private void Start()
    {
        targetButton.onClick.AddListener(() => FirstGameSceneManager.Instance.MoveToPlayScene());
    }
}
