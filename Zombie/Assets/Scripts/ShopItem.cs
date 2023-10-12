using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.Services.Analytics.Internal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ShopItem : MonoBehaviour, IPointerClickHandler
{
    public Text itemDes;
    public Text Heart;
    public Text Gun;
    public Text Bullet;
    public Text Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Heart.text = GameManager.instance.heartPrice + "G";
        Gun.text = GameManager.instance.gunPrice + "G";
        Bullet.text = GameManager.instance.blletPrice + "G";
        Speed.text = GameManager.instance.speedPrice + "G";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ClickHeart(eventData);
        ClickGun(eventData);
        ClickBullet(eventData);
        ClickSpeed(eventData);
        ClickBuy(eventData);
        ClickExit(eventData);
    }

    public void ClickHeart(PointerEventData eventData)
    {
        if (eventData.pointerPressRaycast.gameObject.name == "Heart")
        {
            itemDes.text = "체력 최대치를 늘린다";
            GameManager.instance.selectedItem = "Heart";
        }
    }
    public void ClickGun(PointerEventData eventData)
    {
        if (eventData.pointerPressRaycast.gameObject.name == "Gun")
        {
            itemDes.text = "데미지을 늘린다";
            GameManager.instance.selectedItem = "Gun";
        }
    }
    public void ClickBullet(PointerEventData eventData)
    {
        if (eventData.pointerPressRaycast.gameObject.name == "Bullet")
        {
            itemDes.text = "장탄량를 늘린다";
            GameManager.instance.selectedItem = "Bullet";
        }
    }
    public void ClickSpeed(PointerEventData eventData)
    {
        if (eventData.pointerPressRaycast.gameObject.name == "Speed")
        {
            itemDes.text = "이동 속도를 늘린다";
            GameManager.instance.selectedItem = "Speed";
        }
    }
    public void ClickBuy(PointerEventData eventData)
    {
        if (eventData.pointerPressRaycast.gameObject.name == "Buy")
        {
            if (GameManager.instance.selectedItem == "Heart" && GameManager.instance.gameMoney >= GameManager.instance.heartPrice)
            {
                GameManager.instance.heartCount++;
                GameManager.instance.gameMoney -= GameManager.instance.heartPrice;
                GameManager.instance.heartPrice += 50;
                GameManager.instance.heart += 10;
            }
            else if (GameManager.instance.selectedItem == "Gun" && GameManager.instance.gameMoney >= GameManager.instance.gunPrice)
            {
                GameManager.instance.gunCount++;
                GameManager.instance.gameMoney -= GameManager.instance.gunPrice;
                GameManager.instance.gunPrice += 50;
                GameManager.instance.gun += 5;
            }
            else if (GameManager.instance.selectedItem == "Bullet" && GameManager.instance.gameMoney >= GameManager.instance.blletPrice)
            {
                GameManager.instance.bulletCount++;
                GameManager.instance.gameMoney -= GameManager.instance.blletPrice;
                GameManager.instance.blletPrice += 50;
                GameManager.instance.bullet += 5;
            }
            else if (GameManager.instance.selectedItem == "Speed" && GameManager.instance.gameMoney >= GameManager.instance.speedPrice)
            {
                GameManager.instance.speedCount++;
                GameManager.instance.gameMoney -= GameManager.instance.speedPrice;
                GameManager.instance.speedPrice += 50;
                GameManager.instance.speed += 1;
            }
        }
        UIManager.instance.UpdateMoeyText(GameManager.instance.gameMoney);
    }

    public void ClickExit(PointerEventData eventData)
    {
        if (eventData.pointerPressRaycast.gameObject.name == "Exit")
        {
            GameManager.instance.isShop = true;
            GameManager.instance.onShop = false;
        }
    }
}
