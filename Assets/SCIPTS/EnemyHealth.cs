using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;
    [SerializeField]
    private float currentHealth = 100;
    [SerializeField]
    private float damageBullet = 20;
    [SerializeField]
    private Image lifeBar;
    [SerializeField]
    private ParticleSystem smallExplosion;
    [SerializeField]
    private ParticleSystem bigExplosion;

    void Awake()
    {
        smallExplosion.Stop();
        bigExplosion.Stop();
        currentHealth = maxHealth;
        lifeBar.fillAmount = 1;

    }   
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerThunder"))
        {
            smallExplosion.Play();
            currentHealth -= damageBullet;
            lifeBar.fillAmount = currentHealth / maxHealth;
            Destroy(other.gameObject);
            if(currentHealth <= 0)
            {
                Death();
            }
            void Death()
            {
                bigExplosion.Play();
                Destroy(gameObject, 1.0f);
            } 
        }    
    }   

}
