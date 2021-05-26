using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
   
    protected int itemcount;
    protected string subscript;
    protected string itemname;
    protected string itemtype;



    virtual public void itemInfoSet()
    {}

    virtual public void ItemUse()
    {

        
    }


    virtual public string GetItemName()
    {
        return itemname;
    }

    virtual public string GetItemsubscript()
    {
        return subscript;
    }

    virtual public string ItemType()
    {
        return itemtype;
    }





}
