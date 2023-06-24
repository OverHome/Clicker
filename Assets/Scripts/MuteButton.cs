using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    [SerializeField] private AudioClip mute;
    [SerializeField] private AudioClip unmute;

    private Image _image;
    private AudioSource _audioSource;
    private void Start()
    {
        _image = GetComponent<Image>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void MuteSound()
    {
        sound.mute = !sound.mute;
        _image.sprite = Resources.Load<Sprite>(sound.mute ? "btn/OFF" : "btn/ON");
        _audioSource.PlayOneShot(sound.mute ? mute : unmute);
    }
}
