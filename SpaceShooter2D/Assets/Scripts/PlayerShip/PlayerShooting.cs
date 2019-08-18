using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject Bullet;
    public float MaxReloadTime;
    private float ReloadTimeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        ReloadTimeRemaining = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        if(Input.GetKey(KeyCode.Space))
        {
            if (ReloadTimeRemaining <= 0)
            {
                GameObject bulletObject = Instantiate(Bullet, position + Vector2.up * 0.3f, Quaternion.identity);
                Bullet bulletController = bulletObject.GetComponent<Bullet>();

                bulletController.Shoot(new Vector2(0,1));

                ReloadTimeRemaining = MaxReloadTime;
            }      
        }
        if (ReloadTimeRemaining > 0)
            ReloadTimeRemaining -= Time.deltaTime;

        //Debug.Log(ReloadTimeRemaining);
    }
}
