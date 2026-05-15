using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowManager : MonoBehaviour
{
    public GameObject accountingWindow;
    public GameObject employeeWindow;
    public GameObject emailWindow;
    public GameObject hiddenFolderWindow;
    public int countSus;

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

    public void susPress()
    {
        countSus++;
        if(countSus>=4) SceneManager.LoadScene("Good Ending");
    }
}