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
    public void ResetAllTasks()
    {
        task1.text = "[ ] Review pending invoices";
        task2.text = "[ ] Verify employee records";
        task3.text = "[ ] Read compliance report";
        task4.text = "[ ] Search vendor 'Null Co.'";
        task5.text = "[ ] Finish audit notes";
    }
}