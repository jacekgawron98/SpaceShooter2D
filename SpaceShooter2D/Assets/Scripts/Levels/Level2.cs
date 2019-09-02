using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    private bool paused;
    public List<GameObject> Waves;
    private int waveCounter;
    // Start is called before the first frame update
    void Start()
    {
        waveCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        paused = LevelController.Paused;
        int counter = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (!paused)
        {
            if (counter == 0)
            {
                if(waveCounter == Waves.Count)
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
