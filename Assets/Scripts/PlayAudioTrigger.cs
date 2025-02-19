using UnityEngine;

public class PlayAudioOnTrigger : MonoBehaviour
{
  public AudioClip audioClip;
  private AudioSource audioSource;
  private bool hasPlayed = false;

  void Start()
  {
    audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.clip = audioClip;
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player") && !hasPlayed)
    {
      audioSource.Play();
      hasPlayed = true;
    }
  }
}
