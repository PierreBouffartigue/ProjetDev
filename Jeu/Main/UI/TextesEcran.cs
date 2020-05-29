using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class TextesEcran : MonoBehaviour {

    public GameObject textBox;
    ArrayList chatText = new ArrayList();

    void Start () {
        StartCoroutine(TheSequence());
    }

    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            StartCoroutine("Presentation");
        }
    }

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "★ Jeu en développement ★";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "★ Village principale ★";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "★ Appuyez sur C pour voir la présentation du jeu ★";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";
        
    }

    IEnumerator Presentation()
    {
        if(textBox.GetComponent<Text>().text == "")
        { 
        textBox.GetComponent<Text>().text = "Bienvenue dans notre jeu";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "Il a été réalisé pour notre projet logiciel de fin d'année";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "Il sagit d'un jeu de gestion à la grepolis";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "l'objectif est de ramasser des pieces";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "afin d'améliorer ses batiments";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = " et développer son armée";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = " afin de battre une IA.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";
        }
    }
}