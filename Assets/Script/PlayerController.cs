using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

    //public float crashTolerance = 0.3f;
    private Rigidbody playerRB;
    //private checkSpeed;
    Vector3 lastPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody>();
        //GameManager.Instance.crashTolerance = crashTolerance;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        CheckSpeed();
    }

    void CheckSpeed()
    {
        //speed = (transform.position - lastPosition).magnitude;
        //lastPosition = transform.position;
        //playerRB.velocity.;
        GameManager.Instance.crashSpeed = playerRB.velocity.sqrMagnitude;
        //Debug.Log("Speed " + speed);
    }

    void OnCollisionEnter (Collision col)
    {
        if (GameManager.Instance.crashSpeed > GameManager.Instance.crashTolerance && this.name == "PlayerGlass")
        {
            Scene SceneName = SceneManager.GetActiveScene();
            SceneManager.LoadScene(SceneName.name);
        }
    }
}
