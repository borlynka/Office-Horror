using UnityEngine;
using TMPro;

public class HorrorDebugDisplay : MonoBehaviour
{
    public TextMeshProUGUI debugText;

    void Update()
    {
        if (debugText == null)
            return;

        debugText.text =
            "Fear: " + HorrorProgress.fearLevel +
            "\nSuspicion: " + HorrorProgress.suspicionLevel +
            "\nOn Computer: " + HorrorProgress.playerOnComputer +
            "\nThreat Check: " + HorrorProgress.shouldStartThreatCheck;
    }
}