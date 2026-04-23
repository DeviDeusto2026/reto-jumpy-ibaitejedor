using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour
{
    public Transform zorro;           // Arrastra al zorro/lobo aquí
    public float suavizado = 5f;     // Velocidad de seguimiento
    private float alturaMaxima = 0f; // Registro de lo más alto que ha llegado la cámara
    private Vector3 offset;          // Distancia inicial
    public Vector3 ajusteExtra = new Vector3(0, -2f, 0);

    void Start()
    {
        if (zorro != null)
        {
            // Calculamos la distancia inicial para mantenerla
            offset = transform.position - zorro.position;
            alturaMaxima = transform.position.y;
        }
    }

    void LateUpdate()
    {
        if (zorro == null) return;

        // Calculamos a qué altura "debería" estar la cámara
        float alturaDeseada = zorro.position.y + offset.y + ajusteExtra.y;

        // Regla de oro: Solo actualizamos la altura si es superior a la máxima actual
        if (alturaDeseada > alturaMaxima)
        {
            alturaMaxima = alturaDeseada;
        }

        // Aplicamos la posición: X y Z se mantienen del offset, Y solo sube
        Vector3 posicionFinal = new Vector3(zorro.position.x + offset.x + ajusteExtra.x, alturaMaxima, zorro.position.z + offset.z + ajusteExtra.z);
        transform.position = Vector3.Lerp(transform.position, posicionFinal, suavizado * Time.deltaTime);

        // --- LÓGICA DE FIN DE JUEGO ---
        // Si el lobo cae por debajo de la cámara (fuera de la vista)
        if (zorro.position.y < transform.position.y - 10f)
        {
            Debug.Log("¡GAME OVER! El lobo se quedó fuera.");
            // Aquí podrías reiniciar el nivel:
            // UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        // LÓGICA DE GAME OVER
        // Si la posición Y del lobo es menor que la de la cámara menos un margen...
        if (zorro.position.y < transform.position.y - 7f)
        {
            Debug.Log("¡El lobo se ha caído!");
            ReiniciarJuego();
        }
    }

    void ReiniciarJuego()
    {
        // Carga la escena actual de nuevo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
