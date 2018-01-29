using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketCatcher : MonoBehaviour
{

    //public GameObject gameController;
    //public GameObject basket; 
    public int score;
    public int catchCount;
    public System.DateTime endTime;
    public bool caught = false;


    void OnTriggerEnter2D(Collider2D collision)

    {
        Destroy(GameObject.FindGameObjectWithTag("apple").gameObject);
        caught = true;


        var gameController = GameObject.Find("GameController").GetComponent<GameController>();            
        
            gameController.appleGravity += 0.05f;  // slacking factor



        score += 1;
        catchCount += 1;
  
        if (catchCount >= 3)
        {           
           gameController.appleGravity += 1f;
        }
        gameController.appleDestroyed(true);
    }

    public int GetScore()
    {
        return score;
    }

}

