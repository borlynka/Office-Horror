using UnityEngine;
using UnityEngine.UI;

public class Transaction : MonoBehaviour
{
    public bool isSuspicious = false;
    private Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(CheckTransaction);
    }

    void CheckTransaction()
    {
        if (isSuspicious)
        {
            Debug.Log("Correct suspicious click");
            gameObject.GetComponent<Image>().color = Color.red;
            LevelManager.Instance.AddCorrect();
        }
        else
        {
            Debug.Log("Wrong click");
        }
    }
}