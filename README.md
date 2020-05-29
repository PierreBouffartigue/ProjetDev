# Projet UF Développement Ynov
## Présentation du projet
Le but de ce projet aura été de créer un jeu de gestion de village à la "Grepolis", en effet le joueur pourra développer son village en étant confronté à un robot qu'il devra vaincre. Dans un univers médiéval vous devrez développer votre économie tout en étant confrontés à des éléments imprévus. 

## Architecture du jeu
Le jeu a été développé sous le moteur graphique **Unity** dans sa version 2019.3.11f1, la totalité des scripts ont été développés en **C#**. Le jeu compte des assets graphiques provenant de l'Asset Store Unity ([https://assetstore.unity.com/](https://assetstore.unity.com/)),
certaines textures ont été créées par des graphistes externes spécialement pour notre jeu. Le système d'authentification du jeu est relié à une base de données **MariaDB** et comporte une table users. Du code **PHP** a été utilisé pour relier notre jeu à la base de données. 

## Fonctionnalités majeures

Le jeu comporte des différentes fonctionnalités : 
p* Trois scènes : authentification, menu de lancement, jeu en lui même.
p* Un système d'authentification par base de données MariaDB.
p* Un menu principal permettant de le lancement de jeu, sa fermeture et le passage en plein écran.
t* Un système de gestion d'apparition des villages, de voyage, dans une seule et même scène.
p* Un menu de pause permettant de reprendre le jeu ou de le quitter.
t* Des sons d'ambiance.
tlm* Un système de création de bâtiments, de destruction et pour l’hôtel de ville, d'amélioration.
j* Une économie en ramassant des pièces et améliorant l'hôtel de ville pour en gagner plus.
t* Un système aléatoire d'apparition de tornade pouvant détruire les bâtiments.
t* Un touche d'aide (C).
p* Un texte de présentation au lancement du jeu.
j* Une interface utilisateur avec son argent, la possibilité de choisir une photo de profil.
j* Un hôtel de vente permettant l'achat de troupes avec une interface pour la visibilité du nombre de troupes achetées.
p* Un village ennemi se développant selon le gain d'argent du joueur.
j* Un champ de bataille avec un système de combat basé sur le jeu pierre, papier, ciseaux (ici Lancier, Cavalier, Archer).
p* Un système de voyage interne à la scène principale
p* Un nuage qui se déplace mais qui a été désactivé pour des soucis de performances et car il sort de l'écran. 

## Répartition des tâches

**Malbec Thomas :** Gestion des sons d'ambiance, 
**Bouffartigue Pierre :**
**Trouvat Jeremy :**

## Structure algorithmique

## Base de données


## Installation
**Pour modification :**

**Pour jouer :**

##  Utilisation
Le jeu peut être réutilisé et modifié si nos crédits apparaissent lors de son utilisation, il en est de même pour les scripts.

## Slide de la présentation :
Vous pouvez télécharger les slides de notre présentation à ce [lien](https://cdn.discordapp.com/attachments/698581960179843262/715885602846933033/Projet_Dev.pdf)

## Captures d'écran
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