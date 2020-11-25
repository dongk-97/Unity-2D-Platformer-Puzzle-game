using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasScript : MonoBehaviour
{
    GameObject LevelSelectUI, MainUI;
    public bool main = true, levelSelect = false;
    // Start is called before the first frame update
    void Start()
    {
        LevelSelectUI = GameObject.Find("LevelSelectUI");
        MainUI = GameObject.Find("MainUI");
    }
    void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    // Update is called once per frame
    void Update()
    {
        if(main)
        {
            LevelSelectUI.SetActive(false);
            MainUI.SetActive(true);
        }
        else if(levelSelect)
        {
            LevelSelectUI.SetActive(true);
            MainUI.SetActive(false);
        }
    }
}
