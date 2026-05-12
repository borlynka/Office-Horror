using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;

    public TextMeshProUGUI task1;
    public TextMeshProUGUI task2;
    public TextMeshProUGUI task3;
    public TextMeshProUGUI task4;
    public TextMeshProUGUI task5;

    private void Awake()
    {
        Instance = this;
    }

    public void CompleteTask(int taskNumber)
    {
        switch (taskNumber)
        {
            case 1:
                task1.text = "<s>[X] Review pending invoices</s>";
                break;

            case 2:
                task2.text = "<s>[X] Verify employee records</s>";
                break;

            case 3:
                task3.text = "<s>[X] Read compliance report</s>";
                break;

            case 4:
                task4.text = "<s>[X] Search vendor 'Null Co.'</s>";
                break;

            case 5:
                task5.text = "<s>[X] Finish audit notes</s>";
                break;
        }
    }
}