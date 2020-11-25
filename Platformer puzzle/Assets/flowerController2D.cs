using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerController2D : MonoBehaviour
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
        if(other.name == "player")
        {
            GameObject.Find("SpikeBundle7").GetComponent<SpikeController2D>().flowerCount++;
            Destroy(gameObject);
        }
    }
}
