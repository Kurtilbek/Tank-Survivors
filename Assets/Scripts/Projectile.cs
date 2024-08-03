using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;
    public float lifeTime = 5f; // ����� ����� ������� � ��������
    public string shooterTag; // ��� ����������� �������

    void Start()
    {
        // ���������� ������ ����� lifeTime ������
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // ��������� ��� �������, � ������� ����� ������
        if (collision.gameObject.CompareTag(shooterTag))
        {
            return; // �� ������� ����, ���� ��� ���� ������
        }

        Health targetHealth = collision.gameObject.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }

        // ���������� ������ ����� ������������
        Destroy(gameObject);
    }
}