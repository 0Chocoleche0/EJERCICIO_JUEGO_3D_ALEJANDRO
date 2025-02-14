using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{   
    [SerializeField]
    private GameManager gameManager; //Variante que indica que el objeto a referenciar es el Game Manager.
    [Header("Movement")]
    [SerializeField]
    private int speed = 20; //Variante que indica la velocidad del jugador.
    [SerializeField]
    private int turnSpeed = 30; //Variante que indica la velocidad de giro del jugador.
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
        if (other.CompareTag("EnemyThunder"))  //Se usa para comprobar el tag de la bala del enemigo.
        { 
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
        Camera.main.transform.SetParent(null); //Función que anula el parentesco de la cámara con el player.
        bigExplosion.Play();
        Destroy(gameObject, 1.8f);
        gameManager.GameOver();
        
    }

    private void Attack()
    {
        if(Input.GetMouseButtonDown(0)) //Si se pulsa el botón asignado...
            
            {   
                shootAudio.Play(); //... suena el sonido de disparo.
                for(int i = 0; i < postRotBullet.Length; i++)
                {
                    Instantiate(bulletPrefab, postRotBullet[i].position, postRotBullet[i].rotation);
                }
            }
            
    }

    private void Movement() 
    {   
        float horizontal = Input.GetAxis("Horizontal"); //Función que almacena el movimiento horizontal del player asignándole un botón.
        float vertical = Input.GetAxis("Vertical");  //Función que almacena el movimiento vertical del player asignándole un botón.
        Vector3 direction = new Vector3(horizontal, 0, vertical); //Función que indica la dirección del Vector del player.
        transform.Translate(direction.normalized * speed * Time.deltaTime); //Función que normaliza la velocidad usando la dirección del player.
    }

    private void Turning() //Variable que alamcena el giro del player.
    {
        float xMouse = Input.GetAxis("Mouse X"); //Función que asigna la movilidad en el eje X con el ratón.
        float yMouse = Input.GetAxis("Mouse Y"); //Función que asigna la movilidad en el eje Y con el ratón.
        Vector3 rotation = new Vector3(-yMouse, xMouse , 0); //Función que defina la rotación del vector con el eje x e y del ratón.
        transform.Rotate(rotation.normalized * turnSpeed * Time.deltaTime); //Función que normaliza la velocidad de giro usando la dirección del player. 
    }

    private void Update()
    { 
        Movement();
        Turning();
        Attack();
    }
}