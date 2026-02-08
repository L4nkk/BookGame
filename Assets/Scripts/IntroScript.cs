using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public GameObject introPanel;

    public void Start()
    {
        introPanel.SetActive(true);
    }

    public void CloseIntroPanel()
    {
        introPanel.SetActive(false);
    }
}
