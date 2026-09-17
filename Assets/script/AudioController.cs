using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip foodSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip music;

    private void Start()
    {
        GameManager.OnFoodObtained += PlayFoodSound;
    }

    private void OnDestroy()
    {
        GameManager.OnFoodObtained -= PlayFoodSound;
    }

    private void PlayFoodSound()
    {
        audioSource.PlayOneShot(foodSound);
    }
}

