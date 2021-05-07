using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : BaseScene
{
    [SerializeField]
    private GameObject player;

    public void InventoryButton()
    {
       
        OpenPopup<Inventory>("UI/Popup/InventoryPopup");
        FindObjectOfType<PlayerControl>().enabled = false;
       
    }

    public void QuestButton()
    {

        OpenPopup<Quest>("UI/Popup/QuestPopup");
        FindObjectOfType<PlayerControl>().enabled = false;
    }

    public void TrashSceneEnd()
    {
        OpenPopup<TrashEnd>("UI/Popup/EndGamePopup");
 

    }

    public void GoChoice()
    {

        OpenPopup<SeaGoChoice>("UI/Popup/SeaGo_Choice");

    }

    public void GameOverPopup()
    {

        OpenPopup<GameOverPopup>("UI/Popup/GameOverPopup");

    }

}
