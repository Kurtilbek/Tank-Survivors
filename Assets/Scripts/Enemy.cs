using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDestroyedHandler();
    public event EnemyDestroyedHandler OnEnemyDestroyed;

    public Transform player;
    public Transform turret;
    public float moveSpeed = 3f;
    public float turnSpeed = 100f;
    public float rotationSpeed = 5f;

    void Start()
    {
        // Поиск объекта игрока по тегу "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found. Make sure the player has the tag 'Player'.");
        }
    }

    void Update()
    {
        MoveTowardsPlayer();
        AimAtPlayer();
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // Игнорируем ось Y для поворота
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, player.position) > 2f) // Минимальная дистанция до игрока
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }
    }

    void AimAtPlayer()
    {
        if (player != null)
        {
            Vector3 direction = player.position - turret.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(turret.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
            turret.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
    }
    void OnDestroy()
    {
        if (OnEnemyDestroyed != null)
        {
            OnEnemyDestroyed();
        }
    }
}