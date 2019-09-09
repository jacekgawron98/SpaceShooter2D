using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemiesWave : MonoBehaviour
{
    public float WaveDuration;
    private float waveRamainingTime;
    public List<GameObject> Enemy;
    private float respawnTimeRemaining;
    private Vector2 screenBounds;
    public bool isFinished;
    // Start is called before the first frame update
    void Start()
    {
        isFinished = false;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        waveRamainingTime = WaveDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if(waveRamainingTime > 0)
        {
            if (respawnTimeRemaining <= 0)
            {
                float x = Random.Range(0 - screenBounds.x, 0 + screenBounds.x);
                Vector2 position = new Vector2(x, screenBounds.y+0.1f);
                int enemyType = Random.Range(0, Enemy.Count);
                Instantiate(Enemy[enemyType], position, Quaternion.identity);

                respawnTimeRemaining = 1;
            }
            else
            {
                respawnTimeRemaining -= Time.deltaTime; ;
            }
            waveRamainingTime -= Time.deltaTime;
        }
        else
        {
            if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                isFinished = true;
        }

    }
}
