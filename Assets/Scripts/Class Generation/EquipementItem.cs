using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipement", menuName = "Fade/Equipement")]
public class EquipementItem : ScriptableObject
{
    public enum equipementTypeEnum { oneHanded, twoHanded, item, shield, staff }
    public string equipementName;
    public equipementTypeEnum equipementType;
    public Sprite equipementSprite;
    public EquipementWeight equipementChancesByJob;
}