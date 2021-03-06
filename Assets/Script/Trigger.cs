using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Trigger : MonoBehaviour {

	private float time;
	private bool IsStart;
	private int textTime;
	public Text timerText;

	void Start () {
		IsStart = false;
		time = 0;

	}

	void FixedUpdate ()
	{
		StartTimer ();
	}

	void OnTriggerEnter(Collider collider)
	{
        if (collider.tag == "Player" && transform.tag == "Finish")
        {
            IsStart = true;
            //Debug.Log("Finish");
        }
        else if (collider.tag == "Player" && transform.tag == "Restart")
        {
            PlayerDead();
            //Debug.Log("Die");
        }
		
	}

	void StartTimer()
	{
		if (IsStart) {
			time += Time.deltaTime;
			if (time > textTime)
			{
				textTime = (int)Mathf.Floor (time);
                NextLevel();
			}
		}
	}

    void NextLevel()
    {
        int next;
        string worldName;

        next = (int.Parse(GameManager.Instance.levelName) + 1);
        worldName = GameManager.Instance.worldName;

        GameManager.Instance.levelName = (int.Parse(GameManager.Instance.levelName) + 1).ToString();

        Debug.Log("level name = " + GameManager.Instance.levelName);
        Debug.Log("next = " + next);

        if (next <= 10)
        {
            SceneManager.LoadScene(worldName + next);
        }
        else
        {
            SceneManager.LoadScene("SelectWorld");
        }
    }

    public void PlayerDead()
    {
        Scene SceneName = SceneManager.GetActiveScene();
        SceneManager.LoadScene(SceneName.name);
    }
}
