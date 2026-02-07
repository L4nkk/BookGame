using UnityEngine;

public class MinigameButton : MonoBehaviour
{
    public GameObject minigamePanel;

    public void OpenMinigamePanel()
    {
        minigamePanel.SetActive(true);
    }

    public void CloseMinigamePanel()
    {
        minigamePanel.SetActive(false);
    }
}
