using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ark;
using TMPro;
using UnityEngine.UI;

public class WorkManager : MonoBehaviour
{
    public Bay Bay;
    public TextMeshProUGUI HumanInBay;
    public Button PlusButton;
    public Button MinusButton;
    private void Start()
    {
        UpdateText();
    }
    private void UpdateText()
    {
        HumanInBay.text = Bay.WorkersInBay.Count.ToString() + $" /{Bay.WorkZone.Count}";
        if(Bay.WorkersInBay.Count >= Bay.WorkZone.Count)
        {
            PlusButton.gameObject.SetActive(false);
            MinusButton.gameObject.SetActive(true);
        }
        else if(Bay.WorkersInBay.Count <= 0)
        {
            MinusButton.gameObject.SetActive(false);
            PlusButton.gameObject.SetActive(true);
        }
        else
        {
            PlusButton.gameObject.SetActive(true);
            MinusButton.gameObject.SetActive(true);
        }
    }
    public void AddWorkerInBay()
    {
        Debug.Log("Add");
        if(GameManager.Instance.FreeAssistant.Count > 0 && Bay.WorkersInBay.Count < Bay.WorkZone.Count)
        {
            Bay.WorkersInBay.Add(GameManager.Instance.FreeAssistant[0]);
            Bay.WorkersInBay[Bay.WorkersInBay.Count - 1].NextActions();
            GameManager.Instance.FreeAssistant.RemoveAt(0);
        }
        UpdateText();
    }
    public void RemoveWorker()
    {
        Debug.Log("Remove");
        if (Bay.WorkersInBay.Count > 0)
        {  
            GameManager.Instance.FreeAssistant.Add(Bay.WorkersInBay[0]);
            Bay.WorkersInBay[0].NextActions();
            Bay.WorkersInBay.RemoveAt(0);
        }
        UpdateText();
    }
}
