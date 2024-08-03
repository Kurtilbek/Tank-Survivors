using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarFilling;
    [SerializeField] private Health health;

    private Camera camera;

    private void Awake()
    {
        if (health != null)
        {
            health.HealthChanged += OnHealthChanged;
        }
        else
        {
            Debug.LogError("Health is not assigned in the inspector.");
        }

        camera = Camera.main;
        if (camera == null)
        {
            Debug.LogError("Main camera not found.");
        }

        if (healthBarFilling == null)
        {
            Debug.LogError("Health bar filling image is not assigned in the inspector.");
        }
    }

    private void OnDestroy()
    {
        if (health != null)
        {
            health.HealthChanged -= OnHealthChanged;
        }
    }

    private void OnHealthChanged(float valueAsPercentage)
    {
        if (healthBarFilling != null)
        {
            healthBarFilling.fillAmount = valueAsPercentage;
        }
    }

    private void LateUpdate()
    {
        if (camera != null)
        {
            transform.LookAt(new Vector3(transform.position.x, camera.transform.position.y, camera.transform.position.z));
            transform.Rotate(0, 180, 0);
        }
    }
}