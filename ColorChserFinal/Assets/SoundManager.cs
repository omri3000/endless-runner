using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;


    public AudioSource sound;
    public AudioClip jumpSound;
    public AudioClip bgSound;

    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    public void playBGSound()
    {
        sound.clip = bgSound;
        sound.Play();
    }

    public void playJumpSound()
    {
        sound.PlayOneShot(jumpSound);
    }
}
