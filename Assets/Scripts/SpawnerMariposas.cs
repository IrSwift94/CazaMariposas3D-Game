using UnityEngine;

public class SpawnerMariposas: MonoBehaviour
{
  

    // Referencia al prefab de la mariposa
    public GameObject mariposasPrefab;

    // Referencia al jugador
    public Transform jugador;

    // Tiempo mínimo y máximo entre spawns
    public float tiempoMinimo = 1f;
    public float tiempoMaximo = 3f;

    // Offset de altura sobre el jugador
    public float alturaSpawn = 8f;

    // Rango aleatorio alrededor del jugador
    public float rangoSpawn = 5f;


    void Start()
    {
        // Inicia el ciclo de generación de mariposas
        Invoke("SpawnMariposa", Random.Range(tiempoMinimo, tiempoMaximo));


        
    }

    void SpawnMariposa()
    {
        // Genera una posición aleatoria alrededor del jugador
        float x = jugador.position.x + Random.Range(-rangoSpawn, rangoSpawn);
        float z = jugador.position.z + Random.Range(-rangoSpawn, rangoSpawn);

        // Siempre por encima del jugador
        Vector3 posicion = new Vector3(x, jugador.position.y + alturaSpawn, z);



        //Instancia la mariposa en esa posición
        Instantiate(mariposasPrefab, posicion, Quaternion.identity);

        //Vuelve a llamarse a sí mismo tras un tiempo aleatorio
        Invoke("SpawnMariposa", Random.Range(tiempoMinimo, tiempoMaximo));
             


    }

}
