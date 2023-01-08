using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NameGeneration : MonoBehaviour
{
    public TextAsset fichierCSV;

    string path = @"Assets\DataBank\Name List - Names.csv";
    public List<nameClass> nameArray = new List<nameClass>();

    private void Start()
    {
        NameListGenerator();
    }

    public void NameListGenerator()
    {
        StreamReader lecteur = new StreamReader(path);        
        string ligne;
        // Lecture de chaque ligne du fichier
        while ((ligne = lecteur.ReadLine()) != null)
        {
            // Séparation de la ligne en plusieurs chaînes de caractères en utilisant la virgule comme séparateur
            string[] valeurs = ligne.Split(',');

            //Ajout de la ligne dans une liste
            nameArray.Add(new nameClass());            
            nameArray[nameArray.Count - 1].ID = valeurs[0];
            nameArray[nameArray.Count - 1].nameValue = valeurs[1];
        }
    }
}

[System.Serializable]
public class nameClass
{    
    public string ID;
    public string nameValue;
}
