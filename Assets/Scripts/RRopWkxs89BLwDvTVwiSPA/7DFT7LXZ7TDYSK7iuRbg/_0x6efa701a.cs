using UnityEngine;

public class _0x6efa701a : MonoBehaviour
{
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this.gameObject.GetComponent<_0x6efa701a>();
            DontDestroyOnLoad(this.gameObject);
            this._0xdcd0ffdb();
        }
        else
        {
            this._0xc64af2f9();
            Destroy(this.gameObject);
        }
    }

    public bool IsLevelSelectorEnabled;
    public bool IsLevelIncrementOnWin;
    public bool IsTutorialEnabled;
    public bool IsSkipSplashEnabled;
    public bool IsStoryEnabled;
    private void _0xc64af2f9()
    {
    }

    public static _0x6efa701a Instance;
    public bool IsTimerEnabled;
    public bool IsOnlyWinGameEndEnabled;
    private void _0xdcd0ffdb()
    {
        {
#if !B_LOGS
        {
            Debug.unityLogger.logEnabled = false;
            Application.SetStackTraceLogType(LogType.Assert, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Exception, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Warning, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Error, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
        }
#endif
        }

        QualitySettings.vSyncCount = 1;
        Application.runInBackground = true;
    //Application.targetFrameRate = 60;
    // Time.fixedDeltaTime = 0.03f; // USE CUSTOM PHYSICS TIME FOR OPTIMIZATION IF NEEDED
    // Add this once at startup to silence the specific assertion
    }

    public bool IsBestScoreEnabled;
    public bool IsCheckScoreEnabled;
}