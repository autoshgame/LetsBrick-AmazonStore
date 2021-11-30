using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ManageStatToUI
{
    public static void ChangeHpToUIImage(int quantityOf_Hp, Sprite sprite, List<Image> hpImage)
    {
        if (quantityOf_Hp >= 0)
        {
            for (int i = 0; i < quantityOf_Hp; ++i)
            {
                hpImage[i].gameObject.SetActive(true);
                hpImage[i].sprite = sprite;
            }

            for (int i = quantityOf_Hp; i < hpImage.Count; ++i)
            {
                hpImage[i].gameObject.SetActive(false);
            }
        }
    }


    public static void ChangeScoreToUIImage(int quantityOf_Score, TextMeshProUGUI pointText)
    {
        pointText.text = "Your score : " + quantityOf_Score.ToString();
    }
}