using UnityEngine;

public class CamaraControlador : MonoBehaviour 
{
    //Referencia al jugador que seguirá la cámara
    public Transform jugador;

    //Distancia detrás del jugador
    public float distancia = 5f;

    //Altura de la cámara sobre el jugador
    public float altura = 3f;

    // Suavidad del movimiento de la cámara
    public float suavidad = 5f;

    void LateUpdate()
    {
        // Calcula la posición detrás del jugador según su rotación
        Vector3 posicionDeseada = jugador.position
            - jugador.forward * distancia
            + Vector3.up * altura;

        // Mueve la cámara suavemente hacia esa posición
        transform.position = Vector3.Lerp(
            transform.position,
            posicionDeseada,
            suavidad * Time.deltaTime

            );

        // La cámara siempre mira al jugador
        transform.LookAt(jugador);


        
    }

}
