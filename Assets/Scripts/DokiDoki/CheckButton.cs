using UnityEngine;

public class CheckButton : MonoBehaviour
{
    public GameObject[] slots;
    [SerializeField] private BookStats bookStats;
    private int correctCount = 0;
    private int wrongCount = 0;

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
                wrongCount++;
            }
            else
            {
                Debug.Log("Correct!");
                correctCount++;
            }
        }
        Points();
    }

    public void Points()
    {
        if (wrongCount == 0)
        {
            bookStats.AddLovePoints(20);
        }
        else if (correctCount == 0)
        {
            bookStats.DecrementLovePoints(20);
        }
        else
        {
            bookStats.AddLovePoints(10);
        }
    }
}
