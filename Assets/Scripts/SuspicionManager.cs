using UnityEngine;
using TMPro;

public class SuspicionManager : MonoBehaviour
{
    public TextMeshProUGUI suspicionText;

    public int maxSuspicion = 10;
    public float suspicionDecayInterval = 4f;

    private float decayTimer = 0f;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        decayTimer += Time.deltaTime;

        if (decayTimer >= suspicionDecayInterval)
        {
            decayTimer = 0f;

            if (HorrorProgress.playerOnComputer)
            {
                DecreaseSuspicion(1);
            }
        }

        UpdateUI();

        if (HorrorProgress.suspicionLevel >= maxSuspicion)
        {
            Debug.Log("Too suspicious. Danger event triggered.");
            // Later: trigger NPC stare / boss / game over
        }
    }

    public void IncreaseSuspicion(int amount)
    {
        HorrorProgress.suspicionLevel += amount;
        HorrorProgress.suspicionLevel = Mathf.Clamp(HorrorProgress.suspicionLevel, 0, maxSuspicion);
        UpdateUI();
    }

    public void DecreaseSuspicion(int amount)
    {
        HorrorProgress.suspicionLevel -= amount;
        HorrorProgress.suspicionLevel = Mathf.Clamp(HorrorProgress.suspicionLevel, 0, maxSuspicion);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (suspicionText == null)
            return;

        if (HorrorProgress.suspicionLevel <= 0)
        {
            suspicionText.gameObject.SetActive(false);
            return;
        }

        suspicionText.gameObject.SetActive(true);
        suspicionText.text = "SUSPICION: " + HorrorProgress.suspicionLevel;
    }
}