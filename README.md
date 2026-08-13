# 🎮 HajimeBrokenArt

> Jeu vidéo développé intégralement en solo avec **Unity / C#**, conçu comme un terrain d'entraînement pour la mise en pratique de **design patterns** de programmation dans un contexte de jeu vidéo réel.

![Unity](https://img.shields.io/badge/Unity-2022.x-black?logo=unity)
![C#](https://img.shields.io/badge/C%23-.NET-239120?logo=csharp)
![Statut](https://img.shields.io/badge/Statut-Terminé-brightgreen)

<!-- Remplace le lien ci-dessous par un GIF ou une capture d'écran de gameplay -->
<!-- ![Gameplay](docs/gameplay.gif) -->

---

## 📖 Sommaire

- [Présentation](#-présentation)
- [Objectif du projet](#-objectif-du-projet)
- [Design patterns implémentés](#-design-patterns-implémentés)
- [Fonctionnalités](#-fonctionnalités)
- [Architecture du projet](#-architecture-du-projet)
- [Stack technique](#-stack-technique)
- [Installation](#-installation)
- [Ce que j'ai appris](#-ce-que-jai-appris)
- [Pistes d'amélioration](#-pistes-damélioration)
- [Contact](#-contact)

---

> 💡 La documentation complète du code ce trouve dans mon espace de travail Notion, j'ai développer les explications sur l’implémentation des paternes employés.
## 🕹️ Présentation


Ce jeu est un roguelite / shoot'em up dans lequel le joueur doit survivre à des vagues différents monstres, le jouer accumule des points d'énergie qu'il pourra réutiliser pour améliorer ses armes et capacités. Le jeu propose une multitudes d'ennemies aux comportements variés, des armes aux effets diverses et des capacités déblocables aidant le joueur à survivre aux vagues de monstres de plus en plus complexe.

## 🎯 Objectif du projet

Ce projet n'a pas été développé dans un but purement ludique, mais avant tout comme un **exercice technique personnel**. L'objectif était de :

- Concevoir un jeu complet de A à Z, seul, de la conception à la publication
- Mettre en pratique des **design patterns** classiques dans un contexte concret (et non académique), pour comprendre *quand* et *pourquoi* les utiliser plutôt que de les apprendre par cœur
- Structurer une architecture de code **maintenable et évolutive**

## 🧩 Design patterns implémentés

| Pattern | Utilisation dans le projet |
|---|---|
| **Singleton** | Gestion centralisée du `GameManager` accessible depuis n'importe quel script |
| **Observer** | Système d'événements (ex : mise à jour de l'UI de vie/score sans couplage direct avec la logique de jeu) via `UnityEvent` / `C# events` |
| **State** | Machine à états pour le comportement de l'IA ennemie ou pour les états du joueur (Idle, Run, Jump, Attack...) |
| **Factory** | Création dynamique d'entités (ennemis, items) sans exposer la logique d'instanciation |
| **Strategy** | Interchangeabilité de comportements (ex : différents types d'armes ou d'IA) sans multiplier les `if/else` |
| **MVC / ScriptableObject Architecture** | Séparation des données (ScriptableObjects), de la logique et de la présentation |

> 💡 J'ai développer les explications sur l’implémentation des paternes employés dans le Notion.

## ✨ Fonctionnalités

- Système de vagues
- Amélioration des armes et capacités du personnage
- Système de score avec tableau des scores persistant
- Menu, effets audio
- Système de Path finding avec NavMesh 

## 🛠️ Stack technique

- **Moteur** : Unity [version]
- **Langage** : C#
- **Outils** : Visual Studio, GitHub
- **Librairie** : NavMeshPlus

## 🚀 Installation

Pas encore installable. 

## 📚 Ce que j'ai appris

- Comment identifier le bon pattern face à un problème concret plutôt que de l'appliquer par principe
- L'importance de découpler la logique de jeu de la présentation pour faciliter les tests et l'évolution du code
- La gestion de projet en solo : priorisation, découpage en tâches, gestion du scope
- Compréhension des principes mathématique et physique d'un jeu vidéo
- Mise en place de logiciel de gestion de projet (ici Notion)

## 🔭 Pistes d'amélioration

- ajout de tests unitaires sur la logique métier
- Ajouter du contenue
- Refactorisation du code 

## 📬 Contact

**Théo Bastienne-Banco**
[Portfolio](https://github.com/BTheoB) · [Email](tbastienne@gmail.com)
