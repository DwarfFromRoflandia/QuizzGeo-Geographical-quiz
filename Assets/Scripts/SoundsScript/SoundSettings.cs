using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
   // [SerializeField] private Slider SoundsSlider;
    [SerializeField] private Slider MusicSlider;

   // public List<AudioSource> EffectSounds = new List<AudioSource>();
    public List<AudioSource> BackgroundSounds = new List<AudioSource>();


    private void Update()
    {
        for (int i = 0; i < BackgroundSounds.Count; i++)
        {
            BackgroundSounds[i].volume = MusicSlider.value;
        }
    }
}
