using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTextChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
        changeLevelText();
    }
	
	// Update is called once per frame
	void Update () {
        //changeLevelText();
	}

    public void changeLevelText()
    {
        var levelText = gameObject.transform.GetChild(0);
        var buttonName = gameObject.transform.name;
        int textLength = buttonName.Length;
        var buttonNameCut = buttonName.Substring(5, textLength - 5);
        levelText.gameObject.GetComponent<TextMesh>().text = buttonNameCut;
        GameManager.Instance.levelName = buttonNameCut;
    }
}
