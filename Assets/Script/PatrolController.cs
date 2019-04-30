using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolController : MonoBehaviour {

    //public float speed = 1f;
    public float LeftLimit ;
    public float RightLimit;
    public float startDirection;
    public float speed;
    public float maxSpeed;
    public bool upDown;
    private float curMaxSpeed;
    private float startPos;
    private float curPos;
    private float diffPos;
    private float move;
    private float speedFactor;
    private bool directionRight;
    private Rigidbody rb;

    private float limitLeftPos;
    private float limitRightPos;
    // Use this for initialization
    void Start () {
        if (upDown == false)
        {
            startPos = this.transform.position.x;
            limitLeftPos = this.transform.position.x + LeftLimit;
            limitRightPos = this.transform.position.x + RightLimit;
            //Debug.Log("Start Pos LeftRight = " + startPos);
        }
        else if (upDown == true)
        {
            startPos = this.transform.position.y;
            limitLeftPos = this.transform.position.y + LeftLimit;
            limitRightPos = this.transform.position.y + RightLimit;
            //Debug.Log("Start Pos set UpDown = " + startPos);
        }

        speedFactor = startDirection;
        if (speedFactor > 0)
        {
            directionRight = true;
            speedFactor = speed;
            curMaxSpeed = maxSpeed;
        }
        else
        { 
            directionRight = false;
            speedFactor = speed * -1;
            curMaxSpeed = maxSpeed * -1;
        }
        rb = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (upDown == false)
        {
            curPos = this.transform.position.x;
            //Debug.Log("curPos LeftRight = "+ curPos);
        }
        else if (upDown == true)
        {
            curPos = this.transform.position.y;
            //Debug.Log("curPos UpDown = "+ curPos);
        }

        diffPos = curPos - startPos;
        Move(speedFactor);

        if (diffPos >= RightLimit)
        {
            speedFactor = speed*-1;
            //Debug.Log("--------------------Move Left");
            directionRight = false;
            curMaxSpeed = maxSpeed * -1;
        }

        else if (diffPos <= LeftLimit)
        {
            speedFactor = speed;
            //Debug.Log("----------------------Move Right");
            directionRight = true;
            curMaxSpeed = maxSpeed ;
        }

    }

    void Move(float speed)
    {
        //move = speed * Time.deltaTime;
        //this.transform.Translate(move, 0, 0);
        //Debug.Log("diffPos " + diffPos);
        //Debug.Log("move " + move);
        //Debug.Log("rb.velocity.x :" + rb.velocity.x);
        //if((diffPos>= ((RightLimit*8.5)/10) && directionRight) || (diffPos <= ((LeftLimit * 8.5) / 10) && !directionRight ))
        //    rb.AddForce(-speed*3, 0, 0);
        //else 

        if (upDown == false)
        {
            if ((diffPos >= RightLimit && !directionRight && rb.velocity.x >= curMaxSpeed) || (diffPos <= LeftLimit && directionRight && rb.velocity.x <= curMaxSpeed))
                rb.AddForce(speed * 30, 0, 0);
            else if ((rb.velocity.x >= curMaxSpeed && !directionRight) || (rb.velocity.x <= curMaxSpeed && directionRight))
                rb.AddForce(speed, 0, 0);
            else
                rb.AddForce((speed * 3) / 10 * -1, 0, 0);
            //Debug.Log("LeftRight Move");
        }
        else if (upDown == true)
        {
            if ((diffPos >= RightLimit && !directionRight && rb.velocity.y >= curMaxSpeed) || (diffPos <= LeftLimit && directionRight && rb.velocity.y <= curMaxSpeed))
                rb.AddForce(0, speed * 30, 0);
            else if ((rb.velocity.y >= curMaxSpeed && !directionRight) || (rb.velocity.y <= curMaxSpeed && directionRight))
                rb.AddForce(0, speed, 0);
            else
                rb.AddForce(0, (speed * 3) / 10 * -1, 0);
            //Debug.Log("UpDown Move");
        }
    }
}
