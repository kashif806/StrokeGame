using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedCatcher : MonoBehaviour
{
   

    void OnTriggerEnter2D(Collider2D collision)

    {
        Destroy(GameObject.FindGameObjectWithTag("apple").gameObject);
        GameObject.Find("GameController").GetComponent<GameController>().next = true;
        float speed = GameObject.Find("GameController").GetComponent<GameController>().appleSpeed -= 2f;
        GameObject.Find("BasketCatcher").GetComponent<BasketCatcher>().catchCount = 0;
        
    }
}
