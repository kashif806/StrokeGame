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
        float speed;
        Debug.Log(gameObject.GetComponent<Rigidbody2D>().mass);
        if (GameObject.Find("GameController").GetComponent<GameController>().appleSpeed <= 0.1)
        {
            speed = 0.1f;
            //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            GameObject.Find("SpeedValue").GetComponent<Text>().text = speed.ToString();
            
        }
        else
        {
            speed = GameObject.Find("GameController").GetComponent<GameController>().appleSpeed;
           // gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            GameObject.Find("SpeedValue").GetComponent<Text>().text = speed.ToString();
            
            
        }
    }

   

}
