using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    private bool finished;
    public bool Finished { get { return finished; } set { finished = value; } }
    Vector2 screenBounds;
    public GameObject enemy;

    float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = 2;
        finished = true;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(!finished)
        {
                if(timeRemaining <= 0)
                {
                    float x = Random.Range(0 - screenBounds.x, 0 + screenBounds.x);
                    Vector2 position = new Vector2(x, 1.0f);
                    Instantiate(enemy, position, Quaternion.identity);

                    timeRemaining = 2;
                }
                else
                {
                    timeRemaining -= Time.deltaTime; ;
                }
        }
    }
}
