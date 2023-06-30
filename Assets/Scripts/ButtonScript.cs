using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ButtonScript : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private string audioFolder;
    private AudioClip[] _audioClip;

    private void Start()
    {
        _audioClip = Resources.LoadAll<AudioClip>(audioFolder);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!GetComponent<Button>().interactable)
        {
            audioSource.clip = _audioClip[Random.Range(0, 2)];
            audioSource.Play();
        }
    }
    
    
}
