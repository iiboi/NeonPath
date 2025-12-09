using UnityEngine;

public class PlatformSpawnController : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            FindAnyObjectByType<PlatformSpawner>().PlatformSpawn();
            Invoke(nameof(PlatformFall), 1.5f);
            Invoke(nameof(PlatformDestroy), 3.5f);
        }

    }

    private void PlatformFall()
    {
        rb.isKinematic = false;
    }

    private void PlatformDestroy()
    {
        Destroy(gameObject);
    }
}
