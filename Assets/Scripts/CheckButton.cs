using UnityEngine;

public class CheckButton : MonoBehaviour
{
    public GameObject[] slots;

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
                return;
            }
            else
            {
                Debug.Log("Correct!");
            }
        }
    }
}
