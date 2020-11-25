using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    GameObject player;
    int stageNumber, currentStage;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        currentStage = player.GetComponent<PlayerController2D>().currentStage;
        transform.position = new Vector3(19f * (currentStage - 1), 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        stageNumber = (int) ((player.gameObject.transform.position.x + 9.86f) / 19);
        Vector3 TargetPos = new Vector3(19f * stageNumber, 0, -10);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 2f);
    }
}
