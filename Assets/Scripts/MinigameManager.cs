using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public GameObject[] panels;
    private int currentPanelIndex = 0;
    private bool[] completed;

    private void Start()
    {
        completed = new bool[panels.Length];
        
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == currentPanelIndex);
        }
    }

    public void CurrentPanel()
    {
        completed[currentPanelIndex] = true;
        panels[currentPanelIndex].SetActive(false);

        currentPanelIndex++;

        if (currentPanelIndex < panels.Length)
        {
            panels[currentPanelIndex].SetActive(true);
        }
        else
        {
            Debug.Log("All minigames completed!");
        }
    }

    public bool IsCurrentPanelCompleted()
    {
        return completed[currentPanelIndex];
    }
}
