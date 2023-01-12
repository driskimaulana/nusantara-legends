using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Player player;
    public EnemyChaser enemy;

    public GameObject endgameUI;

    private void Update()
    {
     if(player.currentHealth == 0)
        {
            endgameUI.SetActive(true);
        }   

     if(enemy.health == 0)
        {
            Debug.Log("Dead");
            endgameUI.SetActive(true);
        }
    }
}
