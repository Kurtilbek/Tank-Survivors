using UnityEngine;

public class Gear : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.AddGear();
                Destroy(gameObject); // ”ничтожаем шестерЄнку при сборе
            }
        }
    }
}