using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public PlayerInventory playerInventory; // —сылка на компонент инвентар€ игрока
    public Image experienceBar; // —сылка на UI элемент полоски опыта

    void Update()
    {
        if (playerInventory != null && experienceBar != null)
        {
            experienceBar.fillAmount = (float)playerInventory.gearsCollected / playerInventory.maxGears;
        }
    }
}