using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyShoot : MonoBehaviour
{
    public GameObject Bullet;

    private float reloadTimeRemaining;
    public float MaxReloadTime;
    // Start is called before the first frame update
    void Start()
    {
        reloadTimeRemaining = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
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
