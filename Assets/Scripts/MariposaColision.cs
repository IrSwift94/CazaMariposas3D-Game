using JetBrains.Annotations;
using UnityEngine;




public class MariposaColision : MonoBehaviour
{
    private bool yaContada = false;

    [SerializeField] private float tiempoVida = 10f;

    // Sonido al cazar la mariposa
    public AudioClip sonidoCazar;

    private void Start()
    {
        // Destruye la mariposa si no ha sido cazada ni ha tocado el suelo
        Destroy(gameObject, tiempoVida);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (yaContada)
            return;

        if (other.CompareTag("Jugador"))
        {
            GameManager.SumarPuntos();
            yaContada = true;

            // Reproduce sonido al cazar
            AudioSource.PlayClipAtPoint(
                sonidoCazar,
                transform.position,
                9f
            );

            Destroy(gameObject);
        }
        else if (other.CompareTag("Suelo"))
        {
            GameManager.RestarPuntos();
            yaContada = true;
            Destroy(gameObject);
        }
        else if (other.CompareTag("Obstaculo"))
        {
            GameManager.RestarPuntos();
            yaContada = true;
            Destroy(gameObject);
        }
    }
}



    

