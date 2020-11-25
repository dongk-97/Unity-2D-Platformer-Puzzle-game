using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonManager : MonoBehaviour
{
    GameObject player, pausePanel;
    GameObject[] sliders;
    PlayerController2D playerScript;
    private bool isPause = false, isClicked = false;
    public bool connection = true;
    Vector2 gravity;

    public void Init()
    {
        player = GameObject.Find("player");
        playerScript = player.GetComponent<PlayerController2D>();
        sliders = GameObject.FindGameObjectsWithTag("Slider");
        sliders[0].SetActive(false);
        sliders[1].SetActive(false);
        pausePanel = GameObject.Find("Panel");
        pausePanel.SetActive(false);
        gravity = Physics2D.gravity;
    }

    public void LeftDown()
    {
        if (connection)
        {
            Debug.Log("Left");
            playerScript.inputLeft = true;
        }


    }

    public void LeftUp()
    {
        if (connection)
        {
            Debug.Log("Left");
            playerScript.inputLeft = false;

        }


    }


    public void RightDown()
    {
        if (connection)
        {
            Debug.Log("Right");
            playerScript.inputRight = true;
        }
    }

    public void RightUp()
    {
        if (connection)
        {
            Debug.Log("Right");
            playerScript.inputRight = false;
        }


    }

    public void JumpDown()
    {
        if (connection)
        {
            Debug.Log("Jump");
            playerScript.inputJump = true;
        }
    }

    public void JumpUp()
    {
        if (connection)
        {
            Debug.Log("Jump");
            playerScript.inputJump = false;
        }
    }


    public void Pause()
    {
        int stageNumber = playerScript.currentStage;
        if(!isPause && stageNumber != 8)
        {
            Time.timeScale = 0;
        }
        isPause = !isPause;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        int stageNumber = playerScript.currentStage;
        if (isPause)
        {
            Time.timeScale = 1.0f;
            if(stageNumber != 8)
            {
                isPause = !isPause;
                pausePanel.SetActive(false);
            }
        }
    }

    public void Menu()
    {
        Time.timeScale = 1.0f;
        Physics2D.gravity = gravity;
        SceneManager.LoadScene("MainMenu");
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainMenu");
    }

    public void Sound()
    {
        if(!isClicked)
        {
            sliders[0].SetActive(true);
            sliders[1].SetActive(true);
        }
        else
        {
            sliders[0].SetActive(false);
            sliders[1].SetActive(false);
        }
        isClicked = !isClicked;
    }

    public void Retry()
    {
        int stageNumber = playerScript.currentStage;
        PlayerPrefs.SetInt("currentStage", stageNumber);
        Physics2D.gravity = gravity;
        SceneManager.LoadScene("Platformerpuzzle");

    }

    public void Back()
    {
        GameObject.Find("Canvas").GetComponent<canvasScript>().main = true;
        GameObject.Find("Canvas").GetComponent<canvasScript>().levelSelect = false;
        GameObject.Find("Main Camera").transform.position = new Vector3(0, 0, -10);
    }
}
