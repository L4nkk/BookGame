using UnityEngine;

public class CheckButton : MonoBehaviour
{
    public GameObject[] slots;
    public MinigameManager minigameManager;

    public void Check()
    {
        foreach (var slot in slots)
        {
            if (slot.transform.childCount == 0)
            {
                continue;
            }

            if(slot.transform.GetChild(0).GetComponent<ItemGenre>().Genre != slot.GetComponent<SlotGenre>().Genre)
            {
                Debug.Log("Wrong!");
            }
            else
            {
                Debug.Log("Correct!");
            }
        }

        minigameManager.CompleteCurrentPanel();
    }
}
