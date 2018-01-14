using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{

    //public float appleSpeed = 5f;
    //public Vector3 applePosn;
  

    void Start()
    {
        //float speed;
        //Debug.Log(gameObject.GetComponent<Rigidbody2D>().mass);
        var gameController = GameObject.Find("GameController").GetComponent<GameController>();
        if (gameController.appleGravity >= 0.5) {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = gameController.appleGravity;
        }

        //if (gameController.appleGravity < 0.5)
        //{
        //    speed = 0.5f;
        //    //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        //    //GameObject.Find("SpeedValue").GetComponent<Text>().text = speed.ToString();

        //}
        //else
        //{
        //    speed = 
        //    gameObject.GetComponent<Rigidbody2D>().gravityScale = gameController.appleGravity;
        //    // gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        //    //GameObject.Find("SpeedValue").GetComponent<Text>().text = speed.ToString();


        //}
    }

   

}
