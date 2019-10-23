/*Written by: Alejandro Landaverde 
 *Date:       10/23/2019 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift : MonoBehaviour
{
    public int speed;
    bool start = false;
    Vector3 rotDir;
    float counter = 0;

    void Update()
    {
        CheckInput();
        DoRotation();
    }
    void CheckInput()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if (!start)
            {
                rotDir = Vector3.left;
                start = true;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if (!start)
            {
                rotDir = Vector3.right;
                start = true;
            }
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (!start)
            {
                rotDir = Vector3.back;
                start = true;
            }
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            if (!start)
            {
                rotDir = Vector3.up;
                start = true;
            }
        }
        else if (Input.GetKey(KeyCode.E))
        {
            if (!start)
            {
                rotDir = Vector3.down;
                start = true;
            }
        }
        else
        {
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                if (!start)
                {
                    rotDir = Vector3.forward;
                    start = true;
                }
            }
        }
    }
    void DoRotation()
    {
        float tmp;
        float overshot;

        if (counter >= 90)
        {
            overshot = counter - 90;
            transform.RotateAround(Vector3.zero, rotDir, -overshot);
            counter = 0;
            start = false;
        }
        else
        {
            if (start)
            {
                tmp = 90 * Time.deltaTime * speed;
                counter += tmp;
                transform.RotateAround(Vector3.zero, rotDir, tmp);
            }
        }
    }
}
