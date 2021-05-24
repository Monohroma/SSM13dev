using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    #region SingleTone

    public static SettingsManager Instant
    {
        get { return _instant; }
    }
    private static SettingsManager _instant;

    private void Awake()
    {
        if (_instant == null)
        {
            _instant = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this);
    }

    #endregion

    public static FullScreenMode fullScreen = FullScreenMode.FullScreenWindow;
    public static float volume = 1;

    public static void ApplySettings()
    {
        Screen.fullScreenMode = fullScreen;
    }
}
