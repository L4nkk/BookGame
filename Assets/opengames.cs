using UnityEngine;

public class opengames : MonoBehaviour
{
    public GameObject WriteGame;
    public GameObject DragGame;

    public void OpenWriteGame()
    {
        WriteGame.SetActive(true);
    }

    public void OpenDragGame()
    {
        DragGame.SetActive(true);
    }

    public void CloseWriteGame()
    {
        WriteGame.SetActive(false);
    }

    public void CloseDragGame()
    {
        DragGame.SetActive(false);
    }
}
