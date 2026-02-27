using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. Try to get the component and store it in a variable
        Playerstats player = collision.GetComponentInParent<Playerstats>();

        // 2. ONLY proceed if the variable is NOT null
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        else
        {
            Debug.Log("Spike hit something, but it doesn't have Playerstats attached!");
        }
    }

}
