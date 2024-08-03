using UnityEngine;

public class TankController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 200f;
    public Transform turret;
    public Transform barrel;

    void Update()
    {
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        transform.Translate(0, 0, move);
        transform.Rotate(0, turn, 0);

        RotateTurret();
    }

    void RotateTurret()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            turret.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            turret.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }
    }
}