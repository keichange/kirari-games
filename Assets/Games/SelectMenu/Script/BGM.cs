using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    AudioSource audioSource;
    private double FadeInSeconds = 3.0;
    private bool IsFadeIn = true;
    private double FadeInDeltaTime = 0;
    public double FadeOutSeconds = 1.0;
    public bool IsFadeOut = false;
    private double FadeOutDeltaTime = 0;

    void Start()
    {
        IsFadeIn = true;
        IsFadeOut = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (IsFadeIn)
        {
            FadeInDeltaTime += Time.deltaTime;
            if (FadeInDeltaTime >= FadeInSeconds)
            {
                FadeInDeltaTime = FadeInSeconds;
                IsFadeIn = false;
            }
            audioSource.volume = (float)(FadeInDeltaTime / FadeInSeconds);
        }

        if (IsFadeOut)
        {
            FadeOutDeltaTime += Time.deltaTime;
            if (FadeOutDeltaTime >= FadeOutSeconds)
            {
                FadeOutDeltaTime = FadeOutSeconds;
                IsFadeOut = false;
            }
            audioSource.volume = (float)(1.0 - FadeOutDeltaTime / FadeOutSeconds);
        }

    }
}
