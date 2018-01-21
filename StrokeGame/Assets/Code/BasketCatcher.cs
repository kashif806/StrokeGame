using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketCatcher : MonoBehaviour
{

    //public GameObject gameController;
    //public GameObject basket; 
    public int score;
    public int catchCount;



    void OnTriggerEnter2D(Collider2D collision)

    {
        Destroy(GameObject.FindGameObjectWithTag("apple").gameObject);
        GameObject.Find("GameController").GetComponent<GameController>().next = true;
        score += 1;
        catchCount += 1;
        Debug.Log(catchCount);
        if (catchCount >= 3)
        {
           
            float speed = GameObject.Find("GameController").GetComponent<GameController>().appleSpeed += 2f;

        }
    }

    public int GetScore()
    {
        return score;
    }

}

