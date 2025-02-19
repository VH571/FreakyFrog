using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FreakyFrogHealth : MonoBehaviour
{
    public int health = 5;
    public GameObject deathEffect;
    public AudioClip deathSound;
    public float restartDelay = 1f;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Freaky Frog took damage! Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Freaky Frog has been defeated!");

        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        PlayDeathSound();

        gameObject.SetActive(false);

        Invoke("Restart", restartDelay);
    }

    void PlayDeathSound()
    {
        AudioSource tempAudio = gameObject.AddComponent<AudioSource>();
        tempAudio.clip = deathSound;
        tempAudio.volume = 1f;
        tempAudio.Play();
        Destroy(tempAudio, deathSound.length);
        if (deathSound != null)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Dead");
    }
}
