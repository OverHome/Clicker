using UnityEngine;

public class BackgroundInstance : MonoBehaviour
{
    private AudioSource audioListener;
    private float originalVolume;
    
    [SerializeField] public Clicker clicker;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioListener = GetComponent<AudioSource>();
        originalVolume = audioListener.volume;
    }

    public void MuteSound()
    {
        audioListener.volume = 0f;
        clicker.IsTimer = false;
    }

    public void UnmuteSound()
    {
        audioListener.volume = originalVolume;
         clicker.IsTimer = true;
    }
    
}
