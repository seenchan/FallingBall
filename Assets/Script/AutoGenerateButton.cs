using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGenerateButton : MonoBehaviour {

    public GameObject LevelButton;
    public float numObjects = 10f;
    //public float rad = 0.23f;
    //private float ang = 0f;
    public float gridX = 5f;
    public float gridY = 10f;
    public float spacing = 2f;
    public float check = 1f;



    // Use this for initialization
    void Start () {
        //rad = numObjects * rad;
        //GenerateButtonsCircular();
        //Debug.Log("rad: " + rad);
        //Debug.Log("width: "+Screen.width);
        //Debug.Log("height: " + Screen.height);
        GenerateButtons();
    }

    //Update is called once per frame

    void Update () {
		
	}

    public void GenerateButtons()
    {
        for (int y = 0; y<gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                if (check <= numObjects)
                {
                    Vector3 pos = new Vector3(x, y, 0) * spacing;
                    var newLevel = (GameObject) Instantiate(LevelButton, pos, Quaternion.identity);
                    var newLevelname = "Level" + check;
                    newLevel.name = newLevelname;
                    check++;
                }
            }
        }
    }

    //void GenerateButtonsCircular()
    //{
    //    Vector3 center = transform.position;
    //    float angPos = 360 / numObjects;
    //    Debug.Log(angPos);
    //    for (int i = 0; i<numObjects; i++)
    //    {
    //        ang = ang + angPos;
    //        Debug.Log("objPos: " + ang);
    //        Vector3 pos = RandomCircle(center, rad);
    //        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
    //        Instantiate(LevelButton, pos, rot);
    //    }
    //}

    //Vector3 RandomCircle(Vector3 center, float radius)
    //{
    //    Vector3 pos;
    //    pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
    //    pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
    //    //pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
    //    pos.z = center.z;
    //    return pos;
    //}
}
