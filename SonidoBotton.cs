// Controla los sonidos de los botones en el proyecto

using UnityEngine;
using UnityEngine.UI;

public class PlaySoundOnClick : MonoBehaviour
{
    public Button button;
    public AudioSource audioSource;
    public void Start()
    {
        
        button.onClick.AddListener(PlaySound);
    }

    public void PlaySound()
    {
        
        audioSource.Play();
    }
}
