using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{

    //public float appleSpeed = 5f;
    //public Vector3 applePosn;
    float targetLineForFallTime;

    void Start()
    {
        //float speed;
        //Debug.Log(gameObject.GetComponent<Rigidbody2D>().mass);
        var gameController = GameObject.Find("GameController").GetComponent<GameController>();
       // if (gameController.appleGravity > 0.1f) {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = gameController.appleGravity;
        //}
        //else
        //{
         //   gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        //}

        Debug.Log("apple speed: " + gameObject.GetComponent<Rigidbody2D>().gravityScale);

        float upperBoundaryY = GameObject.Find("UpperBoundary").GetComponent<Transform>().position.y;
        float lowerBoundaryY = GameObject.Find("LowerBoundary").GetComponent<Transform>().position.y;
        targetLineForFallTime = lowerBoundaryY;
        
    }

    private void Update()
    {


        if (gameObject.transform.position.y <= targetLineForFallTime) {
            GameObject.Find("GameController").GetComponent<GameController>().stopStopwatch();

            
        }
    }

}
