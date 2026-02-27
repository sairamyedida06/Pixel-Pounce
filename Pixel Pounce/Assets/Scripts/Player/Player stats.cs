using System.Collections;
using UnityEngine;

public class Playerstats : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] float currentHealth;

    public bool canTakeDamage;

    private void Start()
    {
        currentHealth = maxHealth;
        TakeDamage(100);
        Debug.Log(currentHealth);
    }

    public void TakeDamage(float damage)
    {
        if (canTakeDamage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {


            }

            StartCoroutine(PreventDamage());
        }
    }

    private IEnumerator PreventDamage()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);

        if (currentHealth > 0)
        {
            canTakeDamage = true;
        }
        else
        {

        }
    }
}
