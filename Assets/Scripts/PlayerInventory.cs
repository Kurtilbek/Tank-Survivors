using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int gearsCollected = 0;
    public int maxGears = 10; // ������������ ���������� ��������� ��� ���������� �������
    public Image experienceBar; // ������ �� UI ������� ������� �����

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