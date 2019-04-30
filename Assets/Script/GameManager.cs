using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

    protected override void Init()
    {
    }

    public string worldName;
    public string levelName;
    public float crashSpeed;
    public float crashTolerance;
    public bool isWarningLevel;

    // Use this for initialization
    void Start () {
        Debug.Log("called");
	}
	
	// Update is called once per frame
	void Update () {
       
	}
}
