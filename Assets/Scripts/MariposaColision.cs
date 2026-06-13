using JetBrains.Annotations;
using UnityEngine;

public class MariposaColision : MonoBehaviour
{
    bool yaContada = false;

    void OnTriggerEnter(Collider other)
    {
        if (yaContada) return;

        if (other.CompareTag("Jugador"))
        {
            GameManager.SumarPuntos();
            yaContada = true;
            Destroy(gameObject);

            //Reproduce sonido al cazar
            AudioSource.PlayClipAtPoint(sonidoCazar, transform.position, 9f);
        }

        if (other.CompareTag("Suelo"))
        {
            GameManager.RestarPuntos();
            yaContada = true;
            Destroy(gameObject);
        }

        Debug.Log("TOCÓ: " +  other.name);
     
    }

    // Sonido al cazar la mariposa
    public AudioClip sonidoCazar;
}

    

