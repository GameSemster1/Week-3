## Changes:
 - We've added a Shiled component that disables the collider for a given amount of time after touching a shield pickup, and a object that spawns shiel pickups (Assets/Scripts/new/Shield.cs).
 - We've added limits KeyboardMover that will stop the player from exiting the map (Assets/Scripts/1-movers/KeyboardMover.cs).
 - We've added a copy of KeyboardMove that moves the player from one side of the map to the other if he exits the map (roud world) (Assets/Scripts/1-movers/RoundScreen.cs).
 - We've added lives to the game. The player now loses only after he is hit three times rather than one (Assets/Scripts/3-collisions/DestroyOnTrigger2D.cs).
 - We've added an object that destroys the saucers and lazers when they leave the map (Assets/Scripts/new/ScreenEdge.cs).
 - We've changed the saucers' spawning to always be at the top of the screen ,no matter the resolution (Assets/Scripts/new/ScreenSpawner.cs).





# Unity week 2: Formal elements

A project with step-by-step scenes illustrating some of the formal elements of game development in Unity, including: 

* Prefabs for instantiating new objects;
* Colliders for triggering outcomes of actions;
* Coroutines for setting time-based rules.

Text explanations are available 
[here](https://github.com/erelsgl-at-ariel/gamedev-5780) in folder 06.

NOTE: When you first open this project, you may not see the text in the score field.
This is because TextMesh Pro is not in the project.
The Unity Editor should hopefully prompt you to import TextMeshPro;
once you do this, re-open the scenes, and you should be able to see the texts.

## Credits

Programming:
* Maoz Grossman
* Erel Segal-Halevi

Online courses:
* [The Ultimate Guide to Game Development with Unity 2019](https://www.udemy.com/the-ultimate-guide-to-game-development-with-unity/), by Jonathan Weinberger

Graphics:
* [Matt Whitehead](https://ccsearch.creativecommons.org/photos/7fd4a37b-8d1a-4d4c-80a2-4ca4a3839941)
* [Kenney's space kit](https://kenney.nl/assets/space-kit)
* [Ductman's 2D Animated Spacehips](https://assetstore.unity.com/packages/2d/characters/2d-animated-spaceships-96852)
* [Franc from the Noun Project](https://commons.wikimedia.org/w/index.php?curid=64661575)
* [Greek-arrow-animated.gif by Andrikkos is licensed under CC BY-SA 3.0](https://search.creativecommons.org/photos/2db102af-80d0-4ec8-9171-1ac77d2565ce)
