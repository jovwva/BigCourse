using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance {get; private set;} 

    private AudioSource audioSource;
    private float volume = 1f;
    private const string PP_MUSIC_EFFECT_VOLUME_KEY = "MusicEffectVolume";

    void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();

        volume = PlayerPrefs.GetFloat(PP_MUSIC_EFFECT_VOLUME_KEY, 1f);
        audioSource.volume = volume;
    }
    public void ChangeVolume()
    {
        volume += .1f;
        if (volume > 1f)
        {
            volume = 0f;
        }
        audioSource.volume = volume;
        PlayerPrefs.SetFloat(PP_MUSIC_EFFECT_VOLUME_KEY, volume);
    }
    public float GetVolume()
    {
        return volume;
    }
}
