using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    private PlayerStat playerStat;
    private FirstGameGameManager firstGame_GameManager;

    private void Awake()
    {
        //Get component from GameObject
        playerStat = GameObject.FindGameObjectWithTag("PlayerStat").GetComponent<PlayerStat>();
        firstGame_GameManager = GameObject.FindGameObjectWithTag("FirstGameManager").GetComponent<FirstGameGameManager>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        DecreaseHealthAndCheck();
        firstGame_GameManager.ResetAfter_Health_Decreased();
    }


    void DecreaseHealthAndCheck()
    {
        if (playerStat.Health > 1)
        {
            playerStat.DecreaseHealth();
        }
        else
        {
            playerStat.DecreaseHealth();
            firstGame_GameManager.SetGameOver();
        }
    }
}
