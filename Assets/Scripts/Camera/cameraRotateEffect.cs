using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotateEffect : MonoBehaviour
{
    PlayerMovement pm;
    float mod = 0.1f;
    float zVal = 0.0f;
    
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if(pm.moving)
        {
            Vector3 rot = new Vector3(0, 0, zVal);
            this.transform.eulerAngles = rot;

                zVal += mod;
            if(transform.eulerAngles.z >= 5.5f && transform.eulerAngles.z < 10.0f)
            {
                mod = -0.1f;
            }
            else if(transform.eulerAngles.z <355.0f && transform.eulerAngles.z > 350.0f)
            {
                mod = 0.1f;
            }
        }
    }
}
