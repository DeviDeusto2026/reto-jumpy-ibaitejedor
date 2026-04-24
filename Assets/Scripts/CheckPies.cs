using UnityEngine;

public class CheckPies : MonoBehaviour
{
    public Collider cuerpoDelZorro; 

    // Cuando los pies entran en la zona de la plataforma
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            // Si el zorro está cayendo o quieto, activamos el cuerpo sólido
            Rigidbody rb = cuerpoDelZorro.GetComponent<Rigidbody>();
            if (rb.linearVelocity.y <= 0.1f)
            {
                Physics.IgnoreCollision(cuerpoDelZorro, other, false);
            }
            else
            {
                // Si está subiendo, que lo ignore
                Physics.IgnoreCollision(cuerpoDelZorro, other, true);
            }
        }
    }
}
