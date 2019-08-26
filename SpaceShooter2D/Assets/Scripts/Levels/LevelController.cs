using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelController : MonoBehaviour
{
    public GameObject Level;
    public GameObject InfoText;
    public GameObject HpText;
    public static int EnemyCounter;
    public static int EnemiesOnScreen;

    Level1 level;
    // Start is called before the first frame update
    void Start()
    {
        EnemyCounter = 0;
        EnemiesOnScreen = 0;
        Screen.fullScreen = false;         
    }

    // Update is called once per frame
    void Update()
    {
        level = GetComponent<Level1>();
        HpText.GetComponent<TextMeshProUGUI>().text = "HP: " + PlayerController.HealthPoints;
        
        if(Input.GetKeyDown(KeyCode.Return) && level.Paused)
        {
            InfoText.GetComponent<TextMeshProUGUI>().text = "";
            level.Paused= false;
        }

        if (!PlayerController.IsAlive)
        {
            level.Paused = true;
            InfoText.GetComponent<TextMeshProUGUI>().text = "Game Over Press ESCAPE to restart";
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if(level.Finished)
        {
            level.Paused = true;
            InfoText.GetComponent<TextMeshProUGUI>().text = "You won Press ESCAPE to return to main menu";
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                BossController.ResetStaticValues();
                SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
            }
        }
    }
}
