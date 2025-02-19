using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
  [Header("Optional Effects")]
  [SerializeField] private GameObject hitEffect;
  public AudioClip hitSound;
  public AudioClip spikeSound;
  private bool destroyOnContact = false;

  private void OnTriggerEnter2D(Collider2D other)
  {
    FreakyFrogHealth frogHealth = other.GetComponent<FreakyFrogHealth>();
    if (frogHealth != null)
    {
      PlaySpikeSound();
      frogHealth.Die();
      if (hitEffect != null)
      {
        Instantiate(hitEffect, other.transform.position, Quaternion.identity);
      }

      if (hitSound != null && Camera.main != null)
      {
        AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position);
      }

      if (destroyOnContact)
      {
        Destroy(gameObject);
      }
    }
  }

  void PlaySpikeSound()
  {
    if (spikeSound != null)
    {
      AudioSource.PlayClipAtPoint(spikeSound, transform.position);
    }
  }
}