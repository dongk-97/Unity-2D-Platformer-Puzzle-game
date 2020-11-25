using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    int highestStage, buttonNumber;
    public Sprite lockedImage;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("highestStage"))
        {
            highestStage = PlayerPrefs.GetInt("highestStage");
        }
        else
        {
            highestStage = 1;
        }

        Int32.TryParse(this.name.Substring(5), out buttonNumber);
        if(buttonNumber > highestStage)
        {
            GetComponent<Image>().sprite = lockedImage;
            GetComponentInChildren<Text>().enabled = false;
            GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadStage()
    {
        PlayerPrefs.SetInt("currentStage", buttonNumber);
        SceneManager.LoadScene("Platformerpuzzle");
    }
}
