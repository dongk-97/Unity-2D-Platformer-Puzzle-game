using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestController2D : MonoBehaviour
{
    Animator animator;
    public bool flag;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        flag = true;
        if(this.name == "chestMain" && !PlayerPrefs.HasKey("chestMain"))
        {
            gameObject.SetActive(false);
        }
        else if(this.name == "chestMain" && PlayerPrefs.GetInt("chestMain") == 1)
        {
            animator.Play("chest_run");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.CompareTag("player") && flag)
        {
            animator.Play("chest_run");
            if(other.GetComponent<PlayerController2D>().currentStage != 3)
            {
                switch(this.name)
                {
                    case "chest1":
                        GameObject.Find("SpikeBundle1").GetComponent<Animator>().Play("spike_hide");
                        break;
                    case "chest6":
                        GameObject.Find("SpikeBundle6").GetComponent<Animator>().Play("spike_hide");
                        break;
                    case "chest13":
                        GameObject.Find("SpikeBundle13").GetComponent<Animator>().Play("spike_hide");
                        break;
                    case "chestMain":
                        PlayerPrefs.SetInt("chestMain", 1);
                        break;
                }
                
            }
            flag = false;
        }
    }

    public void initialize()
    {
        flag = true;
        animator.Play("chest_idle");
    }
}
