using UnityEngine;
using UnityEngine.UI;

public class ImageFill : MonoBehaviour
{
    [SerializeField] private Image _imageToFill;

    private void Awake()
    {
        if (_imageToFill == null)
        {
            _imageToFill = GetComponent<Image>();
        }
    }

    public void UpdateFill(float amount)
    {
        float fillAmountDivided = amount / 100f;
        _imageToFill.fillAmount = Mathf.Clamp01(fillAmountDivided);
    }
}
