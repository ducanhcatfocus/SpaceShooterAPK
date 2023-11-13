using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;

    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;

    private void Start()
    {
        GameManager.Instance.RegisterPanelController(this);
    }


    public void ActivateWinScreen()
    {
        canvasGroup.alpha = 1;
        winPanel.SetActive(true);
    }

    public void ActivateLoseScreen()
    {
        canvasGroup.alpha = 1;
        losePanel.SetActive(true);
    }
}
