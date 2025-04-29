using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private movementData md;

    public bool moving = false;
    
    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (moving)
        {
            movement();
        }
        movementCheck();
    }

    public void setMoving(bool value)
    {
        moving = value;
    }
    private void movement() {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * md.moveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * md.moveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * md.moveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * md.moveSpeed * Time.deltaTime, Space.World);
        }

    }
    private void movementCheck()
    {
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            moving = false;
        }
        else
            moving = true;
    }
}
