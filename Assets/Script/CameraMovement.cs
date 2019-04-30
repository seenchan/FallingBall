using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float cameraSpeed = 13f;
    public int scrollSpeed;
    float cameraLimit;

    // Use this for initialization
    void Start ()
    {
        cameraLimit = 1f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveCamera();
        CameraScroll();
    }

    void MoveCamera()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(new Vector3(0, cameraSpeed * Time.deltaTime, 0));
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(new Vector3(0, -cameraSpeed * Time.deltaTime, 0));
        }
    }

    void CameraScroll()
    {
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        cameraLimit = GetComponent<Camera>().transform.position.y;
        float upLimit = 50f;
        float downLimit = 3.78f;

        //if (mouseWheel > 0.3f)
        //{
        //    mouseWheel = 0.3f;
        //}
        //else if (mouseWheel < -0.3)
        //{
        //    mouseWheel = -0.3f;
        //}

        if (cameraLimit < downLimit)
        {
            Debug.Log("limit bawah");
            this.transform.Translate(new Vector3(0, cameraSpeed * Time.deltaTime, 0));
        }

        else if (cameraLimit >= downLimit)
        {
            transform.Translate(Vector3.up * mouseWheel);
        }

        if (cameraLimit > upLimit)
        {
            Debug.Log("limit atas");
            this.transform.Translate(new Vector3(0, -cameraSpeed * Time.deltaTime, 0));
        }
    }
}
