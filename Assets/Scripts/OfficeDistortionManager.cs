using UnityEngine;

public class OfficeDistortionManager : MonoBehaviour
{
    public GameObject normalOffice;
    public GameObject crowdedOffice;
    public GameObject nightmareOffice;

    public int crowdedSuspicionLevel = 10;
    public int nightmareFearLevel = 12;

    void Start()
    {
        UpdateOfficeStage();
    }

    public void UpdateOfficeStage()
    {
        if (HorrorProgress.finalBossMode || HorrorProgress.fearLevel >= nightmareFearLevel)
        {
            SetStage(nightmareOffice);
        }
        else if (HorrorProgress.suspicionLevel >= crowdedSuspicionLevel)
        {
            SetStage(crowdedOffice);
        }
        else
        {
            SetStage(normalOffice);
        }
    }

    void SetStage(GameObject activeStage)
    {
        if (normalOffice != null)
            normalOffice.SetActive(activeStage == normalOffice);

        if (crowdedOffice != null)
            crowdedOffice.SetActive(activeStage == crowdedOffice);

        if (nightmareOffice != null)
            nightmareOffice.SetActive(activeStage == nightmareOffice);
    }
}