using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject plataformaPrefab;
    public Transform plataformaInicial; 
    public int cantidadNuevas = 5;
    public float distancia = 3f;
    public float amplitud = 2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Generar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generar()
    {
        for (int i = 1; i <= cantidadNuevas; i++)
        {
            // Calculamos partiendo de la posición de la plataforma que ya existe
            // Usamos i (empezando en 1) para que la primera copia esté a 3m de la original
            float desplazamientoVertical = i * distancia;
            float desplazamientoLateral;

            // Si 'i' es par, va a la derecha. Si es impar, a la izquierda.
            if (i % 2 == 0)
            {
                desplazamientoLateral = -amplitud;
            }
            else
            {
                desplazamientoLateral = amplitud;
            }

            // Calculamos la posición: 
            // X = desplazamiento lateral
            // Y = desplazamiento vertical (hacia arriba)
            // Z = desplazamiento hacia adelante (para que sea escalera)
            Vector3 nuevaPosicion = plataformaInicial.position + new Vector3(desplazamientoLateral, desplazamientoVertical, 0);

            Instantiate(plataformaPrefab, nuevaPosicion, plataformaPrefab.transform.rotation);
        }
    }
    
}
