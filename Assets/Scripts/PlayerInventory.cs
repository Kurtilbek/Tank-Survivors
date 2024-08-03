using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int gearsCollected = 0;
    public int maxGears = 10; // Максимальное количество шестерёнок для заполнения полоски
    public Image experienceBar; // Ссылка на UI элемент полоски опыта

    private void Start()
    {
        UpdateExperienceBar();
    }

    public void AddGear()
    {
        gearsCollected++;
        UpdateExperienceBar();
        Debug.Log("Gears collected: " + gearsCollected);
    }

    private void UpdateExperienceBar()
    {
        if (experienceBar != null)
        {
            experienceBar.fillAmount = (float)gearsCollected / maxGears;
        }
    }
}