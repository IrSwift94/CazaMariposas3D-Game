using UnityEngine;

public class SpawnerMariposas: MonoBehaviour
{



    // Referencia al prefab de la mariposa
    [SerializeField] private GameObject mariposasPrefab;

    // Referencia al jugador
    [SerializeField] private Transform jugador;

    // Referencias a los Box Collider de las cuatro paredes
    [SerializeField] private BoxCollider paredNorte;
    [SerializeField] private BoxCollider paredSur;
    [SerializeField] private BoxCollider paredEste;
    [SerializeField] private BoxCollider paredOeste;

    // Tiempo mínimo y máximo entre spawns
    [SerializeField] private float tiempoMinimo = 1f;
    [SerializeField] private float tiempoMaximo = 3f;

    // Altura de aparición sobre el jugador
    [SerializeField] private float alturaSpawn = 8f;

    // Rango aleatorio alrededor del jugador
    [SerializeField] private float rangoSpawn = 5f;

    // Margen para evitar que las mariposas aparezcan pegadas a las paredes
    [SerializeField] private float margenParedes = 1f;

    private void Start()
    {
        // Inicia el ciclo de generación de mariposas
        Invoke(
            nameof(SpawnMariposa),
            Random.Range(tiempoMinimo, tiempoMaximo)
        );
    }

    private void SpawnMariposa()
    {
        // Obtiene los límites de la zona de juego
        float minX = paredOeste.bounds.max.x;
        float maxX = paredEste.bounds.min.x;
        float minZ = paredSur.bounds.max.z;
        float maxZ = paredNorte.bounds.min.z;

        // Genera una posición aleatoria alrededor del jugador
        float x = jugador.position.x + Random.Range(-rangoSpawn, rangoSpawn);
        float z = jugador.position.z + Random.Range(-rangoSpawn, rangoSpawn);

        // Limita la posición para mantener la mariposa dentro de la zona
        x = Mathf.Clamp(
            x,
            minX + margenParedes,
            maxX - margenParedes
        );

        z = Mathf.Clamp(
            z,
            minZ + margenParedes,
            maxZ - margenParedes
        );

        // Coloca la mariposa por encima del jugador
        Vector3 posicion = new Vector3(
            x,
            jugador.position.y + alturaSpawn,
            z
        );

        // Instancia la mariposa en la posición calculada
        Instantiate(
            mariposasPrefab,
            posicion,
            Quaternion.identity
        );

        // Programa el siguiente spawn después de un tiempo aleatorio
        Invoke(
            nameof(SpawnMariposa),
            Random.Range(tiempoMinimo, tiempoMaximo)
        );
    }
} 

   


