using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettingsPanel : MonoBehaviour
{
    public Dropdown windowMode;
    public Slider volume;

    public void SaveSettings()
    {
        switch (windowMode.value)
        {
            case 0:
                SettingsManager.fullScreen = FullScreenMode.FullScreenWindow;
                break;
            case 1:
                SettingsManager.fullScreen = FullScreenMode.Windowed;
                break;
            case 2:
                SettingsManager.fullScreen = FullScreenMode.MaximizedWindow;
                break;
        }
    }

    public void ShowPanel()
    {
        gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }
}
