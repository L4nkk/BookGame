using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    public GameObject[] panels;
    public Button[] buttons;
    public GameObject selectPanel;
    private int currentPanelIndex = 0;
    private int highestUnlockedPanel = 0;
    private bool[] completed;

    private void Start()
    {
        completed = new bool[panels.Length];

        highestUnlockedPanel = PlayerPrefs.GetInt("HighestUnlockedPanel", 0);
        
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }

        UpdateButtons();
    }

    public void OpenSelectPanel()
    {
        selectPanel.SetActive(true);
    }

    public void OpenPanel(int index)
    {
        if (index < 0 || index >= panels.Length)
        {
            Debug.LogError("Invalid panel index!");
            return;
        }

        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == index);
        }

        currentPanelIndex = index;
        panels[currentPanelIndex].SetActive(true);
    }

    public void CompleteCurrentPanel()
    {
        panels[currentPanelIndex].SetActive(false);

        completed[currentPanelIndex] = true;

        if (currentPanelIndex + 1 < panels.Length)
        {
            highestUnlockedPanel = currentPanelIndex + 1;
            PlayerPrefs.SetInt("HighestUnlockedPanel", highestUnlockedPanel);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("All minigames completed!");
        }

        UpdateButtons();
    }

    public bool IsCurrentPanelCompleted()
    {
        return completed[currentPanelIndex];
    }

    private void UpdateButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = !completed[i];
        }
    }
}
