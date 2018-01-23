﻿using System.Collections;
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

    //private System.DateTime getTime()
    //{
     //   return System.DateTime.Now;
    //}

    void OnTriggerEnter2D(Collider2D collision)

    {
        Destroy(GameObject.FindGameObjectWithTag("apple").gameObject);
        caught = true;
        //endTime = getTime();
        //Debug.Log("timer : " + GameObject.Find("GameController").GetComponent<GameController>().timer);
        //GameObject.Find("GameController").GetComponent<GameController>().timer = 0;

        var gameController = GameObject.Find("GameController").GetComponent<GameController>();
        //gameController.next = true;        
        score += 1;
        catchCount += 1;
       // Debug.Log(catchCount);
        if (catchCount >= 3)
        {           
            float speed = gameController.appleGravity += 1f;
        }
        gameController.appleDestroyed(true);
    }

    public int GetScore()
    {
        return score;
    }

}

