using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : Enemy
{
    private int direction; // Variable used to determine left or right movement

    // Moves left or right depending on the value of variable "direction"
    public virtual void Move()
    {
        Vector3 tempPos = pos;
        if (direction == 1)
        {
            tempPos.x += speed * Time.deltaTime;
        }
        else
        {
            tempPos.x -= speed * Time.deltaTime;
        }
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Randomly sets the value of direction as either 1 or 2
        direction = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

}
