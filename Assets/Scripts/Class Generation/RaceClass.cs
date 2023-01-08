using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RaceClass
{
    public enum race { Badger, Bunny, Hedgedog, Squirrel, Weasel}
    public enum gender { Female, Male }

    public race raceType;
    public gender genderType;
    public int headType;
    public int bodyType;
    public int handsType;
}
