using UnityEngine;
using UnityEngine.UI;

public class EmailClick : MonoBehaviour
{
    public Image backgroundImage;

    public Sprite nextScreen;

    public void ChangeScreen()
    {
        backgroundImage.sprite = nextScreen;
    }
}