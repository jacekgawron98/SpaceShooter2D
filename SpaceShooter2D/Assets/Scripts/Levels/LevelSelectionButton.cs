using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts.Management;
public class LevelSelectionButton : MonoBehaviour
{
    public int LevelNumber;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadLevel);
    }

    public void LoadLevel()
    {
        ApplicationManager.selectedLevel = LevelNumber;
        SceneManager.LoadScene("Level",LoadSceneMode.Single);
    }
}
