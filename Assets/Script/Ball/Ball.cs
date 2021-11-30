using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D ballRigidBody2D;
    private GameObject player;
    private PlayerStat playerStat;
    private FirstGameGameManager firstGame_GameManager;

    [SerializeField] private BrickLevel brickLevel = default;
    

    int bricksThatAreColapsed = 0;


    private void Awake()
    {
        ballRigidBody2D = GetComponent<Rigidbody2D>();

        //Find GameObject 
        playerStat = GameObject.FindGameObjectWithTag("PlayerStat").GetComponent<PlayerStat>();
        player = GameObject.FindGameObjectWithTag("Player");
        firstGame_GameManager = GameObject.FindGameObjectWithTag("FirstGameManager").GetComponent<FirstGameGameManager>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick")
        {
            Destroy(collision.gameObject);
            playerStat.IncreaseScore(1);
            AddCollapsedBrick();
            FirstGameSoundManager.Instance.PlayBrokenBrickSound();
        }

        //Check game condition when colliding an object
        CheckGameWinner();
    }


    public void AddBeginForce()
    {
        ballRigidBody2D = this.GetComponent<Rigidbody2D>();
        ballRigidBody2D.AddForce(new Vector2(Random.Range(0, 100), 400));    //400 is the number have been calculated to satisfy the player
    }


    public void ResetBallPositionAndVelocity()
    {
        this.transform.position = player.transform.position + new Vector3(0, 1, 0); //1 is the distance between Ball and Player in the frist time
        ballRigidBody2D.velocity = Vector2.zero;
    }


    public void AddCollapsedBrick()
    {
        bricksThatAreColapsed += 1;
    }


    void CheckGameWinner()
    {
        //Debug.Log(bricksThatAreColapsed);
        if (bricksThatAreColapsed >= brickLevel.level1)
        {
            firstGame_GameManager.SetGameWinner();
        }
    }
}
