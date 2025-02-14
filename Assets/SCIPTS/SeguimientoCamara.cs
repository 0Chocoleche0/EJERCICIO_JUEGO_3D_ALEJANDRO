using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguiminetoCamara : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset = new Vector3(0, 0, -1); //Variable que indica la posición del Vector.
    [SerializeField]
    private float velocidadLineal = 20.0f, //Variable que indica la velocidad lineal de la cámara.
                  velocidadGiro = 30.0f; //Variable que indica la velicidad de giro de la cámara.
    [SerializeField]
    private Transform target; //Variable que define el objetivo.
    
    private void LateUpdate() //Variable que hace que se reproduzca más tarde que las acciones del Uptade.
    {   
        if (target == null) 
        {   
            return;
        }
        Vector3 posicionDeseada = target.position + target.rotation * offset; //Función que indica que la posición deseada es igual que la posición y la rotación del objetivo.
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, velocidadLineal * Time.deltaTime); //Función que 

        Quaternion rotacionDeseada = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, velocidadGiro);
    }

    
}
