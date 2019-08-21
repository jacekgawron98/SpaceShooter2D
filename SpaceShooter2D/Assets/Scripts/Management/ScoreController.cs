using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
    public static int Score;

    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + Score;
    }
}
