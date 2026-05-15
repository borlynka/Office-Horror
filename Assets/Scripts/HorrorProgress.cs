public static class HorrorProgress
{
    public static int fearLevel = 0;
    public static int suspicionLevel = 0;
    public static int computerExitCount = 0;

    public static bool shouldStartThreatCheck = false;
    public static bool hasShownControlTips = false;
    public static bool completedComputerTask = false;
    public static bool playerOnComputer = false;

    public static bool passByWarningUsedThisExit = false;

    public static bool finalBossMode = false;

    public static bool computerLocked = false;
    public static bool monitorFailurePlayed = false;
    public static void Reset()
    {
        fearLevel = 0;
        suspicionLevel = 0;
        computerExitCount = 0;

        shouldStartThreatCheck = false;
        hasShownControlTips = false;
        completedComputerTask = false;
        playerOnComputer = false;

        passByWarningUsedThisExit = false;
        finalBossMode = false;

        computerLocked = false;
        monitorFailurePlayed = false;
    }

}