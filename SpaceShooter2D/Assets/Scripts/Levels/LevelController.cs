using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Assets.Scripts.Management;
using UnityEditor;

public class LevelController : MonoBehaviour
{
    public static bool Finished;
    public static bool Paused;

    public GameObject Level;
    public GameObject InfoPanel;
    public GameObject CountdownText;
    public static int EnemyCounter;
    public static int EnemiesOnScreen;

    private float StartCountdown;

    private void Awake()
    {
        Screen.fullScreen = false;
        InfoPanel.SetActive(false);
        EnemyCounter = 0;
        EnemiesOnScreen = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        SelectLevel();

        StartCountdown = 5;
        Paused = true;
        Finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(StartCountdown <= 0 && Paused && !Finished)
        {
            CountdownText.GetComponent<TextMeshProUGUI>().text = "";
            Paused = false;
        }
        else if(Paused && !Finished)
        {
            if (StartCountdown < 1)
                CountdownText.GetComponent<TextMeshProUGUI>().text = "GO!";
            else if (StartCountdown > 4)
                CountdownText.GetComponent<TextMeshProUGUI>().text = "USE ARROW TO MOVE! READY?";
            else
                CountdownText.GetComponent<TextMeshProUGUI>().text = ((int)StartCountdown).ToString();

            StartCountdown -= Time.deltaTime;
        }

        if (!PlayerController.IsAlive)
        {
            Paused = true;
            InfoPanel.SetActive(true);

            TextMeshProUGUI infoText = InfoPanel.transform.Find("InfoText").gameObject.GetComponent<TextMeshProUGUI>();
            infoText.text = "GAME OVER";
        }

        if(Finished)
        {
            Paused = true;
            InfoPanel.SetActive(true);
            TextMeshProUGUI infoText = InfoPanel.transform.Find("InfoText").gameObject.GetComponent<TextMeshProUGUI>();
            infoText.text = "YOU WON! Score: " + ScoreController.Score;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
                SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
            }
        }
    }

    void SelectLevel()
    {
        Object levelPrefab = Resources.Load("levels/level" + ApplicationManager.selectedLevel);
        Instantiate(levelPrefab);
    }
}
