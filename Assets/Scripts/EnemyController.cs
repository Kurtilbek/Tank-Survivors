using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float turnSpeed = 100f;

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0; // ���������� ��� Y ��� ��������
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, player.position) > 2f) // ����������� ��������� �� ������
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}