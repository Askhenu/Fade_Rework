using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EquipementGenerator : MonoBehaviour
{
    EquipementItem[] oneHandedList;
    EquipementItem[] twoHandedList;
    EquipementItem[] shieldList;
    EquipementItem[] objList;
    EquipementItem[] staffList;

    public List<EquipementItem> equipementItems = new List<EquipementItem>();
    private void Start(){ EquipementFill(); }
    void EquipementFill()
    {
        oneHandedList = Resources.LoadAll<EquipementItem>("ScriptableObjects/EquipementItems/1Handed/");
        twoHandedList = Resources.LoadAll<EquipementItem>("ScriptableObjects/EquipementItems/2Handed/");
        objList = Resources.LoadAll<EquipementItem>("ScriptableObjects/EquipementItems/Objets/");
        shieldList = Resources.LoadAll<EquipementItem>("ScriptableObjects/EquipementItems/Shield/");
        staffList = Resources.LoadAll<EquipementItem>("ScriptableObjects/EquipementItems/Staff/");

        foreach(EquipementItem item in oneHandedList) { equipementItems.Add(item); }
        foreach(EquipementItem item in twoHandedList) { equipementItems.Add(item); }
        foreach(EquipementItem item in objList) { equipementItems.Add(item); }
        foreach(EquipementItem item in shieldList) { equipementItems.Add(item); }
        foreach(EquipementItem item in staffList) { equipementItems.Add(item); }
    }
}

[System.Serializable]
public class EquipementClass
{
    public EquipementItem handR;
    public EquipementItem handL;
    public EquipementItem obj;
}


[System.Serializable]
public class EquipementWeight
{
    public float mage = 1;
    public float ranger = 1;
    public float rogue = 1;
    public float warrior = 1;
}