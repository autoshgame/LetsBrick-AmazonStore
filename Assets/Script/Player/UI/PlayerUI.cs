using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private PlayerStat playerStat;

    //Resources
    [SerializeField] private Sprite hpSprite;

    //UI image
    [SerializeField] List<Image> hpImage;


    private void Awake()
    {
        InitUI();
    }


    private void Start()
    {
        playerStat = GameObject.FindGameObjectWithTag("PlayerStat").GetComponent<PlayerStat>();
    }


    private void OnGUI()
    {
        ManageStatToUI.ChangeHpToUIImage(playerStat.Health, hpSprite, hpImage);
    }


    void InitUI()
    {
        foreach (Image image in hpImage)
        {
            image.gameObject.SetActive(false);
        }
    }
}
