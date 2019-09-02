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
    public GameObject InfoText;
    public GameObject HpText;
    public static int EnemyCounter;
    public static int EnemiesOnScreen;

    private void Awake()
    {
        Screen.fullScreen = false;
        EnemyCounter = 0;
        EnemiesOnScreen = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("LEVEL: " + ApplicationManager.selectedLevel);
        SelectLevel();

        Paused = true;
        Finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        HpText.GetComponent<TextMeshProUGUI>().text = "HP: " + PlayerController.HealthPoints;
        
        if(Input.GetKeyDown(KeyCode.Return) && Paused)
        {
            InfoText.GetComponent<TextMeshProUGUI>().text = "";
            Paused= false;
        }

        if (!PlayerController.IsAlive)
        {
            Paused = true;
            InfoText.GetComponent<TextMeshProUGUI>().text = "Game Over Press ESCAPE to restart";
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if(Finished)
        {
            Paused = true;
            InfoText.GetComponent<TextMeshProUGUI>().text = "You won Press ESCAPE to return to main menu";
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
                SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
            }
        }
    }

    void SelectLevel()
    {
        Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Levels/Level"+ApplicationManager.selectedLevel+".prefab", typeof(GameObject));
        Instantiate(prefab);
    }
}
