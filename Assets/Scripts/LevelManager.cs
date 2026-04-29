using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int correctClicks = 0;
    public int requiredClicks = 2;

    public GameObject employeeRecordsButton;

    void Awake()
    {
        Instance = this;
    }

    public void AddCorrect()
    {
        correctClicks++;

        if (correctClicks >= requiredClicks)
        {
            UnlockNext();
        }
    }

    void UnlockNext()
    {
        Debug.Log("Level 1 Complete");
        employeeRecordsButton.SetActive(true);
    }
}