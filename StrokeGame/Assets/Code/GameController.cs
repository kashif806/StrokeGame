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
    //public float timeLeft = 50f;
    public GameObject basket;
    public float appleSpeed = 10;
    public float appleGravity = 1f;
    public Rect cameraRect;
    public bool next;
    public System.DateTime startTime;
    public float timer;
    int trailNo = 0;
    



    // Use this for initialization
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        appleGravity = 1f;
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
		GameObject.Find("Message").GetComponent<Text>().text = "";
        StartCoroutine(Spawn());
    }

    //private System.DateTime getTime()
   // {
   //     return System.DateTime.Now;
  //  }
    private void FixedUpdate()
    {
        //timeLeft -= Time.deltaTime;
        GameObject.Find("TrailNo").GetComponent<Text>().text = trailNo.ToString();
        //Debug.Log(GameObject.Find("Apple(Clone)").transform.position.y);
               
    }

    private bool CentPos()
    {
        if (basket.transform.position.x < 1.5 
            && basket.transform.position.x > -1.5
            && GameObject.Find("BasketCatcher").GetComponent<EdgeCollider2D>().enabled == true
            )
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
        
        while (true)
        {
            
            int x = 1;
			switch (Random.Range (1, 3)) 
			{
				case 1:
					x = 1;
					break;
			default:
				x = -1;
				break;
			}

			Vector3 screenTop = cam.ScreenToWorldPoint (new Vector3 (0.0f, Screen.height, 0.0f));
			Vector3 spawnPosition = new Vector3(x * maxWidth, screenTop.y, 0.0f);
			Quaternion spawnRotation = Quaternion.identity;
			if (next && CentPos())
			{
                trailNo += 1;
               
                next = false;
				Instantiate(ball, spawnPosition, spawnRotation);
                timer += Time.time;
                
               // startTime = getTime();
                //Debug.Log("Start: " + startTime.ToString());
                yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
			}

            yield return new WaitForSeconds(0.5f);
        }

    }
}

