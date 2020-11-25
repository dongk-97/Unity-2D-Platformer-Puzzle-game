using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "player" && other.GetComponent<PlayerController2D>().currentStage == 9)
        {
            if(this.name == "btn_Left")
            {
                other.GetComponent<PlayerController2D>().inputLeft = false;
            }
            else if(this.name == "btn_Right")
            {
                other.GetComponent<PlayerController2D>().inputRight = false;
            }
            else if (this.name == "btn_Jump")
            {
                other.GetComponent<PlayerController2D>().inputJump = false;
            }
            gameObject.SetActive(false);
            other.GetComponent<PlayerController2D>().buttonCount++;
        }
    }
}
