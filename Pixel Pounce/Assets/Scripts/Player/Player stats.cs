using System.Collections;
using UnityEngine;

public class Playerstats : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] float currentHealth;

    public bool canTakeDamage = true;

    private Animator animator;
    private void Start()
    {
        animator = GetComponentInParent<Animator>();

        currentHealth = maxHealth;
        
        Debug.Log(currentHealth);
    }

    public void TakeDamage(float damage)
    {
        if (canTakeDamage)
        {
            currentHealth -= damage;

            animator.SetBool("Damaged", true);

            if (currentHealth <= 0)
            {


            }

            StartCoroutine(PreventDamage());
        }
    }

    private IEnumerator PreventDamage()
    {
        canTakeDamage = false;

        Debug.Log("couroutine");

        yield return new WaitForSeconds(0.15f);


        if (currentHealth > 0)
        {
            canTakeDamage = true;
            animator.SetBool("Damaged", false);
        }
        else
        {
            animator.SetBool("Death",true);
        }
    }
}
