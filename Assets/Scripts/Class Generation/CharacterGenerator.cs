using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    public List<DiceClass> jobOpportunity = new List<DiceClass>();
    public int jobNumberAtStart = 2;

    public GameObject charaBlueprint;

    public NameGeneration nameGeneration;

    //options de sprites
    public List<Sprite> headOptions = new List<Sprite>();
    public List<Sprite> bodyOptions = new List<Sprite>();
    public List<Sprite> handOptions = new List<Sprite>();
    public List<Sprite> tailOptions = new List<Sprite>();

    //lance le processus de creation d'un nouveau personnage
    public void CreateChara()
    {
        //instantie le personnage
        GameObject charaObject = Instantiate(charaBlueprint);
        CharacterID charaID = charaObject.GetComponentInChildren<CharacterID>();

        //lui assigne ses des de classes
        for (int i=0; i<jobNumberAtStart; i++)
        {
            AssignDice(charaID);
        }

        //lui assigne les composante de sa race
        AssignRace(charaID);

        //lui assigne ses sprites
        AssignSprites(charaObject);

        //lui assigne un nom
        AssignName(charaObject);
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

    //assigne les tetes
    void AssignHead(GameObject character)
    {
        //recupere les infos d'ID de character
        CharacterClass charaID = character.GetComponentInChildren<CharacterID>().CharacterInfo;

        //recupere le type de race
        int raceIndex = RaceConverter(charaID.m_race.raceType);

        //recupere les gameObjects de la tete
        GameObject head = character.transform.GetChild(1).GetChild(0).gameObject;

        //assign le sprite de la tete
        head.GetComponent<SpriteRenderer>().sprite = headOptions[raceIndex*4 + charaID.m_race.headType];
        if(charaID.m_race.genderType== RaceClass.gender.Male)
        {
            head.GetComponent<SpriteRenderer>().sprite = headOptions[raceIndex*4 + charaID.m_race.headType + 2];
        }
    }

    //assigne les mains
    void AssignHand(GameObject character)
    {
        //recupere les infos d'ID de character
        CharacterClass charaID = character.GetComponentInChildren<CharacterID>().CharacterInfo;

        //recupere les gameObjects des mains
        GameObject handR = character.transform.GetChild(1).GetChild(2).gameObject;
        GameObject handL = character.transform.GetChild(1).GetChild(3).gameObject;

        //assigne les sprite correspondant
        handR.GetComponent<SpriteRenderer>().sprite = handOptions[charaID.m_race.handsType * 2];
        handL.GetComponent<SpriteRenderer>().sprite = handOptions[charaID.m_race.handsType * 2 + 1];
    }

    //assigne le corps et la queue
    void AssignBody(GameObject character)
    {
        //recupere les infos d'ID de character
        CharacterClass charaID = character.GetComponentInChildren<CharacterID>().CharacterInfo;

        //recupere les gameObjects du corps et de la queue
        GameObject body = character.transform.GetChild(1).GetChild(1).gameObject;
        GameObject tail = character.transform.GetChild(1).GetChild(4).gameObject;

        //recupere le type de race
        int raceIndex = RaceConverter(charaID.m_race.raceType);

        //gere l'exeption des hedgedogs
        int bodyModifier = 0;
        if(charaID.m_race.raceType == RaceClass.race.Hedgehog) { bodyModifier = 18; }

        //assigne le sprite du corps
        body.GetComponent<SpriteRenderer>().sprite = bodyOptions[charaID.m_race.bodyType + bodyModifier];

        //gere l'assignation de la queue
        Sprite tailSprite;
        switch (charaID.m_race.raceType)
        {
            case RaceClass.race.Hedgehog:
                {
                    tailSprite = null;
                    break;
                }
            case RaceClass.race.Bunny:
                {
                    tailSprite = tailOptions[3];
                    if(charaID.m_race.genderType == RaceClass.gender.Female) { tailSprite = tailOptions[4]; }
                    break;
                }
            default:
                {
                    tailSprite = tailOptions[raceIndex];
                    break;
                }
        }

        tail.GetComponent<SpriteRenderer>().sprite = tailSprite;
    }

    //assigne le nom
    void AssignName(GameObject character)
    {
        //recupere les infos d'ID de character
        CharacterClass charaID = character.GetComponentInChildren<CharacterID>().CharacterInfo;

        //gere le genre
        int offset = 0;
        if (charaID.m_race.genderType == RaceClass.gender.Female) { offset = 20; }

        //creer l'ID du nom a assigner
        string id = RaceConverter(charaID.m_race.raceType).ToString() + (offset + Random.Range(1, 21)).ToString();
        Debug.Log(id);
        
        //boucle sur les noms pour en générer un aleatoire selon la race et le genre
        for(int i=0; i<nameGeneration.nameArray.Count; i++)
        {
            //recupere les paramètre du nom
            nameClass nom = nameGeneration.nameArray[i];

            if(nom.ID == id)
            {
                //assigne le nom correspondant
                charaID.m_name = nameGeneration.nameArray[i].nameValue;
            }
        }
    }

    //assign les sprites
    void AssignSprites(GameObject character)
    {
        AssignHead(character);
        AssignBody(character);
        AssignHand(character);
    }

    //convertit une race en int
    public static int RaceConverter(RaceClass.race race)
    {
        switch (race)
        {
            case RaceClass.race.Badger:
                {
                    return 1;
                }
            case RaceClass.race.Bunny:
                {
                    return 4;
                }
            case RaceClass.race.Hedgehog:
                {
                    return 3;
                }
            case RaceClass.race.Squirrel:
                {
                    return 2;
                }
            case RaceClass.race.Weasel:
                {
                    return 0;
                }
        }
        return -1;
    }
}
