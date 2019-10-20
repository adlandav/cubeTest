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
    float x = 0;
    float y = 0;
    float z = 0;
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
                rotDir = new Vector3(-angle, 0, 0);
                start = true;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if (!start)
            {
                rotDir = new Vector3(angle, 0, 0);
                start = true;
            }
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (!start)
            {
                rotDir = new Vector3(0, 0, -angle);
                start = true;
            }
        }
        else
        {
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                if (!start)
                {
                    rotDir = new Vector3(0, 0, angle);
                    start = true;
                }
            }
        }
    }
    void DoRotation() {
        if (start)
        {
            targetTime -= Time.deltaTime;
            x += rotDir.x;
            y += rotDir.y;
            z += rotDir.z;
            transform.rotation = Quaternion.Euler(x, y, z);
        }
        if (targetTime <= 0.0f)
        {
            //Debug.LogError(x);
            targetTime = baseTime / speed;
            start = false;
        }
    }
}
