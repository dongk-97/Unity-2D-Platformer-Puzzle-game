using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    Vector2 BackgroundPos;
    bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        BackgroundPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
            SwipeTouch();
            SwipeClick();


    }

    public void SwipeTouch()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe left
                if (currentSwipe.x < -100 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Ray raycast = Camera.main.ScreenPointToRay(firstPressPos);
                    RaycastHit raycastHit;
                    if (Physics.Raycast(raycast, out raycastHit) && raycastHit.collider.name == "Background")
                    {
                        GameObject player = GameObject.Find("player");
                        // Set current stage
                        player.GetComponent<PlayerController2D>().currentStage += 1;
                        int currentStage = player.gameObject.GetComponent<PlayerController2D>().currentStage;

                        // Set highest stage
                        int highestStage = PlayerPrefs.GetInt("highestStage");
                        if (currentStage > highestStage)
                        {
                            PlayerPrefs.SetInt("highestStage", currentStage);
                        }

                        // Modify player's pos_init, current position, and color
                        player.GetComponent<PlayerController2D>().pos_init = new Vector3(-8.17f + 19 * (currentStage - 1), player.transform.position.y, 0);
                        player.GetComponent<PlayerController2D>().initialize();
                        player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.25f + 0.25f * (currentStage - 1));
                        Debug.Log("left swipe");
                    }
                }
            }
        }
    }

    public void SwipeClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            float xDiff = secondPressPos.x - firstPressPos.x;

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe left
            if (xDiff < -160 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Ray raycast = Camera.main.ScreenPointToRay(firstPressPos);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit) && raycastHit.collider.name == "Background" && !flag)
                {
                    GameObject player = GameObject.Find("player");
                    // Set current stage
                    player.GetComponent<PlayerController2D>().currentStage += 1;
                    int currentStage = player.gameObject.GetComponent<PlayerController2D>().currentStage;

                    // Set highest stage
                    int highestStage = PlayerPrefs.GetInt("highestStage");
                    if (currentStage > highestStage)
                    {
                        PlayerPrefs.SetInt("highestStage", currentStage);
                    }

                    // Modify player's pos_init, current position, and color
                    player.GetComponent<PlayerController2D>().pos_init = new Vector3(-8.17f + 19 * (currentStage - 1), player.transform.position.y, 0);
                    player.GetComponent<PlayerController2D>().initialize();
                    player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.25f + 0.25f * (currentStage - 1));
                    Debug.Log("left swipe");
                    flag = true;
                }
            }
        }
    }
}
