using Unity.Cinemachine;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private AudioClip collectableSFX;

    [SerializeField] private int scoreValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlayCoinSFX(collectableSFX);

            GameManager.Instance.AddScore(scoreValue);

            Destroy(gameObject);
        }
    }
}
