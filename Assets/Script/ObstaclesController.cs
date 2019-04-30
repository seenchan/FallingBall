using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{

    private Ray ray;
    private RaycastHit hit;
    ButtonScript call;

    // Use this for initialization
    void Start()
    {
        call = new ButtonScript();
    }

    // Update is called once per frame
    void Update()
    {
        ClickAndDestroy();
    }

    void ClickAndDestroy()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000f) && Input.GetMouseButtonDown(0) && hit.collider.tag == "Obstacle")
            {
                Destroy(hit.collider.gameObject);
            }
            else if (Physics.Raycast(ray, out hit, 1000f) && Input.GetMouseButtonDown(0) && hit.collider.tag == "ButtonLevel")
            {
                string click;
                int textLength;
                string selectedLevel;
                string worldName;
                //string thisSceneName;

                worldName = GameManager.Instance.worldName;

                click = hit.collider.gameObject.name;
                textLength = click.Length;
                selectedLevel = click.Substring(5, textLength - 5);

                //Scene thisScene = SceneManager.GetActiveScene();
                //thisSceneName = thisScene.name;
                //textLength = thisSceneName.Length;
                //worldName = thisSceneName.Substring(11, 6);
                GameManager.Instance.levelName = selectedLevel;
                SceneManager.LoadScene(worldName + selectedLevel);
                //Debug.Log("selected" + selectedLevel);
                //Debug.Log("world name" +worldName);
                Debug.Log(worldName + selectedLevel);
                DestroyButton();
            }
            else if (Physics.Raycast(ray, out hit, 1000f) && Input.GetMouseButtonDown(0) && hit.collider.tag == "SelectLevel")
            {
                call.GotoSelectLevel();
                Destroy(hit.collider.gameObject);
            }
            else if (Physics.Raycast(ray, out hit, 1000f) && Input.GetMouseButtonDown(0) && hit.collider.tag == "ExitGame")
            {
                call.ExitGame();
                Destroy(hit.collider.gameObject);
            }
            else if (Physics.Raycast(ray, out hit, 1000f) && Input.GetMouseButtonDown(0) && hit.collider.tag == "SecretLevel")
            {
                SceneManager.LoadScene("LevelSecret");
                Destroy(hit.collider.gameObject);
                DestroyButton();
            }
        }
    }

    void DestroyButton()
    {
        GameObject[] allButtons = GameObject.FindGameObjectsWithTag("ButtonLevel");
        for (int i = 0; i < allButtons.Length; i++)
        {
            Destroy(allButtons[i]);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (GameManager.Instance.crashSpeed > GameManager.Instance.crashTolerance && this.name == "PlayerSteel" && collision.collider.gameObject.tag == "Obstacle")
        {
            Debug.Log("deleted");
            Destroy(collision.collider.gameObject);
        }
        Debug.Log("something crashed");
    }
}

