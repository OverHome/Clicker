using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private AudioSource audioSource;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if(!GetComponent<Button>().interactable)audioSource.Play();
    }
}
