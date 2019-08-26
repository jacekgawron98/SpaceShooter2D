using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    private bool finished;
    public bool Finished { get { return finished; } }
    private bool paused;
    public bool Paused { get { return paused; } set { paused = value; } }

    Vector2 screenBounds;

    public GameObject[] Enemy;
    public GameObject BossEnemy;
    float respawnTimeRemaining;
    private short waveCounter;

    private float waveRemainingTime;
    private bool isNextWave;

    // Start is called before the first frame update
    void Start()
    {
        respawnTimeRemaining = 2;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        paused = true;
        finished = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            if (LevelController.EnemyCounter != 10 && !BossController.IsCreated)
            {
                RandomEnemiesWave();
            }
            else if (LevelController.EnemiesOnScreen == 0 && !BossController.IsCreated)
            {
                BossWaveStart(BossEnemy);
            }
            else if (BossController.IsCreated && !BossController.IsAlive)
            {
                finished = true;
            }
        }
    }

    private void RandomEnemiesWave()
    {
        if (respawnTimeRemaining <= 0)
        {
            Debug.Log("Enemies: " + LevelController.EnemyCounter);
            float x = Random.Range(0 - screenBounds.x, 0 + screenBounds.x);
            Vector2 position = new Vector2(x, 1.2f);
            int enemyType = Random.Range(0, Enemy.Length);
            Instantiate(Enemy[enemyType], position, Quaternion.identity);

            respawnTimeRemaining = 2;
        }
        else
        {
            respawnTimeRemaining -= Time.deltaTime; ;
        }
    }
    private void BossWaveStart(GameObject boss)
    {
        Vector2 position = new Vector2(0, 1.5f);
        Instantiate(boss, position, Quaternion.identity);
    }
}
