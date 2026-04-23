using UnityEngine;

public class PassPlatform : MonoBehaviour
{
    private Collider colisionadorPlataforma;

    void Start()
    {
        colisionadorPlataforma = GetComponent<Collider>();
    }

    void Update()
    {
        // Buscamos al zorro por su Tag
        GameObject zorro = GameObject.FindWithTag("Fox");

        if (zorro != null)
        {
            // Si la parte de arriba del zorro es más baja que la plataforma...
            if (zorro.transform.position.y < transform.position.y)
            {
                // ...hacemos que la plataforma sea un fantasma (Trigger)
                colisionadorPlataforma.isTrigger = true;
            }
            else
            {
                // ...si ya pasó hacia arriba, la hacemos sólida
                colisionadorPlataforma.isTrigger = false;
            }
        }
    }

}
