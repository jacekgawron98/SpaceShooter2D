using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.y -= 0.3f * Time.deltaTime;
        transform.position = position;
        if (transform.position.y <= -screenBounds.y) 
        {
            Destroy(gameObject);
        }
    }
}
