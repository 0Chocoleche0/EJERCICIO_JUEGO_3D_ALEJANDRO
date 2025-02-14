using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [Header("Movimiento")] //Variable que se usa para agrupar otras variables por nombres.
    [SerializeField] //Variable que se usa para poder visualizar los datos de una variable aún siendo privada.
    private int speed = 12; //Variable para indicar la cantidad entera de velocidad tiene el objeto.
    [SerializeField]
    private float distanceToPlayer = 6; //Variable para indicar la distancia con el jugador.
    private GameObject player; //Variable para indicar que el objeto nombrado es el player.
    [Header("Attack")] 
    [SerializeField]
    private GameObject bulletPrefab; //Variable para indicar que el objeto nombrado es el prefab de la bala.
    [SerializeField]
    private Transform[] posRotBullet; //Variable para indicar que el objeto nombrado es la posición del lanzador de balas.
    [SerializeField]
    private float timeBetweenBullets = 3.0f; //Variable para indicar el tiempo decimal entre balas.
    private AudioSource shootAudio; //Variable que se usa para añadir un recurso de audio, en este caso el sonido de disparo.

    void Awake() //Variable que hace que las funciones se ejecuten al empezar el juego.
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Función para indicar que hay que buscar al objeto player con un tag asignado a este.
        InvokeRepeating("Attack", 1, timeBetweenBullets); //Función para que el ataque se repita, respetando el tiempo entre balas.
        shootAudio = GetComponent<AudioSource>(); //Variable para asginarle un componente al recurso de audio.
    }
    
    void Update()
    {
        if(player == null) //Indica que el objeto ya no realiza una acción o un estado.
            return; //Devuelve la información de la acción o el estado. 
        transform.LookAt(player.transform.position); //Función que hace que el objetivo mire a la posición del player.
    }

    void FollowPlayer() //Variable que se usa para almacenar los datos relacionados con la persecución del player
    {
        float distance = Vector3.Distance(transform.position, player.transform.position); //Función que indica una distancia entre el enemigo y el player.
        if (distance > distanceToPlayer) //Se usa para indicar que si la distancia es mayor que la distancia al jugador...
            transform.Translate(Vector3.forward * speed * Time.deltaTime); //... modifica la velocidad del enemigo para siempre mantener cierta distancia ya definida.
    }

    private void Attack() //Variable que almacena los datos relacionados con el ataque del enemigo.
    {    
            shootAudio.Play(); //Función para que se active el efecto de sonido de disparo.
            for(int i = 0; i < posRotBullet.Length; i++) //Bucle que almacena un número empezando por cero, que si es menor que la cantidad de lanzadores de balas, sigue sumando balas.
            {   
            Instantiate(bulletPrefab, posRotBullet[i].position, posRotBullet[i].rotation); //Función que instancia el prefab de la bala, la posicion y la rotación del lanzador de la bala.
            }
        
    }
}
