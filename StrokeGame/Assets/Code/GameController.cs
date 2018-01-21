using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Camera cam;
    public GameObject ball;

    private float maxWidth;
    private float ballWidth;
    public float timeDelay = 2.0f;
    public float timeLeft = 50f;
    public GameObject basket;
    public float appleSpeed = 10;
    public Rect cameraRect;
    public bool next;



    // Use this for initialization
    void Start()
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

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        ballWidth = ball.GetComponent<Renderer>().bounds.size.x;
        timeDelay = 2.5f;
        maxWidth = targetWidth.x - ballWidth;
        next = true;
        StartCoroutine(Spawn());
    }

    private void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        GameObject.Find("TimeValue").GetComponent<Text>().text = Mathf.RoundToInt(timeLeft).ToString();
        //Debug.Log(CentPos());

    }
    private void Update()
    {
        Debug.Log("Next: " + next);
    }

    private bool CentPos()
    {
        if (basket.transform.position.x < 1.5 && basket.transform.position.x > -1.5)
        {
            GameObject.Find("Message").GetComponent<Text>().text = "";
            GameObject.Find("RightBoundary").GetComponent<SpriteRenderer>().color = Color.clear;
            GameObject.Find("LeftBoundary").GetComponent<SpriteRenderer>().color = Color.clear;
            return true;
        }
        else
        {
            GameObject.Find("Message").GetComponent<Text>().text = "Move your basket to the square in center";
            GameObject.Find("RightBoundary").GetComponent<SpriteRenderer>().color = Color.blue;
            GameObject.Find("LeftBoundary").GetComponent<SpriteRenderer>().color = Color.blue;
            return false;
                     
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);
        while (timeLeft > 0)
        {   
           /* if (next == false)
            {
                continue;
            }*/
            int x = Random.Range(1, 3);
            if (x == 1)
            {
                Vector3 spawnPosition = new Vector3(maxWidth, transform.position.y, 0.0f);
                Quaternion spawnRotation = Quaternion.identity;
                if (CentPos() == true )
                {

                    next = false;
                    Instantiate(ball, spawnPosition, spawnRotation);
                    
                    
                }
                yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
            }
            if (x==2)
            {
                Vector3 spawnPosition = new Vector3(-maxWidth, transform.position.y, 0.0f);
                Quaternion spawnRotation = Quaternion.identity;
                if (CentPos() == true)
                {
                    next = false;
                    Instantiate(ball, spawnPosition, spawnRotation);
                    
                   
                }
                yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
            }


        }
    }
}

