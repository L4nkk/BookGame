
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    [SerializeField] private AudioClip[] audioClips;
    public AudioSource dropSound;
    public FaceController faceController;

    public void OnDrop(PointerEventData eventData)
    {
            GameObject draggableItem = eventData.pointerDrag;
            Draggable draggable = draggableItem.GetComponent<Draggable>();
            draggable.parentAfterDrag = transform;  
            dropSound.clip = audioClips[Random.Range(0, audioClips.Length)];
            dropSound.Play();
            StartCoroutine(IsTalkingEffect());
    }

    private IEnumerator IsTalkingEffect()
    {
        faceController.isTalking = true;
        yield return new WaitForSeconds(1f);
        faceController.isTalking = false;
    }
}
