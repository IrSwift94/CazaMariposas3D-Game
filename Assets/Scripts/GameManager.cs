using UnityEngine;
using TMPro;

public class GameManager: MonoBehaviour
{
    


    // Puntuación actual del jugador
    private static int puntuacion = 0;

    // Tiempo restante de la partida
    [SerializeField] private float tiempoRestante = 90f;

    // Referencias a los textos de la UI
    [SerializeField] private TextMeshProUGUI textoPuntuacion;
    [SerializeField] private TextMeshProUGUI textoTiempo;

    //Panel que se muestra al acabar la partida
    [SerializeField] private GameObject panelFinPartida;

    // Texto de puntuación final
    [SerializeField] private TextMeshProUGUI textoPuntuacionFinal;

    //Panel de pausa
    [SerializeField] private GameObject panelPausa;

    // Estado de pausa
    private bool pausado = false;

    private void Start()
    {
        Time.timeScale = 1; // Asegura que el tiempo está activo al iniciar
        
        //Inicializa la puntuacion a 0
        puntuacion = 0;

        //Oculta el panel de fin de partida al inicio
        panelFinPartida.SetActive(false);

        //Actualiza la UI
        ActualizarUI();
        
    }

    private void Update()
    {
        //Pausa y reanuda con Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
                Reanudar();
            else
                Pausar();
        
        }



        // Si aún queda tiempo, descuenta
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            ActualizarUI();

        }
        else
        {
            //Tiempo agotado, termina la partida
            FinPartida();
        }

    }

    //Actualiza los textos de puntuación y tiempo en pantalla
    private void ActualizarUI() 
    {
        textoPuntuacion.text = "Puntuación: " + puntuacion;
        textoTiempo.text = "Tiempo: " + Mathf.CeilToInt(tiempoRestante);

    }

    // Suma 5 puntos al cazar una mariposa
    public static void SumarPuntos()
    {
        puntuacion += 5;

    }

    // Resta 1 punto cuando la mariposa toca el suelo
    
    public static void RestarPuntos()
    {
        puntuacion -= 1;
    }

    //Muestra el panel de fin de partida
    private void FinPartida()
    {
        tiempoRestante = 0;
        panelFinPartida.SetActive(true);
        textoPuntuacionFinal.text = "Puntuación Final: " + puntuacion;
        Time.timeScale = 0; // Pausa el juego
    }

    //Vuelve al menú principal
    public void VolverAlMenu()
    {
        Time.timeScale = 1; // Reactiva el tiempo antes de cambiar de escena
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");

    }

    //Cierra el juego
    public void SalirDelJuego()
    {
        Application.Quit();

    }


    //Pausa el juego
    public void Pausar()
    {
        pausado = true;
        panelPausa.SetActive(true);
        Time.timeScale = 0;
    }

    //Reanuda el juego
    public void Reanudar()
    {
        pausado = false;
        panelPausa.SetActive(false);
        Time.timeScale = 1;
    }


}
