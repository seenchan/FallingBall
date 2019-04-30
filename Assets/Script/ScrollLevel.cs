using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollLevel : MonoBehaviour {

    public GameObject levelTube;
    public Slider slider;
    public float slide;
    public float offset;
    float startY;
    float startZ;
    public GameObject textWarning;
    // Use this for initialization
    void Start () {
        startY = levelTube.transform.position.y;
        startZ = levelTube.transform.position.z;
        levelTube.transform.position = new Vector3(0, startY, startZ);
        if (GameManager.Instance.isWarningLevel)
        {
            
            textWarning.SetActive(true);
            
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Scroll()
    {
        levelTube.transform.position = new Vector3((-slider.value*slide)+offset, startY, startZ);
        Debug.Log(slider.value);
    }
}
