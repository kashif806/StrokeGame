﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedCatcher : MonoBehaviour
{
   

    void OnTriggerEnter2D(Collider2D collision)

    {
        Destroy(GameObject.FindGameObjectWithTag("apple").gameObject);
        var gameController = GameObject.Find("GameController").GetComponent<GameController>();
        gameController.next = true;
        gameController.appleGravity -= 0.2f;
        GameObject.Find("BasketCatcher").GetComponent<BasketCatcher>().catchCount = 0;
        
    }
}
