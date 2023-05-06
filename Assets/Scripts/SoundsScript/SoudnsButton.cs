using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoudnsButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private AudioClip music;
    [SerializeField] private AudioSource audioSource;


    public void ClickSound() => audioSource.PlayOneShot(music);


    public void OnPointerDown(PointerEventData data) => ClickSound();

}
