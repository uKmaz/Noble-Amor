using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData pd;

    public bool moving = false;
    

    private void Update()
    {
        movement();
    }

    public void setMoving(bool value)
    {
        moving = value;
    }
    private void movement() {

        movementCheck();
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * pd.moveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * pd.moveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * pd.moveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * pd.moveSpeed * Time.deltaTime, Space.World);
        }

    }
    private void movementCheck()
    {
        moving =
          Input.GetKey(KeyCode.W) ||
          Input.GetKey(KeyCode.S) ||
          Input.GetKey(KeyCode.A) ||
          Input.GetKey(KeyCode.D);
    }
}
