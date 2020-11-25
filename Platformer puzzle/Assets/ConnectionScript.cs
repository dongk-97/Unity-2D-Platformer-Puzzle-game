using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionScript : MonoBehaviour
{
    int currentStage;
    // Start is called before the first frame update
    NetworkReachability initial;
    NetworkReachability curr;
    bool flag_first=true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentStage = GameObject.Find("player").GetComponent<PlayerController2D>().currentStage;
        if (currentStage == 13)
        {
            if (flag_first)
            {
                initial = Application.internetReachability;
                GameObject.Find("Managers").GetComponent<UIButtonManager>().connection = false;
                GameObject.Find("player").GetComponent<PlayerController2D>().inputLeft = false;
                GameObject.Find("player").GetComponent<PlayerController2D>().inputRight = false;
                GameObject.Find("player").GetComponent<PlayerController2D>().inputJump = false;
                flag_first = false;
            }
            if (initial == NetworkReachability.NotReachable)
            {
                if(Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork 
                    || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
                {
                    GameObject.Find("Managers").GetComponent<UIButtonManager>().connection = true;
                }
            }


            else if (initial == NetworkReachability.ReachableViaCarrierDataNetwork || initial == NetworkReachability.ReachableViaLocalAreaNetwork)
            {
                if(Application.internetReachability == NetworkReachability.NotReachable)
                {
                    initial = NetworkReachability.NotReachable;
                }
            }

        }

    }
}
