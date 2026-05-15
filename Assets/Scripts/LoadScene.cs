using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void OpenEmail()
    {
        SceneManager.LoadScene("email_bgg");
    }
    public void GoBack()
{
    SceneManager.LoadScene("computer screen");
}
}