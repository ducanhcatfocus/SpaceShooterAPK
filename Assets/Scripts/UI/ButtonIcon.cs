using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonIcon : MonoBehaviour
{
    [SerializeField] Button[] lvButton;
    [SerializeField] Sprite unlockedIcon;
    [SerializeField] Sprite lockedIcon;
    [SerializeField] int firstLVBuildIndex;

    private void Awake()
    {
        int unlockLv = PlayerPrefs.GetInt(GameManager.Instance.levelUnlock, firstLVBuildIndex);
        for (int i = 0; i < lvButton.Length; i++)
        {
            if(i + firstLVBuildIndex <= unlockLv)
            {
                lvButton[i].interactable = true;
                lvButton[i].image.sprite = unlockedIcon;
                TextMeshProUGUI textButton = lvButton[i].GetComponentInChildren<TextMeshProUGUI>();
                textButton.text = (i+1).ToString();
                textButton.enabled = true;
            }
            else
            {
                lvButton[i].interactable = false;
                lvButton[i].image.sprite = lockedIcon;
                lvButton[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;

            }
        }
    }
}
