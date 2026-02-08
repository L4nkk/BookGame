using UnityEngine;

public class opengames : MonoBehaviour
{
    public GameObject WriteGame;
    public GameObject DragGame;

    public void OpenWriteGame()
    {
        WriteGame.SetActive(true);
        DragGame.SetActive(false);
    }

    public void OpenDragGame()
    {
        DragGame.SetActive(true);
        WriteGame.SetActive(false);
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
