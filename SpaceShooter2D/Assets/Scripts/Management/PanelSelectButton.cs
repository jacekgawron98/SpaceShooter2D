using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelSelectButton : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("LevelSelection", LoadSceneMode.Single);
    }
}
