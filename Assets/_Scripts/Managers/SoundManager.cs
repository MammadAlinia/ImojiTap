using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioClip win, wrong;
    [SerializeField] private AudioSource sfx;
    private void Awake()
    {
        Instance = this;
    }

    public void PlayWrong()
    {
        sfx.PlayOneShot(wrong);
    }
  
    public void PlayWin()
    {
        sfx.PlayOneShot(win);
    }
}
