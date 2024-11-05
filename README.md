# Steve Runner

> Made for a school assignment

Build verion: Unity 2022.3.39.f1
Download: https://unity.com/releases/editor/whats-new/2022.3.39

![image](https://github.com/user-attachments/assets/0029920f-33ce-4484-bd6a-1ffa243e91a5)

> [!NOTE] 
>  **⚠️ Building from package may not include project settings, if this happens load files from git repo, or fix manually by adding both scenes into your build settings**
![image](https://github.com/user-attachments/assets/3f287ebc-351f-4e0c-8040-0d4e7d4c83f4)



---
# Installation

- Download `steve_runner_build_0.01.zip`
- Unpack zip
- Run Runner.exe to play!

Project files included as well in case you want to look at code and functions

> Game follows mostly the provided unity tutorials, with some additional features documented below.

---

# Features

### Custom block aesthetic!
You play as a steve in a cave enviorement with custom sounds and models!

> Provided tutorial tutorial assets have been replaced custom minecraft-themed assets created in Blockbench, steve rig was created in blender, as well as steve is now running in an iconic t-pose!
> Additionally the world has been replaced with a 3D model over the default 2D background provided in the Unity tutorials.

### Start menu
Player starts in a menu, where they can choose their difficulty and leave the game.

> Menu utilized a secondary scene, where the game managers switch between two scenes for a more organized experience. Using the simple "SceneManager.LoadScene" function.

### Difficulty seleciton
Choose from 3 difficulties for your best fitting.

> Difficulty is created mostly based on the Unity UI tutorials, however instead of an integer, this one utilized a PlayerPrefab string, which felt like an easier method for storing difficulty data between two scenes

### Score tracking
Keep track of your current score and top score.

> Score tracking was created based on the Unity UI tutorials, elements are hidden and visible in relevant gameplay context and updated in a function when necceccary. Score updates and adds 1 score after an object passes the player coordinates in the world.

### Multiple lives
Play with multiple lives for better gameplay experience.

> Updated from the base gameplay made in the tutorial, players now have a health score which removes one score when hit by an object. The health score at the beginning is determined by the selected difficulty level. Health score is updated every time a player jumps over an object.

### Multiple creatures
Jump over creepers and ravager mobs!

> Each difficulty contain their own array of creatures that will spawn with various chances of spawning, simply done by having multiple prefabs on the array to add weight. (In a more sophisticated model the weight would be determined by an int rather than duplication).
> Spawn frequenzy is randomized by min - max values determined by difficulty level chosen by the player.

### Unlocking
Unlock hardcore mode for achieving 10 points!

> Players top score is stored on a global player prefab, which easily lets code to reference the top score also in the main menu scene with different objects.
> After reaching a top score of 10, UI button for hardcore mode is unlocked and playable.

# Difficulties

### Noob mode

- 3 Lives
- Only creeper mobs
- Slow spawn rate


### Survivor mode

- 2 Lives
- Creepers, some ravengers
- Medium spawn rate

### Hardcore mode

> [!NOTE] 
>  **⚠️ 10 points required in previous modes!**

- Only one life
- Creepers & ravengers
- Fast spawn rate!


![image](https://github.com/user-attachments/assets/432a9dd4-0c7b-4161-b03f-32ca4f8d98d6)






