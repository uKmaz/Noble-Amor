using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateToCursor : MonoBehaviour
{
    Vector3 mousePos;
    Camera cam;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        rotateToCamera();
    }

    public void rotateToCamera()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,(Input.mousePosition.z-cam.transform.position.z)));
        rb.transform.eulerAngles = new Vector3(0,0,Mathf.Atan2((mousePos.y-transform.position.y),(mousePos.x-transform.position.x))*Mathf.Rad2Deg);
    }
}
