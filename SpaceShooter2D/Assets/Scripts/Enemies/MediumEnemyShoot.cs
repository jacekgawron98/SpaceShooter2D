using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyShoot : MonoBehaviour
{
    public GameObject Bullet;

    private float reloadTimeRemaining;
    public float MaxReloadTime;
    // Start is called before the first frame update
    void Start()
    {
        reloadTimeRemaining = 0;
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
            List<GameObject> bulletObjects = new List<GameObject>();
            List<Bullet> bulletControllers = new List<Bullet>();

            bulletObjects.Add(Instantiate(Bullet, new Vector2(transform.position.x-0.025f,transform.position.y), Quaternion.identity));
            bulletControllers.Add(bulletObjects[0].GetComponent<Bullet>());

            bulletObjects.Add(Instantiate(Bullet, new Vector2(transform.position.x+0.025f, transform.position.y), Quaternion.identity));
            bulletControllers.Add(bulletObjects[1].GetComponent<Bullet>());

            foreach (var o in bulletControllers)
            {
                o.Shoot(new Vector2(0, -1));
            }
            reloadTimeRemaining = MaxReloadTime;
        }
        if (reloadTimeRemaining > 0)
        {
            reloadTimeRemaining -= Time.deltaTime;
        }

    }
}
