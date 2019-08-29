using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private float remainingTime;
    // Start is called before the first frame update
    void Start()
    {
        remainingTime = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(remainingTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            remainingTime -= Time.deltaTime;
        }
    }
}
