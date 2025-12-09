using NUnit.Framework.Constraints;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 8f;

    private Rigidbody rb;

    private bool isMovingForward = true;

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
            Movement();
        }

    }

    private void Movement()
    {
        if(isMovingForward)
        {
            rb.linearVelocity = Vector3.right * speed;

            isMovingForward = false;
        }
        else
        {
            rb.linearVelocity = Vector3.forward * speed;

            isMovingForward = true;
        }
    }
}