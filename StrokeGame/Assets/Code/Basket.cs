using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{


    public Camera cam;
    public float maxWidth;
    public float basketSpeed = 1;
    public Vector3 targetPosition;
    public Rect cameraRect;
    public Vector3 basketSize;
    public GameObject BasketCatcher;
    public GameObject UpperBoundary;
    public GameObject LowerBoundary;
    public System.DateTime endTime;


    private void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        var bottomLeft = cam.ScreenToWorldPoint(Vector3.zero);
        var topRight = cam.ScreenToWorldPoint(new Vector3(
            cam.pixelWidth, cam.pixelHeight));
        cameraRect = new Rect(
            bottomLeft.x,
            bottomLeft.y,
            topRight.x - bottomLeft.x,
            topRight.y - bottomLeft.y);
        basketSize = GetComponent<Renderer>().bounds.size;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 TargetWidth = cam.ScreenToWorldPoint(upperCorner);
        
    }

    private System.DateTime getTime()
    {
        return System.DateTime.Now;
    }   


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rawPostion = new Vector3(
            Mathf.Clamp(mousePosition.x, cameraRect.xMin + (basketSize.x / 2), cameraRect.xMax - (basketSize.x / 2)),
            Mathf.Clamp(mousePosition.y, cameraRect.yMin + (basketSize.y / 2), (cameraRect.yMax - (basketSize.y / 2))),
            0);

        targetPosition = new Vector3(rawPostion.x, rawPostion.y, 0);
        gameObject.transform.position = targetPosition;

        float basketUpper = targetPosition.y + (basketSize.y / 2);
        float basketLower = targetPosition.y - (basketSize.y / 2);


        if (basketUpper >= GameObject.Find("UpperBoundary").transform.position.y || basketLower <= GameObject.Find("LowerBoundary").transform.position.y)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.GetComponent<EdgeCollider2D>().enabled = false;
            GameObject.Find("BasketCatcher").GetComponent<EdgeCollider2D>().enabled = false;
            GameObject.Find("BasketCatcher").GetComponent<EdgeCollider2D>().isTrigger = false;
        }
        else {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            gameObject.GetComponent<EdgeCollider2D>().enabled = true;
            GameObject.Find("BasketCatcher").GetComponent<EdgeCollider2D>().enabled = true;
            GameObject.Find("BasketCatcher").GetComponent<EdgeCollider2D>().isTrigger = true;
        }

        
        GameObject.Find("ScoreNo").GetComponent<Text>().text = BasketCatcher.GetComponent<BasketCatcher>().GetScore().ToString();

        if (GameObject.Find("Apple(Clone)") == true)
        {

            if (GameObject.Find("BasketCatcher").GetComponent<BasketCatcher>().caught == true)
            {
                endTime = GameObject.Find("BasketCatcher").GetComponent<BasketCatcher>().endTime;
                TimeSpan ts = (GameObject.Find("GameController").GetComponent<GameController>().startTime) - endTime;
                Debug.Log("total time" + ts.ToString());
                GameObject.Find("BasketCatcher").GetComponent<BasketCatcher>().caught = false;
            }

            else if (GameObject.Find("Apple(Clone)").transform.position.y < -4.2 && GameObject.Find("Apple(Clone)").transform.position.y > -4.35)
            {

                 endTime = getTime();
                 //Debug.Log("END TM: " + endTime);
                 
                TimeSpan ts = (GameObject.Find("GameController").GetComponent<GameController>().startTime) - endTime;
                Debug.Log("total time" + ts.ToString());
                
            }
        }
        





    }
}
