using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearScript : MonoBehaviour
{
    GameObject btn_Right, btn_Left, btn_Jump;
    Vector2 gravity;
    int triggerNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        gravity = Physics2D.gravity;
        int currentStage = 1;
        if (PlayerPrefs.HasKey("currentStage"))
        {
            currentStage = PlayerPrefs.GetInt("currentStage");
        }
        else if(PlayerPrefs.HasKey("highestStage"))
        {
            currentStage = PlayerPrefs.GetInt("highestStage");
        }
        
        Int32.TryParse(this.name.Substring(19), out triggerNumber);
        if(triggerNumber >= currentStage)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<CapsuleCollider2D>().enabled = true;
        }
        if (this.name == "Stage Clear Trigger4" && currentStage != 4)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else if(this.name == "Stage Clear Trigger3" && currentStage == 4)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
        btn_Right = GameObject.Find("btn_Right");
        btn_Left = GameObject.Find("btn_Left");
        btn_Jump = GameObject.Find("btn_Jump");

        if(this.name == "Stage Clear Trigger7" && currentStage == 8)
        {
            Invoke("disableRightBtn", 0.5f);
        }
        else if(this.name == "Stage Clear Trigger13" && currentStage == 14)
        {
            if(PlayerPrefs.HasKey("chestMain") && PlayerPrefs.GetInt("chestMain") == 1)
            {
                GameObject.Find("SpikeBundle14").GetComponent<Animator>().Play("spike_hide");
            }
            else
            {
                PlayerPrefs.SetInt("chestMain", 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void disableRightBtn()
    {
        GameObject.Find("player").GetComponent<PlayerController2D>().inputRight = false;
        btn_Right.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "player")
        {
            // Set current stage
            other.GetComponent<PlayerController2D>().currentStage += 1;
            int currentStage = other.gameObject.GetComponent<PlayerController2D>().currentStage;

            // Set highest stage
            int highestStage = PlayerPrefs.GetInt("highestStage");
            if(currentStage > highestStage)
            {
                PlayerPrefs.SetInt("highestStage", currentStage);
            }

            // Modify player's pos_init and current position
            other.GetComponent<PlayerController2D>().pos_init = new Vector3(-8.17f+19*(currentStage-1), other.transform.position.y, 0);
            other.GetComponent<PlayerController2D>().initialize();

            // enable CapsuleCollider
            GetComponent<CapsuleCollider2D>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = false;
            if(currentStage == 4)
            {
                GetComponent<CapsuleCollider2D>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                GameObject.Find("Stage Clear Trigger4").GetComponent<BoxCollider2D>().enabled = true;
            }

            // Disable and enable right button for stage 8
            if(this.name == "Stage Clear Trigger7")
            {
                other.gameObject.GetComponent<PlayerController2D>().inputRight = false;
                btn_Right.SetActive(false);
            }
            else if(this.name == "Stage Clear Trigger8")
            {
                btn_Right.SetActive(true);
            }

            // Enable buttons for stage 9
            else if(this.name == "Stage Clear Trigger9")
            {
                Physics2D.gravity = gravity;
                btn_Right.SetActive(true);
                btn_Left.SetActive(true);
                btn_Jump.SetActive(true);
                if (PlayerPrefs.GetInt("highestStage") == 10)
                {
                    PlayerPrefs.SetInt("highestStage", 11);
                    print(11);
                }
            }

            else if(this.name == "Stage Clear Trigger13")
            {
                PlayerPrefs.SetInt("chestMain", 0);
            }
            else if(this.name == "Stage Clear Trigger14")
            {
                PlayerPrefs.DeleteKey("chestMain");
            }
        }
    }
}
