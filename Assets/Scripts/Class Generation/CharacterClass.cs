using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterClass 
{
    public string m_name;
    public List<DiceClass> m_dices = new List<DiceClass>();
    public RaceClass m_race;
}