﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject SpecialBullet;
    public AudioClip ShootSound;
    private AudioSource audioSource;

    public int NumberOfBullets;
    public float SpecialBulletTimeRemaining;

    public float MaxReloadTime;
    private float ReloadTimeRemaining;
    private bool paused;
    // Start is called before the first frame update
    void Start()
    {
        SpecialBulletTimeRemaining = 0;
        NumberOfBullets = Mathf.Clamp(NumberOfBullets, 1, 5);
        ReloadTimeRemaining = 0;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        paused = LevelController.Paused;
        if(!paused)
        {
            if (SpecialBulletTimeRemaining <= 0)
            {
                StandarShooting();
            }
            else
            {
                SpecialShooting();
                SpecialBulletTimeRemaining -= Time.deltaTime;
            }
        }
    }

    void StandarShooting()
    {
        if (ReloadTimeRemaining <= 0)
        {
            float offset = 0.02f * (NumberOfBullets - 1);

            List<GameObject> bulletObjects = new List<GameObject>();
            List<Bullet> bulletControllers = new List<Bullet>();

            for (int i = 0; i < NumberOfBullets; i++)
            {
                Vector2 bulletPos = new Vector2(transform.position.x - offset + (0.04f * i), transform.position.y + 0.1f);
                bulletObjects.Add(Instantiate(Bullet, bulletPos, Quaternion.identity));
                bulletControllers.Add(bulletObjects[i].GetComponent<Bullet>());
            }

            foreach (Bullet bullet in bulletControllers)
            {
                bullet.Shoot(new Vector2(0, 1));
            }
            audioSource.PlayOneShot(ShootSound, 0.5f);

            ReloadTimeRemaining = MaxReloadTime;
        }
        if (ReloadTimeRemaining > 0)
            ReloadTimeRemaining -= Time.deltaTime;
    }

    void SpecialShooting()
    {
        if (ReloadTimeRemaining <= 0)
        {
            Vector2 bulletPos = new Vector2(transform.position.x, transform.position.y + 0.1f);
            GameObject bulletObject = Instantiate(SpecialBullet, transform.position, Quaternion.identity);
            Bullet bulletController = bulletObject.GetComponent<Bullet>();

            bulletController.Shoot(new Vector2(0, 1));
            audioSource.PlayOneShot(ShootSound);
            ReloadTimeRemaining = 0.1f;
        }
        if (ReloadTimeRemaining > 0)
            ReloadTimeRemaining -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddBulletPowerUp addBulletPowerUp = collision.gameObject.GetComponent<AddBulletPowerUp>();
        if(addBulletPowerUp != null)
        {
            addBulletPowerUp.AddBullet(gameObject);
        }

        SuperBulletPowerUp superBulletPowerUp = collision.gameObject.GetComponent<SuperBulletPowerUp>();
        if(superBulletPowerUp != null)
        {
            superBulletPowerUp.ChangeBullet(gameObject);
        }
    }
}
