using UnityEngine;
using UnityEngine.UI;

public class Transaction : MonoBehaviour
{
    public bool isSuspicious = false;

    private Button btn;
    private Image img;

    private void Start()
    {
        btn = GetComponent<Button>();
        img = GetComponent<Image>();

        if (btn != null)
            btn.onClick.AddListener(CheckTransaction);
    }

    void CheckTransaction()
    {
        if (isSuspicious)
        {
            Debug.Log("Correct suspicious click!");

            if (img != null)
                img.color = Color.red;

            if (LevelManager.Instance != null)
            {
                LevelManager.Instance.AddCorrect();
            }
            else
            {
                Debug.LogWarning("LevelManager.Instance is missing.");
            }

            if (TaskManager.Instance != null)
            {
                TaskManager.Instance.CompleteTask(1);
            }
            else
            {
                Debug.LogWarning("TaskManager.Instance is missing.");
            }
        }
        else
        {
            Debug.Log("Wrong click");
        }
    }
}