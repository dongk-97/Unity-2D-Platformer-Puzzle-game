using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("player");
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if (this.transform.position.x - 0.65 < Input.GetTouch(0).position.x && Input.GetTouch(0).position.x < this.transform.position.x + 0.65 &&
                this.transform.position.y - 1 < Input.GetTouch(0).position.y && Input.GetTouch(0).position.y < this.transform.position.y + 1 &&
                this.transform.position.x - 0.65 < player.transform.position.x && player.transform.position.x < this.transform.position.x + 0.65 &&
                this.transform.position.y - 1 < player.transform.position.y && player.transform.position.y < this.transform.position.y + 1)
            {
                switch (this.name)
                {
                    case "Continue Door":
                        if(PlayerPrefs.HasKey("currentStage"))
                        {
                            PlayerPrefs.DeleteKey("currentStage");
                        }
                        SceneManager.LoadScene("Platformerpuzzle");
                        break;
                    case "Level Select Door":
                        GameObject.Find("Canvas").GetComponent<canvasScript>().main = false;
                        GameObject.Find("Canvas").GetComponent<canvasScript>().levelSelect = true;
                        GameObject camera = GameObject.Find("Main Camera");
                        camera.transform.position = new Vector3(0, 13, -10);
                        break;
                    case "Exit Door":
                        Application.Quit();
                        break;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        GameObject player = GameObject.Find("player");
        if (this.transform.position.x - 0.65 < player.transform.position.x && player.transform.position.x < this.transform.position.x + 0.65 &&
            this.transform.position.y - 1 < player.transform.position.y && player.transform.position.y < this.transform.position.y + 1)
        {
            switch (this.name)
            {
                case "Continue Door":
                    if (PlayerPrefs.HasKey("currentStage"))
                    {
                        PlayerPrefs.DeleteKey("currentStage");
                    }
                    SceneManager.LoadScene("Platformerpuzzle");
                    break;
                case "Level Select Door":
                    GameObject.Find("Canvas").GetComponent<canvasScript>().main = false;
                    GameObject.Find("Canvas").GetComponent<canvasScript>().levelSelect = true;
                    GameObject camera = GameObject.Find("Main Camera");
                    camera.transform.position = new Vector3(0, 13, -10);
                    break;
                case "Exit Door":
                    Application.Quit();
                    break;
            }
        }
    }
}
