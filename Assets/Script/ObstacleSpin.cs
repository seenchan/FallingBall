using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpin : MonoBehaviour {

    public float rotationSpeed;
    //private float rotate;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().AddTorque(0, 0, rotationSpeed);

        //rotate = rotationSpeed * Time.deltaTime;
        //this.transform.Rotate(0, 0, rotate);
    }

}
