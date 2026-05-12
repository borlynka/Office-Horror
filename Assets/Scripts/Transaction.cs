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
            Debug.Log("Correct suspicious click");

            if (img != null)
                img.color = Color.red;

            LevelManager.Instance.AddCorrect();

            // 🔥 THIS is what connects it to your sticky note system
            TaskManager.Instance.CompleteTask(1);
        }
        else
        {
            Debug.Log("Wrong click");
        }
    }
}