using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // This script is for managing all the different stages and scenes of the game, for example losing scene.

    // Bool used to store the information of whether or not the game has ended
    bool gameHasEnded = false;

    public GameObject PauseMenu;
    public GameObject LoseMenu;
    public GameObject CurrentMenu;

    public Text resumeText;

    bool gamePaused = false;

    public Animator animator;

    public GameObject[] Blocks;

    // This public function will be called by the DuckCollider.cs script when the duck hits something and loses.
    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            print("You lost!");
            gameHasEnded = true;
            animator.SetFloat("Run", 0f);
            Invoke("Lost", 2f);
        }
    }

    private void Start()
    {
        Blocks = Resources.LoadAll<GameObject>("Blocks");
        GameObject FirstBlock = Instantiate(Blocks[Random.Range(0, 17)]);
        FirstBlock.name = "1";
        GameObject SecondBlock = Instantiate(Blocks[Random.Range(0, 17)]);
        SecondBlock.name = "2";
        SecondBlock.transform.position = new Vector3(0, 0, 72);
        GameObject ThirdBlock = Instantiate(Blocks[Random.Range(0, 17)]);
        ThirdBlock.name = "3";
        ThirdBlock.transform.position = new Vector3(0, 0, 144);
    }

    public void Lost()
    {
        LoseMenu.SetActive(true);
        CurrentMenu.SetActive(false);
    }

    public void Restart()
    {
        LoseMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public GameObject HelpPanel;
    public GameObject MainPanel;
    bool isHelp = false;
    public void HelpMenu()
    {
        if (isHelp)
        {
            isHelp = false;
            HelpPanel.SetActive(false);
            MainPanel.SetActive(true);
        }
        else
        {
            isHelp = true;
            HelpPanel.SetActive(true);
            MainPanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "GameScene" && LoseMenu.active == false)
        {
            if (gamePaused)
            {
                StartCoroutine(Resume());
            }
            else
            {
                Pause();
            }
        }
    }
    public IEnumerator Resume()
    {
        resumeText.text = "3";
        yield return new WaitForSecondsRealtime(1f);
        resumeText.text = "2";
        yield return new WaitForSecondsRealtime(1f);
        resumeText.text = "1";
        yield return new WaitForSecondsRealtime(1f);
        resumeText.text = "Go!";
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        yield return new WaitForSecondsRealtime(1.5f);
        resumeText.text = "";
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("IntroScene");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
