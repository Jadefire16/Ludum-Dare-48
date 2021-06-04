using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundSource;
    public AudioSource winSource;
    public AudioSource lossSource;



    const int maxHp = 3;
    int hpValue;

    private void OnEnable()
    {
        Player.UpdateHealthEvent += UpdateHealth;
        SlotsVisuals.WonSpinEvent += PlayWinSound;
        SlotsVisuals.LostSpinEvent += PlayLossSound;

    }

    private void PlayLossSound()
    {
        lossSource.Play();   
    }

    private void OnDisable()
    {
        Player.UpdateHealthEvent -= UpdateHealth;
        SlotsVisuals.WonSpinEvent -= PlayWinSound;
        SlotsVisuals.LostSpinEvent += PlayLossSound;

    }

    void PlayWinSound()
    {
        winSource.Play();
    }

    private void UpdateHealth(int obj)
    {
        float scaledVal = ((float)obj / maxHp) + 0.05f;
        scaledVal = Mathf.Clamp(scaledVal, 0.5f, 1f);
        backgroundSource.pitch = scaledVal;
    }

    public static float GetNormalizedValue(float val, float max, float min) => (val - min) / (max - min); 
}
