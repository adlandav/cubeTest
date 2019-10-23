/*Written by: Alejandro Landaverde 
 *Date:       10/18/2019 
 *Issues:
    the direction on which the key strokes turn the cube changes
    when the cube is at certain angles.

    the movement of the cube isn't perfectly precise. Therefore,
    in rare cases, the cube may not snap to position.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    readonly float baseTime = 1;
    public int speed;
    float targetTime;
    float angle = 1.5f;
    bool start = false;
    Vector3 rotDir;

    private void Start()
    {
        targetTime = baseTime / speed;
        angle *= speed;
    }
    void Update()
    {
        CheckInput();
        DoRotation();
    }
    void CheckInput() {
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
    void DoRotation() {
        if (start)
        {
            targetTime -= Time.deltaTime;
            transform.RotateAround(Vector3.zero, rotDir, angle);
        }
        if (targetTime <= 0.0f)
        {
            targetTime = baseTime / speed;
            start = false;
        }
    }
}
