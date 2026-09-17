
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Objetivo que seguirá la cámara
    [SerializeField] private Transform target;

    //Distancia de la cámara respecto al jugador
    [SerializeField] private Vector3 offset = new Vector3(0, 8, 0);

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}

