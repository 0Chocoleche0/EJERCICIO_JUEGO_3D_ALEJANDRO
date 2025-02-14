using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEnemy : MonoBehaviour
{ 
    void Update() //Método donde se ejecutan las funciones que coloquemos, acutalizándose frame a frame.
    {
        transform.LookAt(Camera.main.transform.position); //Función que hace que el objetivo mire a la posición de la cámara.
    }
}
