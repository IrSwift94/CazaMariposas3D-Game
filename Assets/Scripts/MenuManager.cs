using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour 
{
    // Carga la escena del juego al pulsar "Jugar"
    public void CargarJuego()
    {
        SceneManager.LoadScene("Game");
    }

    // Carga la pantalla de instrucciones al pulsar "Instrucciones"
    public void CargarInstrucciones()
    {
        SceneManager.LoadScene("Instrucciones");
    }

    // Vuelve al menú principal (se usará desde la escena Instrucciones)
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
