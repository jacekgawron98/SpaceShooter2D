using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject Bullet;
    public int NumberOfBullets;
    public float MaxReloadTime;
    private float ReloadTimeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        NumberOfBullets = Mathf.Clamp(NumberOfBullets, 1, 5);
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
                float offset = 0.02f * (NumberOfBullets - 1);

                List<GameObject> bulletObjects = new List<GameObject>();
                List<Bullet> bulletControllers = new List<Bullet>();

                for(int i=0;i<NumberOfBullets;i++)
                {
                    Vector2 bulletPos = new Vector2(position.x - offset + (0.04f * i) , position.y+0.1f);
                    Debug.Log(bulletPos.x);
                    bulletObjects.Add(Instantiate(Bullet, bulletPos, Quaternion.identity));
                    bulletControllers.Add(bulletObjects[i].GetComponent<Bullet>());
                }
                
                foreach(Bullet bullet in bulletControllers)
                {
                    bullet.Shoot(new Vector2(0, 1));
                }

                ReloadTimeRemaining = MaxReloadTime;
            }      
        }
        if (ReloadTimeRemaining > 0)
            ReloadTimeRemaining -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddBulletPowerUp powerUp = collision.gameObject.GetComponent<AddBulletPowerUp>();
        if(powerUp != null)
        {
            powerUp.AddBullet(gameObject);
        }
    }
}
