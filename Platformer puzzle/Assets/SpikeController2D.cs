using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController2D : MonoBehaviour
{
    float volume_bgm;
    float volume_sfx;
    public int flowerCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        volume_bgm = GameObject.Find("SoundManager").GetComponent<volumeValueController>().musicVolume_bgm;
        volume_sfx = GameObject.Find("SoundManager").GetComponent<volumeValueController>().musicVolume_sfx;
        if (this.name == "SpikeBundle5")
        {
            if (volume_bgm==0 && volume_sfx==0)
            {
                GetComponent<Animator>().Play("spike_hide");
            }
            else
            {
                GetComponent<Animator>().Play("spike_idle");
            }
        }else if(this.name == "SpikeBundle7")
        {
            if (flowerCount == 7)
            {
                GetComponent<Animator>().Play("spike_hide");
            }
        }




    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            if(other.GetComponent<PlayerController2D>().currentStage != 3)
            {
                if(this.name != "SpikeBundle3")
                {
                    other.gameObject.GetComponent<PlayerController2D>().initialize();
                }
            }
            else if(!GameObject.Find("chest3").GetComponent<chestController2D>().flag)
            {
                other.gameObject.GetComponent<PlayerController2D>().initialize();
                GameObject.Find("chest3").GetComponent<chestController2D>().initialize();
            }
        }
    }
}
