using UnityEngine;

public class JugadorController : MonoBehaviour 
{
    //Velocidad de movimiento del jugador
    public float velocidad = 5f;

    // Referencia al Animator del personaje chibi
    public Animator animator;

    void Start()
    {
        //Busca el Animator en los hijos del jugador
        animator = GetComponentInChildren<Animator>(true);
        if (animator == null)
            Debug.Log("Animator es NULL");

        else
            Debug.Log("Animator encontrado: " + animator.gameObject.name);

        Debug.Log("Animator gameobject: " + animator.gameObject.name);
        Debug.Log("Controller: " + animator.runtimeAnimatorController);

        

    }



    void Update()
    {
        

        //Obtiene el input horizontal (A/D) y vertical (W/S)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Debug.Log("H: " + horizontal + " V: " + vertical);

        // Calcula el movimiento
        Vector3 movimiento = new Vector3(horizontal, 0, vertical);


        // Mueve el jugador en las 4 direcciones fijas
        transform.Translate(movimiento * velocidad * Time.deltaTime, Space.World);

        // Actualiza el parámetro Velocidad del Animator
        float mag = movimiento.magnitude;
        Debug.Log("Magnitude: " + mag);
        animator.SetFloat("Velocidad", mag);



        Debug.Log("SetFloat Velocidad: " + movimiento.magnitude);
        Debug.Log("Movimiento: " + movimiento);

        Debug.Log("Animator objeto: " + animator.gameObject.name);


        //Rota el personaje hacia la dirección de movimiento
        if (movimiento != Vector3.zero)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(movimiento);
            rotacionObjetivo *= Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, 10f * Time.deltaTime);
        }

    }

}
