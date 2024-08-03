using UnityEngine;

public class PlayerTurretController : MonoBehaviour
{
    public Transform turret;
    public Camera mainCamera;
    public float turnSpeed = 100f;

    void Update()
    {
        RotateTurretTowardsCursor();
    }

    void RotateTurretTowardsCursor()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 targetPosition = hitInfo.point;
            targetPosition.y = turret.position.y; // Игнорируем ось Y для поворота
            Vector3 direction = targetPosition - turret.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            turret.rotation = Quaternion.RotateTowards(turret.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }
}