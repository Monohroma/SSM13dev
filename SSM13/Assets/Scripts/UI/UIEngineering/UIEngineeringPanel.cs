using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ark;

public class UIEngineeringPanel : MonoBehaviour
{
    public Bay bay_orig;
    public Text name_text;
    public Text num_text;

    public void Setup(Bay bay)
    {
        bay_orig = bay;
        name_text.text = bay.BayName;
        num_text.text = bay.Energy.ToString();
    }

    public void UpdateParametrs()
    {
        name_text.text = bay_orig.BayName;
        num_text.text = bay_orig.Energy.ToString();
    }
}
