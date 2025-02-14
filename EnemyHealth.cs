using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100; //Variable que indica la vida máxima del enemigo.
    [SerializeField]
    private float currentHealth = 100; //Variable que indica la vida actual.
    [SerializeField]
    private float damageBullet = 20; //Variable que indica el daño de su bala.
    [SerializeField]
    private Image lifeBar; //Varible que contiene su barra de vida.
    [SerializeField]
    private ParticleSystem smallExplosion; //Variable que contiene las partículas de la explosión pequeña.
    [SerializeField]
    private ParticleSystem bigExplosion; //Variable que contiene las partículas de la explosión grande.

    void Awake() 
    {
        smallExplosion.Stop(); //Función que hace que la explosión pequeña deje de ejecutarse.
        bigExplosion.Stop(); //Función que hace que la explosión grande deje de ejecutarse.
        currentHealth = maxHealth; //Función que indica que la vida actual al inciar es igual a la vida máxima.
        lifeBar.fillAmount = 1; //Función que indica que la barra de vida al inicio debe estar llena.

    }   
    private void OnTriggerEnter(Collider other) //Variable que almacena la colisión del enemigo.
    {
        if(other.CompareTag("PlayerThunder")) //Se usa para comprobar el tag de la bala del player.
        {
            smallExplosion.Play(); //Indicando que la explosión se ejecuta si le golpea.
            currentHealth -= damageBullet; //Haciendo que la barra de vida baje el daño que tenga asignada la bala del player.
            lifeBar.fillAmount = currentHealth / maxHealth; //Reduce la barra de vida actual con la vida máxima.
            Destroy(other.gameObject); //Destruye el enemigo.
            if(currentHealth <= 0) //Si la vida acutal llega a 0.
            {
                Death(); //Activa la muerte.
            }
            void Death() //Variable para almacenar la muerte.
            {
                bigExplosion.Play(); //Si se activa la muerte se activa la explosión grande.
                Destroy(gameObject, 1.0f); //Destruyendo al enemigo cuando pase un segundo.
            } 
        }    
    }   

}
