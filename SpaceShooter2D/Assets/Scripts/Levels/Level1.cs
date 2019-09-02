using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    private bool paused;
    public List<GameObject> Waves;
    private int waveCounter;
    public int EnemiesCounter;

    GameObject randomWave;
    // Start is called before the first frame update
    void Start()
    {
        EnemiesCounter = GameObject.FindGameObjectsWithTag("Enemy").Length;
        waveCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        paused = LevelController.Paused;

        if (!paused)
        {
            if (waveCounter == 0 && EnemiesCounter == 0)
            {
                
                randomWave = Instantiate(Waves[waveCounter]);
                EnemiesCounter++;
            }
            else if (waveCounter == 0)
            {
                if (randomWave.GetComponent<RandomEnemiesWave>().isFinished)
                {
                    EnemiesCounter--;
                    waveCounter++;
                }                
            }
            else
            {
                EnemiesCounter = GameObject.FindGameObjectsWithTag("Enemy").Length;
                if (EnemiesCounter == 0)
                {
                    if (waveCounter == Waves.Count)
                    {
                        LevelController.Finished = true;
                        return;
                    }
                    waveCounter++;
                    Instantiate(Waves[waveCounter - 1]);
                }
            }
        }
    }

}
