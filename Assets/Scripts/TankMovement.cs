using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 150f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotate = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + transform.forward * move);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, rotate, 0));
    }
}