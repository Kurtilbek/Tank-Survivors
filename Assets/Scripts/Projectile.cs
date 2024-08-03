using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;
    public float lifeTime = 5f; // Время жизни снаряда в секундах
    public string shooterTag; // Тег стреляющего объекта

    void Start()
    {
        // Уничтожаем снаряд через lifeTime секунд
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Проверяем тег объекта, в который попал снаряд
        if (collision.gameObject.CompareTag(shooterTag))
        {
            return; // Не наносим урон, если это свой объект
        }

        Health targetHealth = collision.gameObject.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }

        // Уничтожаем снаряд после столкновения
        Destroy(gameObject);
    }
}