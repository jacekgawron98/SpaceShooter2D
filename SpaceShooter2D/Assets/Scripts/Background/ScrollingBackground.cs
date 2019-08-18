using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float BackgroundSpeed;
    private GameObject[] Background;
    // Start is called before the first frame update
    void Start()
    {
        BackgroundSpeed = 0.5f;
        Background = new GameObject[3];
        for(int i = 0;i<3;i++)
        {
            Background[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var obj in Background)
        {
            Vector2 position = obj.transform.position;
            position += new Vector2(0, -1) * BackgroundSpeed * Time.deltaTime;
            obj.transform.position = position;
            if (obj.transform.position.y < -3.0f)
            {
                position.y += obj.gameObject.GetComponent<SpriteRenderer>().bounds.size.y*3;
                obj.transform.position = position;
            }
        }
    }
}
