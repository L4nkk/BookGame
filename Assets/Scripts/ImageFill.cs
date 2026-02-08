using UnityEngine;
using UnityEngine.UI;

public class ImageFill : MonoBehaviour
{
    private Image _imageToFill;

    private void Awake()
    {
        _imageToFill = GetComponent<Image>();
    }

    public void IncrementFillAmount(float amount)
    {
        float fillAmountDivided = amount / 100f;
        _imageToFill.fillAmount = Mathf.Clamp01(_imageToFill.fillAmount + fillAmountDivided);
    }
}
