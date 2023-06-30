using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private string audioFolder;
    [SerializeField] private Clicker clicker;

    private Queue<AudioClip> _audioClips;

    private AudioClip NextClip => _audioClips.Count == 0 ? null : _audioClips.Dequeue();

    private void Start()
    {
        var a = Resources.LoadAll<AudioClip>(audioFolder);
        _audioClips = new Queue<AudioClip>(a);
    }

    public void UpLoadSound()
    {
        for (int i = 0; i < clicker.GlobalData.ToiletId!; i++)
        {
            SetNextSound();
        }
    }

    public void SetNextSound()
    {
        audioSource.clip = NextClip;
    }

    IEnumerator NextSound()
    {
        var clip = NextClip;
        yield return new WaitForSeconds(clip.length);
        audioSource.clip = clip;
    }
}
