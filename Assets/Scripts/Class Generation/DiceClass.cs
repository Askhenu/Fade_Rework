using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dice", menuName = "Fade/Dice")]
public class DiceClass : ScriptableObject
{
    public enum diceSide { Agility, Constitution, Magic, Observation, Strenght }

    public diceSide[] dice = new diceSide[6];
}