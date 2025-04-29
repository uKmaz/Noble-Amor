using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowPlayer : MonoBehaviour
{
    GameObject player;
    PlayerMovement pm;
    bool followPlayer = true;
    Camera cam;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");   
        cam = Camera.main;
        pm = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            followPlayer = false;
            pm.setMoving(false);
        }
        else
        {
            followPlayer = true;
        }
        if (followPlayer)
        {
            camFollowPlayer();
        }
        else
        {
            lookAhead();
        }
    }

    public void setFollowPlayer(bool value)
    {
        followPlayer = value;
    }
    void camFollowPlayer()
    {
        Vector3 newPos = new Vector3(player.transform.position.x,player.transform.position.y,this.transform.position.z);
        this.transform.position = newPos;
    }

    void lookAhead()
    {
        Vector3 camPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        camPos.z = -10;
        Vector3 dir = camPos-this.transform.position;
        if(player.GetComponent<SpriteRenderer>().isVisible ==true)
        {
            transform.Translate(dir * 2 * Time.deltaTime);
        }
    }
}
