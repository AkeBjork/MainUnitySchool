using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Legg til disse to når du jobber med XML
using System.IO;
using System.Xml;

//UI ting
using UnityEngine.UI;
//TextMeshPro
using TMPro;

public class LoadXMLFile : MonoBehaviour
{
    public TextAsset xmlRawFile;

    // laster inn xml filen over
    void Start()
    {
        string data = xmlRawFile.text;
        //sender xml filen til metoden under
        ParseXMLFile(data);
    }

    //"parser" xml filen
    void ParseXMLFile(string xmlData)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(xmlData));

        //laster inn noden som heter klasse
        string xmlPathPattern = "//Klasse";
        XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);


        //Går igjennom alle noder som heter klasse. Ovenifraq og ned i XML-filen.
        foreach (XmlNode node in myNodeList)
        {
            //printer navnet på noden vi er i nå (bare for oversikt når dere lærer eller søker etter feil)
            print(node.LocalName);

            //printer hva klassenavnet er for å lettere forstå koden, denne trengs ikke. 
            print(node.SelectSingleNode("Klassenavn").InnerText);

            //Hvis nåværende node har klassenavnet 2STA så gjør noe
            if (node.SelectSingleNode("Klassenavn").InnerText == "2STA")
            {
                //printer ut alle elevnavn i denne klassen. Pass på i starter på 1 ikke 0, da 0 er noden klassenavn. 1+ er alltid elever i nåværende xml-dokument.
                for (int i = 1; i < node.ChildNodes.Count; i++)
                {
                    print("Elevnavn: " + node.ChildNodes[i].SelectSingleNode("Elevnavn").InnerText);
                }
            }
        }
        //Merk: Hvis dere kaller på en node som ikke finnes så får dere en null-feil. Test gjerne ved å endre linje 39 "Klassenavn" til å være en node som ikke finnes i filen. Test med "test"
        
        /*
         * NullReferenceException: Object reference not set to an instance of an object
         * LoadXMLFile.ParseXMLFile (System.String xmlData) (at Assets/_scripts/LoadXMLFile.cs:39)
         * LoadXMLFile.Start () (at Assets/_scripts/LoadXMLFile.cs:18)
         */
    }
}

