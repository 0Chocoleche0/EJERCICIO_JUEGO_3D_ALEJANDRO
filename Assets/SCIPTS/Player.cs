using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{   
    [SerializeField]
    private GameManager gameManager;
    [Header("Movement")]
    [SerializeField]
    private int speed = 20;
    [SerializeField]
    private int turnSpeed = 30;
    [Header("Attack")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform[] postRotBullet;
    [Header("Health")]
    [SerializeField]
    private float maxHealth = 100;
    [SerializeField]
    private float currentHealth = 100;
    [SerializeField]
    private float damageBullet = 5;
    [SerializeField]
    private Image lifeBar;
    [SerializeField]
    private ParticleSystem smallExplosion;
    [SerializeField]
    private ParticleSystem bigExplosion;
    private AudioSource shootAudio;


    

    

    private void Awake()
    {
        shootAudio = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
        currentHealth = maxHealth;
        lifeBar.fillAmount = 1;
        smallExplosion.Stop();
        bigExplosion.Stop();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyThunder"))
        {
             Debug.Log("explosion");
             smallExplosion.Play();
             currentHealth -= damageBullet;
             lifeBar.fillAmount = currentHealth / maxHealth;
             Destroy(other.gameObject);
             if (currentHealth <= 0)
             {
              Death();
             }
        }
    }
    private void Death()
    {   
        Camera.main.transform.SetParent(null);
        bigExplosion.Play();
        Destroy(gameObject, 1.8f);
        gameManager.GameOver();
        
    }

    private void Attack()
    {
        if(Input.GetMouseButtonDown(0))
            
            {   
                shootAudio.Play();
                for(int i = 0; i < postRotBullet.Length; i++)
                {
                    Instantiate(bulletPrefab, postRotBullet[i].position, postRotBullet[i].rotation);
                }
            }
            
    }

    private void Movement()
    {   
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    private void Turning()
    {
        float xMouse = Input.GetAxis("Mouse X");
        float yMouse = Input.GetAxis("Mouse Y");
        Vector3 rotation = new Vector3(-yMouse, xMouse , 0);
        transform.Rotate(rotation.normalized * turnSpeed * Time.deltaTime);
    }

    private void Update()
    { 
        Movement();
        Turning();
        Attack();
    }
}