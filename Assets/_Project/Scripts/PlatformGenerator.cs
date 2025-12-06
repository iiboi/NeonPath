using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float offset = 2.5f;
    [SerializeField] private Vector3 lastPos;

    [Header("References")]
    [SerializeField] private GameObject platformPrefab;

    private void Start() 
    {
        for (int i = 0; i < 20; i++)
        {
            CreateNewPlatform();
        }
    }

    public void CreateNewPlatform()
    {
        int randomDirection = Random.Range(0, 2);

        if (randomDirection == 0)
        {
            lastPos.x += offset;
        }
        else
        {
            lastPos.z += offset;
        }

        Instantiate(platformPrefab, lastPos, Quaternion.identity);
    }
}
