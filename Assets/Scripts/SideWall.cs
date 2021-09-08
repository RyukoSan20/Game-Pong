using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    public PlayerControl player;

    [SerializeField]
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Ball")
        {
            player.AddScore();

            if(player.Score < gameManager.maxScore)
            {
                // restart ball
                other.gameObject.SendMessage("RestartBall", 2.0f, SendMessageOptions.RequireReceiver);
            }
        }
    }
}
