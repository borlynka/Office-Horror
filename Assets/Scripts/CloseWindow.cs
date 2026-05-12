using UnityEngine;

public class CloseWindow : MonoBehaviour
{
    public GameObject windowToClose;

    public void Close()
    {
        windowToClose.SetActive(false);
    }
}