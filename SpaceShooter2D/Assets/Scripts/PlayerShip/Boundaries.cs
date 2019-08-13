using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    Vector2 screenBounds;
    float objectWidth;
    float objectHeight;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        objectWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, screenBounds.x*-1 + objectWidth, screenBounds.x - objectWidth);
        position.y = Mathf.Clamp(position.y, screenBounds.y*-1 + objectHeight, screenBounds.y - objectHeight);

        transform.position = position;
    }
}
