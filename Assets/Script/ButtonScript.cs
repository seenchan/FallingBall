using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

//this is BUTTON CONTROLLER

public class ButtonScript : MonoBehaviour {
    private Ray ray;
    private RaycastHit hit;
    private bool rayAlreadyHit;
    public TextMesh worldName;


    void Start()
    {
        //worldName = transform.GetComponent<TextMesh>();
    }
    public void RestartGame()
	{
        Scene SceneName = SceneManager.GetActiveScene();
        SceneManager.LoadScene(SceneName.name);
	}

	public void ExitGame()
	{
		Application.Quit ();
	}

	public void GoToMainMenu()
	{
        SceneManager.LoadScene("SelectWorld");
    }

    public void GoToLevel(string level)
    {
        SceneManager.LoadScene("level"+level);
    }

    public void GotoSelectLevel()
    {
        SceneManager.LoadScene("SelectLevel");
    }

    public void GoToTestLevel()
    {
        SceneManager.LoadScene("Test");
    }

    public void GoToSelectWorld()
    {
        SceneManager.LoadScene("Test");
    }
    public void GoToScene(string scene)
    {
        //Scene thisScene = SceneManager.GetActiveScene();
        //var sceneName = thisScene.name;
        //int textLength = sceneName.Length;
        //var shortenScene = sceneName.Substring(5, textLength - 5);

        //Debug.Log("goto scene " + shortenScene);
        SceneManager.LoadScene(scene);
    }
    public void BoxButtonClick()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            if (hit.transform.name.Equals(transform.name))
            {
                GameManager.Instance.worldName = worldName.text;
                GoToScene(hit.transform.name);
                Debug.Log(hit.transform.name);
                Debug.Log(worldName.text);
            }
        }
    }
    
    private void Update()
    {
        if (gameObject.tag == "ButtonLevel")
        {
            if (Input.GetMouseButtonUp(0))
            {
                BoxButtonClick();
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        string scene = coll.name + this.name;
        
        if (coll.name == "Glass")
        {
            if (int.Parse(this.name) > 5)
            {
                BackToTop(coll);
                return;

            }
        }
        else if (coll.name == "Steel")
        {
            if (int.Parse(this.name) > 5)
            {
                BackToTop(coll);
                return;
            }
        }  

        GameManager.Instance.levelName = this.name;
        GameManager.Instance.worldName = coll.name;
        GoToScene(scene);
        Debug.Log(coll.name);
        //Debug.Log(this.name);
    }


    void BackToTop(Collider coll)
    {

        RestartGame();
        GameManager.Instance.isWarningLevel = true;
    }
}
