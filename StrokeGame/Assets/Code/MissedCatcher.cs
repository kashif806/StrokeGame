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

        //endTime = getTime();
        //Debug.Log("END TM: " + endTime);

        // TimeSpan ts = (GameObject.Find("GameController").GetComponent<GameController>().startTime) - endTime;
        //Debug.Log("total time" + ts.ToString());
        //Debug.Log("timer : " + GameObject.Find("GameController").GetComponent<GameController>().timer);
        //GameObject.Find("GameController").GetComponent<GameController>().timer = 0; 
        //gameController.next = true;
                
        gameController.appleGravity -= 0.2f;
        GameObject.Find("BasketCatcher").GetComponent<BasketCatcher>().catchCount = 0;
        gameController.appleDestroyed(false);
    }
}
