using UnityEngine;




public class JugadorController : MonoBehaviour
{
    // Velocidad de movimiento del jugador
    [SerializeField] private float velocidad = 5f;

    // Referencia al Animator del personaje
    private Animator animator;

    // Movimiento del jugador
    private Vector3 movimiento;

    // Rigidbody del jugador
    private Rigidbody rb;

    private void Start()
    {
        // Busca el Animator en los hijos del jugador
        animator = GetComponentInChildren<Animator>(true);

       

        // Obtiene el Rigidbody
        rb = GetComponent<Rigidbody>();

        // Interpolación para suavizar el movimiento visual
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void Update()
    {
        // Leer INPUT en Update
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Crear dirección de movimiento
        movimiento = new Vector3(horizontal, 0f, vertical);

        // Evita que la diagonal sea más rápida
        movimiento = Vector3.ClampMagnitude(movimiento, 1f);

        // Rotar el personaje hacia la dirección de movimiento
        if (movimiento != Vector3.zero)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(movimiento);

            // Si el modelo mira hacia atrás
            rotacionObjetivo *= Quaternion.Euler(0f, 180f, 0f);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                rotacionObjetivo,
                10f * Time.deltaTime
            );
        }

        // Animator
        if (animator != null)
        {
            //Actualizar velocidad del Animator
             animator.SetFloat("Velocidad", movimiento.magnitude);
        }
    }

    private void FixedUpdate()
    {
        if (movimiento.sqrMagnitude < 0.0001f)
            return;

        Vector3 direccion = movimiento.normalized;
        float distancia = velocidad * Time.fixedDeltaTime;

        // Comprobar si hay una pared delante
        if (rb.SweepTest(
            direccion,
            out RaycastHit hit,
            distancia,
            QueryTriggerInteraction.Ignore))
        {
            // Convertimos el movimiento en un movimiento paralelo a la pared
            Vector3 direccionDeslizamiento =
                Vector3.ProjectOnPlane(direccion, hit.normal);

            direccionDeslizamiento.y = 0f;

            if (direccionDeslizamiento.sqrMagnitude > 0.0001f)
            {
                direccionDeslizamiento.Normalize();

                // Deslizamiento por la pared
                rb.MovePosition(
                    rb.position + direccionDeslizamiento * distancia
                );
            }

            return;
        }

        // Movimiento normal
        rb.MovePosition(
            rb.position + direccion * distancia
        );
    }
}





