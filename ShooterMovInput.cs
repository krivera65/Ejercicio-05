using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterMovInput : MonoBehaviour
{
    public float speed;                            // Velocidad de movimiento.
    public float rotationSpeed;                    // Velocidad de rotación.
    public float jumpForce = 10.0f;                // Fuerza del salto.
    private Vector2 movementValue;                 // Valor de entrada de movimiento.
    private float lookValue;                       // Valor de entrada de mirar.
    public GameObject prefab;                      // Prefab del proyectil.
    public GameObject shootPoint;                  // Punto de disparo.
    private Rigidbody rb;                          // Componente Rigidbody.
    public LayerMask groundLayer;                  // Capa del suelo.
    public float fastSpeedMultiplier = 2.0f;       // Multiplicador de velocidad rápida.
    public InputAction moveAction;                 // Debes asignar la acción de movimiento en el Inspector.

    private bool isJumping = false;                // Indica si está en el aire.
    private int jumpsLeft = 2;                     // Dos saltos permitidos.
    private int jumpsMade = 0;                     // Número de saltos realizados.
    public float fallForce = 20.0f;                // Fuerza hacia abajo al caer.

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        // Captura la entrada de movimiento y ajusta la velocidad.
        Vector2 inputDirection = value.Get<Vector2>() * speed;
        movementValue.x = inputDirection.x * speed;
        movementValue.y = inputDirection.y * speed;
    }

    public void OnLook(InputValue value)
    {
        // Captura la entrada de mirar y ajusta la velocidad de rotación.
        lookValue = value.Get<Vector2>().x * rotationSpeed;
    }

    public void OnFire(InputValue value)
    {
        // Cuando se presiona el botón de disparo, crea un clon del prefab y lo dispara.
        if (value.isPressed)
        {
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
        }
    }

    public void OnJump(InputValue value)
    {
        if (jumpsLeft > 0 && !isJumping)
        {
            // Verifica si quedan saltos disponibles y si no se está saltando actualmente.
            // Si es cierto, permite el salto.
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Actualiza el estado de salto y los saltos realizados.
            isJumping = true;
            jumpsLeft--;
            jumpsMade++;
        }
        else if (jumpsMade < 2)
        {
            // Si no quedan saltos disponibles pero se han realizado menos de 2 saltos,
            // reinicia la velocidad vertical y aplica otra fuerza de salto.
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Incrementa el contador de saltos realizados.
            jumpsMade++;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Restablece el estado de salto y los saltos disponibles al tocar el suelo.
        isJumping = false;
        jumpsLeft = 2;
        jumpsMade = 0;
    }

    void FixedUpdate()
    {
        // Aplica una fuerza hacia abajo constante para simular la gravedad.
        rb.AddForce(Vector3.down * fallForce);
    }

    void Update()
    {
        // Mueve y rota el objeto según las entradas de movimiento y mirar.
        transform.Translate(
            movementValue.x * Time.deltaTime,
            0,
            movementValue.y * Time.deltaTime);
        transform.Rotate(0, lookValue * Time.deltaTime, 0);
    }
}
