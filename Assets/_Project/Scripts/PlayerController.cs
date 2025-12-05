using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    
    [SerializeField]
    [Range(0f, 10f)] private float speed = 8f; 
    
    //
    private Rigidbody rb;

    private bool movingForward = true;

    private void Awake() 
    {        
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        
        rb.linearVelocity = Vector3.forward * speed;
    }

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }


    private void ChangeDirection()
    {
        // PHYSICS FIX:
        // Reset the angular velocity (rotation speed) to zero.
        // This prevents the ball from "drifting" or "sliding" due to momentum when turning.
        rb.angularVelocity = Vector3.zero;

        if (movingForward)
        {
            rb.linearVelocity = Vector3.right * speed;

            movingForward = false;
        }
        else
        {
            rb.linearVelocity = Vector3.forward * speed;

            movingForward = true;
        }
    }
}
