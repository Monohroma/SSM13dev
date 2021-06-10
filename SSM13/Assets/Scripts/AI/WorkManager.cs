using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ark;
using TMPro;
using UnityEngine.UI;
using UI;

public class WorkManager : MonoBehaviour
{
    //Скрипт назначения NPC на работу. Для каждой работы отдельный скрипт. Жмёшь плюсик - ассистент превращается в соответстующего отсеку работника (в процессе кодинга), на минус работник становится снова ассистентом
    
    public Bay Bay;
    public TextMeshProUGUI HumanInBay;
    public bool IsAssistant;
    public Button PlusButton;
    public Button MinusButton;
    private UIBridge bridge;
    public void Setup(UIBridge uib)
    {
        bridge = uib;
    }

    private void Start()
    {
        UpdateText();
    }
    public void UpdateText()
    {
        if (!IsAssistant)
        {
            if (Bay != null)
            {
                HumanInBay.text = Bay.AssignedToWork.Count.ToString() + $" /{Bay.WorkZone.Count}";

                if (Bay.WorkersInBay.Count >= Bay.WorkZone.Count)
                {
                    MinusButton.gameObject.SetActive(true);
                    PlusButton.gameObject.SetActive(false);
                }
                else if (Bay.WorkersInBay.Count <= 0)
                {
                    MinusButton.gameObject.SetActive(false);
                    PlusButton.gameObject.SetActive(true);
                }
                else
                {
                    MinusButton.gameObject.SetActive(true);
                    PlusButton.gameObject.SetActive(true);
                }
                if (GameManager.Instance.FreeAssistant.Count == 0)
                {
                    PlusButton.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            HumanInBay.text = GameManager.Instance.FreeAssistant.Count + $" /{GameManager.Instance.AllCrew.Count}";
        }
    }
    public void AddWorkerInBay()
    {
        if(GameManager.Instance.FreeAssistant.Count > 0 && Bay.WorkersInBay.Count < Bay.WorkZone.Count)
        {
            Bay.WorkersInBay.Add(GameManager.Instance.FreeAssistant[0]);

            var crew = Bay.WorkersInBay[Bay.WorkersInBay.Count - 1];


            crew.NextActions();
            var newCrew = Instantiate(Bay.WorkerPrefab, crew.transform.position, Quaternion.identity);
            Bay.AssignedToWork.Add(newCrew.GetComponent<AI.Crew>());
            newCrew.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = crew.gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
            newCrew.name = Bay.gameObject.name;
            Destroy(crew);

            GameManager.Instance.FreeAssistant.RemoveAt(0);
        }
        bridge.UpdateParams();
        UpdateText();
    }
    public void RemoveWorker()
    {
        if (Bay.WorkersInBay.Count > 0)
        {  
            GameManager.Instance.FreeAssistant.Add(Bay.WorkersInBay[0]);

            var crew = Bay.WorkersInBay[0];

            Bay.AssignedToWork.Remove(crew);
            crew.NextActions();
            var newCrew = Instantiate(GameManager.Instance.AssistantPrefab, crew.transform.position, Quaternion.identity);
            newCrew.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = crew.gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
            newCrew.name = "Assistant";
            Destroy(crew);

            Bay.WorkersInBay[0].NextActions();
            Bay.WorkersInBay.RemoveAt(0);
        }
        bridge.UpdateParams();
        UpdateText();
    }
}
