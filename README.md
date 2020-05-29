# Projet UF Développement Ynov
## Présentation du projet
Le but de ce projet aura été de créer un jeu de gestion de village à la "Grepolis", en effet le joueur pourra développer son village en étant confronté à un robot qu'il devra vaincre. Dans un univers médiéval vous devrez développer votre économie tout en étant confrontés à des éléments imprévus. 

## Architecture du jeu
Le jeu a été développé sous le moteur graphique **Unity** dans sa version 2019.3.11f1, la totalité des scripts ont été développés en **C#**. Le jeu compte des assets graphiques provenant de l'Asset Store Unity ([https://assetstore.unity.com/](https://assetstore.unity.com/)),
certaines textures ont été créées par des graphistes externes spécialement pour notre jeu. Le système d'authentification du jeu est relié à une base de données **MariaDB** et comporte une table users. Du code **PHP** a été utilisé pour relier notre jeu à la base de données. Toute la mise en commun des données pour travailler simultanément sur le jeu passe par le système d'organisation interne à Unity qui fonctionne comme Git.  

## Fonctionnalités majeures

Le jeu comporte des différentes fonctionnalités : 
* Trois scènes : authentification, menu de lancement, jeu en lui même.
* Un système d'authentification par base de données MariaDB.
* Un menu principal permettant de le lancement de jeu, sa fermeture et le passage en plein écran.
* Un système de gestion d'apparition des villages, de voyage, dans une seule et même scène.
* Un menu de pause permettant de reprendre le jeu ou de le quitter.
* Des sons d'ambiance.
* Un système de création de bâtiments, de destruction et pour l’hôtel de ville, d'amélioration.
* Une économie en ramassant des pièces et améliorant l'hôtel de ville pour en gagner plus.
* Un système aléatoire d'apparition de tornade pouvant détruire les bâtiments.
* Un touche d'aide (C).
* Un texte de présentation au lancement du jeu.
* Une interface utilisateur avec son argent, la possibilité de choisir une photo de profil.
* Une interface permettant l'achat de troupes avec une interface pour la visibilité du nombre de troupes achetées.
* Un village ennemi se développant selon le gain d'argent du joueur.
* Un champ de bataille avec un système de combat basé sur le jeu pierre, papier, ciseaux (ici Lancier, Cavalier, Archer).
* Un système de voyage interne à la scène principale
* Un nuage qui se déplace mais qui a été désactivé pour des soucis de performances et car il sort de l'écran. 

## Répartition des tâches
**Tout le monde :** Graphismes

**Malbec Thomas :** Gestion des sons d'ambiance, apparition des tornades, une touche d'aide avec un texte apparaissent au lancement du jeu, système de destruction de bâtiment

**Bouffartigue Pierre :** Gestion d'apparition des villages, menu de lancement, système d'authentification, village ennemi, menu de pause, création de bâtiment

**Trouvat Jeremy :** Amélioration de bâtiment, économie, achat de troupes, champ de bataille

## Structure algorithmique

## Installation

### Pour modification :
__Prérequis :__
- Un serveur local (Wamp conseillé)
- Un serveur web
- Unity 2019.3.11f1, l'utilisation d'une version différent peut empêcher le bon fonctionnement du jeu.
- L'IDE Visual Studio Code est inclus avec Unity mais vous pouvez en utiliser en autre si besoin.

__Installation :__
* Les identifiants utilisés pour phpMyAdmin sont ceux par défaut donc en login : root et rien en mot de passe

* Créer une base de donnée MariaDB nommée "unity" (par défaut) puis importer la [base de données](https://github.com/PierreBouffartigue/ProjetDev/tree/master/Base%20de%20donn%C3%A9es)
* Lancez wamp et créez un répertoire WWW en mettant  à l'adresse [http://localhost/unity/api/](http://localhost/unity/api/) le fichier [index.php](https://github.com/PierreBouffartigue/ProjetDev/tree/master/Serveur%20web)

* Vous avez désormais de quoi faire fonctionner l'authentification en local et il sera possible de modifier l'adresse du serveur web directement en jeu en allant sur la scène "Login" puis en allant sur le GameObject Canva, dessus se trouve attaché un script "server" avec une ligne modifiable "url" comportant l'adresse. 

* Les identifiants du compte par défaut sont en login : unity en mot de passe : unity1

* Une fois sur unity créez un jeu 2D, une fois dans les assets supprimer ce qu'elles contiennent et glissez les fichiers du jeu trouvables [ici](https://github.com/PierreBouffartigue/ProjetDev/tree/master/Jeu)

* Rendez vous dans main/scenes et cliquez sur une des scènes pour y accéder.

* Dans file -> build settings en haut à gauche de l'éditeur ou par la suite de touches Ctrl + Shift + B vous aurez accès au options pour construire le jeu, il peut être utilisé sur plusieurs supports (web, consoles, mobile, pc) mais il faudra adapter les interfaces. 

* Donc une fois dans ce menu faites glisser les scènes une à une dans cet ordre : Scène principale (0), menu de lancement (1), login (2).

* Félicitations vous avez accès à notre jeu et pouvez désormais le modifier et y jouer.

### Pour jouer :
Téléchargez simplement le lanceur de notre jeu, pour ne pas avoir à installer une base de données en local la page de login a été désactivée pour la démonstration : 

##  Utilisation
Le jeu peut être réutilisé et modifié si nos crédits apparaissent lors de son utilisation, il en est de même pour les scripts.

## Slide de la présentation :
Vous pouvez télécharger les slides de notre présentation à ce [lien](https://cdn.discordapp.com/attachments/698581960179843262/715885602846933033/Projet_Dev.pdf)

## Captures d'écran
**Versioning :**

![enter image description here](https://cdn.discordapp.com/attachments/698581960179843262/715890918368215050/Collaboration.PNG)

**Authentification :**
![enter image description here](https://cdn.discordapp.com/attachments/698581960179843262/715882341045764196/Login.PNG)

**Menu de lancement :**
![enter image description here](https://cdn.discordapp.com/attachments/698581960179843262/715882342127894588/LaunchMenu.PNG)

**Village du joueur :**
![enter image description here](https://cdn.discordapp.com/attachments/698581960179843262/715882343226802216/VillagePrincipal.PNG)

**Village ennemi :**
![enter image description here](https://cdn.discordapp.com/attachments/698581960179843262/715882345667887144/Enemy.PNG)

**Champ de bataille :**
![enter image description here](https://cdn.discordapp.com/attachments/698581960179843262/715882345818882118/Bataille.PNG)
