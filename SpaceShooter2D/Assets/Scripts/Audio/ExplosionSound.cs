using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip ExplosionClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySound();
    }
    
    private void PlaySound()
    {
        audioSource.PlayOneShot(ExplosionClip);
    }
}
