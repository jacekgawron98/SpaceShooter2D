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

    Level1 level;
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = false;         
    }

    // Update is called once per frame
    void Update()
    {
        level = Level.GetComponent<Level1>();
        HpText.GetComponent<TextMeshProUGUI>().text = "HP: " + PlayerController.HealthPoints;
        
        if(Input.GetKeyDown(KeyCode.Return) && level.Finished)
        {
            InfoText.GetComponent<TextMeshProUGUI>().text = "";
            level.Finished = false;
        }

        if (!PlayerController.IsAlive)
        {
            level.Finished = true;
            InfoText.GetComponent<TextMeshProUGUI>().text = "Game Over Press ESCAPE to restart";
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
