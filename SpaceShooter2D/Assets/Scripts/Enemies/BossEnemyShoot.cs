using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyShoot : MonoBehaviour
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
            List<Vector2> shootDirections = new List<Vector2>();

            float offset = 0.04f;
            for(int i = 0; i<5; i++)
            {
                bulletObjects.Add(Instantiate(Bullet, new Vector2(transform.position.x - 0.08f + offset * i, transform.position.y), Quaternion.identity));
                bulletControllers.Add(bulletObjects[i].GetComponent<Bullet>());
                Vector2 direction = Quaternion.AngleAxis(-30 + 15 * i, Vector3.forward) * (new Vector2(0, -1));
                shootDirections.Add(direction);
            }

            for(int i=0; i<bulletControllers.Count ;i++)
            {
                bulletControllers[i].Shoot(shootDirections[i]);
            }
            reloadTimeRemaining = MaxReloadTime;
        }
        if (reloadTimeRemaining > 0)
        {
            reloadTimeRemaining -= Time.deltaTime;
        }

    }
}
