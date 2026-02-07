using UnityEngine;

public class MinigameButton : MonoBehaviour
{
    public GameObject minigamePanel;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    public void OpenMinigamePanel()
    {
        minigamePanel.SetActive(true);
    }

    public void CloseMinigamePanel()
    {
        minigamePanel.SetActive(false);
    }

    public void OpenPanel1()
    {
        panel1.SetActive(true);
    }

    public void OpenPanel2()
    {
        panel2.SetActive(true);
    }

    

    public void OpenPanel3()
    {
        panel3.SetActive(true);
    }

}