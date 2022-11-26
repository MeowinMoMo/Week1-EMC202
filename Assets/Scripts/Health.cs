using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator an;
    public Image HPbar;
    private void Awake()
    {
        currentHealth = startingHealth;
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    { 
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        Debug.Log(currentHealth);

        float Fill = currentHealth/startingHealth;

        HPbar.fillAmount = Fill;

        if (currentHealth > 0)
        {
            an.SetBool("Hurt",true);
            an.SetTrigger("hurt");
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Static;
            an.SetBool("Death", true);
            an.SetTrigger("death");
        }
    }

}
