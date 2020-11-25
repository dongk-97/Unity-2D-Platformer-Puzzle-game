using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropController2D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            other.gameObject.GetComponent<PlayerController2D>().initialize();
            if(other.gameObject.GetComponent<PlayerController2D>().currentStage == 3)
            {
                GameObject.Find("chest3").GetComponent<chestController2D>().initialize();
            }
        }

        if(other.gameObject.name == "chest2")
        {
            GameObject.Find("SpikeBundle2").GetComponent<Animator>().Play("spike_hide");
        }
    }
}
