using UnityEngine;

public class Completed : MonoBehaviour
{
    [SerializeField] private GameObject textoVictoria;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fox")
        {
            if (textoVictoria != null)
            {
                textoVictoria.SetActive(true);
            }

            Time.timeScale = 0f;
        }
    }
}
