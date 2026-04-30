using UnityEngine;

public class HideAfterSeconds : MonoBehaviour
{
    public float seconds = 6f;

    void Start()
    {
        Destroy(gameObject, seconds);
    }
}