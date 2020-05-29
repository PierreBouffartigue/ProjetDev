using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class TextesEcran : MonoBehaviour {

    public GameObject textBox;
    ArrayList chatText = new ArrayList();

    void Start () {
        // Au début de la scene appelle la fonction TheSequence()
        StartCoroutine(TheSequence());
    }

    void Update()
    {
        // Si on appuie sur c
        if (Input.GetKeyDown("c"))
        {
            // Lance la pésentaion
            StartCoroutine("Presentation");
        }
    }

    IEnumerator TheSequence()
    {
        // Affichage de text qui change après un temps donné
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "★ Jeu en développement ★";
        // Attend 3 secondes avant de passer au texte suivant
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "★ Village principale ★";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "★ Appuyez sur C pour voir la présentation du jeu ★";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";
        
    }

    IEnumerator Presentation()
    {
        // Si le texte d'introduction est fini
        if(textBox.GetComponent<Text>().text == "")
        { 
        // Affichage de text de présentation qui change toutes les 5 secondes
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
