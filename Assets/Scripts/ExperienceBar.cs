using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public PlayerInventory playerInventory; // ������ �� ��������� ��������� ������
    public Image experienceBar; // ������ �� UI ������� ������� �����

    void Update()
    {
        if (playerInventory != null && experienceBar != null)
        {
            experienceBar.fillAmount = (float)playerInventory.gearsCollected / playerInventory.maxGears;
        }
    }
}