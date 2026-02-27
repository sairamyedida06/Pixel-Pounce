using Unity.Cinemachine;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private AudioClip collectableSFX;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlayCoinSFX(collectableSFX);

            Destroy(gameObject);
        }
    }
}
