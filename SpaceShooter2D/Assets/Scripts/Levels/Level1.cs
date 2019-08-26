using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    private bool finished;
    public bool Finished { get { return finished; } set { finished = value; } }

    Vector2 screenBounds;

    public GameObject[] enemy;
    float respawnTimeRemaining;
    private short waveCounter;

    private float waveRemainingTime;
    private bool isNextWave;

    // Start is called before the first frame update
    void Start()
    {
        respawnTimeRemaining = 2;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        finished = true;

    }
    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            RandomEnemiesWave();
        }
    }

    private void RandomEnemiesWave()
    {
        if (respawnTimeRemaining <= 0)
        {
            Debug.Log("Enemies: " + LevelController.EnemyCounter);
            float x = Random.Range(0 - screenBounds.x, 0 + screenBounds.x);
            Vector2 position = new Vector2(x, 1.2f);
            int enemyType = Random.Range(0, enemy.Length);
            Instantiate(enemy[enemyType], position, Quaternion.identity);

            respawnTimeRemaining = 2;
        }
        else
        {
            respawnTimeRemaining -= Time.deltaTime; ;
        }
    }
}
