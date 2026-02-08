using UnityEngine;
using System.Collections;

public class UITransitionController : MonoBehaviour
{
    public RectTransform selectionPanel;
    public RectTransform minigamePanel;

    public float transitionDuration = 0.4f;
    public float screenHeight = 1080f;

    bool isTransitioning = false;

    public void GoToMinigame()
    {
        if (isTransitioning) return;
        StartCoroutine(SwipeTransition(
            selectionPanel, new Vector2(0, screenHeight),
            minigamePanel, Vector2.zero
        ));
    }

    public void BackToSelection()
    {
        if (isTransitioning) return;
        StartCoroutine(SwipeTransition(
            selectionPanel, Vector2.zero,
            minigamePanel, new Vector2(0, -screenHeight)
        ));
    }

    IEnumerator SwipeTransition(
        RectTransform panelOut, Vector2 outTarget,
        RectTransform panelIn, Vector2 inTarget)
    {
        isTransitioning = true;

        Vector2 outStart = panelOut.anchoredPosition;
        Vector2 inStart = panelIn.anchoredPosition;

        float time = 0f;

        while (time < transitionDuration)
        {
            float t = time / transitionDuration;
            t = Mathf.SmoothStep(0, 1, t);

            panelOut.anchoredPosition =
                Vector2.Lerp(outStart, outTarget, t);

            panelIn.anchoredPosition =
                Vector2.Lerp(inStart, inTarget, t);

            time += Time.deltaTime;
            yield return null;
        }

        panelOut.anchoredPosition = outTarget;
        panelIn.anchoredPosition = inTarget;

        isTransitioning = false;
    }
}
