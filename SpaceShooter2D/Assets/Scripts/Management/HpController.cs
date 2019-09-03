using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HpController : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = PlayerController.HealthPoints + "%";
    }
}
