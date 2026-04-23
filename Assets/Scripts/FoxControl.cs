using UnityEngine;

public class FoxControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float velocidad = 5f;
    public float fuerzaSalto = 10f;
    private Rigidbody rb;
    private bool estaEnSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento horizontal
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movH, 0, movV) * velocidad;

        // Mantener la velocidad de caída (Y) actual del rigidbody
        rb.linearVelocity = new Vector3(movimiento.x, rb.linearVelocity.y, movimiento.z);

        // Salto (solo si presiona Espacio y está en el suelo)
        if (Input.GetButtonDown("Jump") && estaEnSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            estaEnSuelo = false;
        }
    }

    // Detección simple de suelo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.name.Contains("Platform"))
        {
            estaEnSuelo = true;
        }
    }
}
