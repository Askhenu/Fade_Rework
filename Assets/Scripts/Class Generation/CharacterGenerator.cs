using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    public List<DiceClass> jobOpportunity = new List<DiceClass>();
    public int jobNumberAtStart = 2;

    public GameObject charaBlueprint;

    //lance le processus de creation d'un nouveau personnage
    public void CreateChara()
    {
        //instantie le personnage
        CharacterID charaID = Instantiate(charaBlueprint).GetComponentInChildren<CharacterID>();

        //lui assigne ses des de classes
        for (int i=0; i<jobNumberAtStart; i++)
        {
            AssignDice(charaID);
        }

        //lui assigne les composante de sa race
        AssignRace(charaID);
    }

    //ajoute un de aleatoire au personnage en argument
    void AssignDice(CharacterID characterID)
    {
        DiceClass randomDice = jobOpportunity[Random.Range(0, jobOpportunity.Count)];
        characterID.CharacterInfo.m_dices.Add(randomDice);
    }

    //assigne les composante de la race du personnage en argument
    void AssignRace(CharacterID characterID)
    {
        //assignation de la race
        System.Array randomRace = System.Enum.GetValues(typeof(RaceClass.race));
        characterID.CharacterInfo.m_race.raceType = (RaceClass.race)randomRace.GetValue(Random.Range(0, randomRace.Length));

        //assignation du genre
        System.Array randomGender = System.Enum.GetValues(typeof(RaceClass.gender));
        characterID.CharacterInfo.m_race.genderType = (RaceClass.gender)randomGender.GetValue(Random.Range(0, randomGender.Length));

        //assignation des composant head, body & hand
        characterID.CharacterInfo.m_race.headType = Random.Range(0, 2);
        characterID.CharacterInfo.m_race.bodyType = Random.Range(0, 18);
        characterID.CharacterInfo.m_race.handsType = Random.Range(0, 4);
    }
}
