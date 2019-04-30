using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetSceneName : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Scene scene = SceneManager.GetActiveScene();
        var levelName = scene.name;
        int textLength = levelName.Length;
        var nameCut = levelName.Substring(5, textLength - 5);
        this.gameObject.GetComponent<Text>().text = "Level "+ GameManager.Instance.levelName;
        Debug.Log(nameCut);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
