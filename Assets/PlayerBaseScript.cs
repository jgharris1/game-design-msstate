using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseScript : MonoBehaviour
{

    public entitybasebehavior Selfdata;
    public Vector3 playerDir;
    // Start is called before the first frame update
    void Start()
    {
        playerDir = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        playerDir.Set(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            playerDir.Set(playerDir.x, playerDir.y + 1, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerDir.Set(playerDir.x - 1, playerDir.y, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerDir.Set(playerDir.x, playerDir.y - 1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerDir.Set(playerDir.x + 1, playerDir.y, 0);
        }
        Selfdata.targetPos.Set(transform.position.x + playerDir.x, transform.position.y + playerDir.y, 0);
    }
}
