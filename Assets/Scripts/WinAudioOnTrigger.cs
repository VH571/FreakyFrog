using UnityEngine;
using UnityEngine.SceneManagement;

public class WinAudioOnTrigger : MonoBehaviour
{
  public AudioClip audioClip;
  private AudioSource audioSource;
  private bool hasPlayed = false;
  public float Delay = 1f;
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
      Invoke("StartScreen", Delay);
    }
  }
  public void StartScreen()
  {
    SceneManager.LoadScene("WIn");
  }
}
