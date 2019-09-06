using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    private bool paused;
    public List<GameObject> Waves;
    private int waveCounter;
    private int enemiesCounter;

    GameObject wave;
    RandomEnemiesWave randomWave;
    private bool isRandomWave;
    // Start is called before the first frame update
    void Start()
    {
        enemiesCounter = GameObject.FindGameObjectsWithTag("Enemy").Length;
        waveCounter = 0;
        isRandomWave = false;
    }

    // Update is called once per frame
    void Update()
    {
        paused = LevelController.Paused;
        if (!paused)
        {
            if (isRandomWave)
            {
                if (randomWave.GetComponent<RandomEnemiesWave>().isFinished)
                {
                    isRandomWave = false;
                }
            }
            else
            {
                enemiesCounter = GameObject.FindGameObjectsWithTag("Enemy").Length;
                if (enemiesCounter == 0)
                {
                    if (waveCounter == Waves.Count)
                    {
                        LevelController.Finished = true;
                        return;
                    }
                    waveCounter++;
                    wave = Instantiate(Waves[waveCounter - 1]);
                    randomWave = wave.GetComponent<RandomEnemiesWave>();
                    if (randomWave != null)
                    {
                        isRandomWave = true;
                    }
                }
            }
        }
    }

}
