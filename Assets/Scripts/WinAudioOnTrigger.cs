using UnityEngine;
using UnityEngine.SceneManagement;

public class WinAudioOnTrigger : MonoBehaviour
{
  public AudioClip audioClip;
  private AudioSource audioSource;
  private bool hasPlayed = false;
  public float Delay = 14f;
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
      FreakyFrogController playerController = other.GetComponent<FreakyFrogController>();
      if (playerController != null)
      {
        playerController.enabled = false;
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
          rb.linearVelocity = Vector2.zero;
          rb.isKinematic = true;
        }
      }

      Invoke("StartScreen", Delay);
    }
  }
  public void StartScreen()
  {
    SceneManager.LoadScene("Win");
  }
}
