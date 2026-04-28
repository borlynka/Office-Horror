using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public GameObject accountingWindow;
    public GameObject employeeWindow;
    public GameObject emailWindow;
    public GameObject hiddenFolderWindow;

    public void OpenWindow(GameObject window)
    {
        CloseAll();
        window.SetActive(true);
    }

    public void CloseAll()
    {
        accountingWindow.SetActive(false);
        employeeWindow.SetActive(false);
        emailWindow.SetActive(false);
        hiddenFolderWindow.SetActive(false);
    }
}