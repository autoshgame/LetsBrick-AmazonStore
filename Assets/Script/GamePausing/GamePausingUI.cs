using UnityEngine;

public class GamePausingUI : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.SetActive(false);
    }


    public void SetActivation()
    {
        this.gameObject.SetActive(true);
    }


    public void SetDeactivation()
    {
        this.gameObject.SetActive(false);
    }
}
