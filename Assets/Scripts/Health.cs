using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]public int maxHP = 100;
    public int currentHP; // Изменено на public
    public GameObject gearPrefab;
    public float gearDropChance = 0.5f; // Шанс выпадения шестерёнки (50%)

    public event Action<float> HealthChanged;
    
    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
        else
        {
            float currentHPAsPercantage = (float) currentHP / maxHP;
            HealthChanged?.Invoke(currentHPAsPercantage);
        }
    }

    void Die()
    {
        DropGear();
        HealthChanged?.Invoke(0);
        Destroy(gameObject); // Уничтожаем объект при смерти
    }

    void DropGear()
    {
        //if (Random.value <= gearDropChance)
        //{
        //    GameObject gear = Instantiate(gearPrefab, transform.position, Quaternion.identity);
        //    gear.GetComponent<Collider>().isTrigger = true; // Делаем шестерёнку триггером, чтобы не было коллизии
        //}
    }
}