using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyShoot : MonoBehaviour
{
    public GameObject Bullet;

    private float reloadTimeRemaining;
    public float MaxReloadTime;
    public bool AutoShooting = false;
    // Start is called before the first frame update
    void Start()
    {
        reloadTimeRemaining = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(AutoShooting)
        {
            Shoot();
        }
        else
        {
            RaycastHit2D raycast = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y-0.1f), new Vector2(0, -1));
            if(raycast.collider != null)
            {
                PlayerController player = raycast.collider.gameObject.GetComponent<PlayerController>();
                if(player != null)
                {
                    Shoot();
                }
            }
        }
    }

    void Shoot()
    {
        if (reloadTimeRemaining <= 0)
        {
            GameObject bulletObject = Instantiate(Bullet, transform.position, Quaternion.identity);
            Bullet bulletController = bulletObject.GetComponent<Bullet>();

            bulletController.Shoot(new Vector2(0, -1));

            reloadTimeRemaining = MaxReloadTime;
        }
        if (reloadTimeRemaining > 0)
        {
            reloadTimeRemaining -= Time.deltaTime;
        }

    }
}
