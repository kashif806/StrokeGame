using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MissedCatcher : MonoBehaviour
{

    public System.DateTime endTime;


    private System.DateTime getTime()
    {
        return System.DateTime.Now;
    }

    void OnTriggerEnter2D(Collider2D collision)

    {
        Destroy(GameObject.FindGameObjectWithTag("apple").gameObject);
        var gameController = GameObject.Find("GameController").GetComponent<GameController>();

        gameController.appleGravity += 0.05f;  //slacking factor
        gameController.appleGravity -= 0.2f;
        GameObject.Find("BasketCatcher").GetComponent<BasketCatcher>().catchCount = 0;
        gameController.appleDestroyed(false);
    }
}
