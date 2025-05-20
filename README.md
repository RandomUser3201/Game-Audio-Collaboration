# Game-Audio-Collaboration
For this project the Samurai Village Unity project was used.

# Project Overview:
This project focused on adding high-quality sound design to the Samurai Village Unity game using FMOD and other audio tools. The goal was to create an immersive audio experience by implementing key features such as footsteps, NPC dialogue, area-based sound triggers, interactable sound effects, and volume controls through the user interface.

While the team successfully completed these core elements, attempts to integrate advanced audio features like reverb, occlusion effects, and a wider variety of sound effects—including specific crop sounds and complex NPC dialogue triggers—were limited. 

These challenges were mainly due to time constraints and underestimating the learning curve associated with new software and tools. Despite this, the project achieved a solid foundation for dynamic and interactive audio within the game environment.

## Character List & Voice Lines
- Character List Table:
![Image](https://github.com/user-attachments/assets/dc7d1151-c596-4f9f-bfed-00de7e75f2ce)

- PDF:
- [Character List.pdf](https://github.com/user-attachments/files/19269810/character.list.pdf.pdf)

## Gantt Chart 
The following image is a visualization of the project timeline. For this project, a mix of the Waterfall and Agile methodology was used for project management.

![Image](https://github.com/user-attachments/assets/ab0148cb-3ee8-459a-a87c-f87099d4f295)

## Task Overview
Effort was made to ensure each task was distributed equally among all members

![Image](https://github.com/user-attachments/assets/aaf38eb4-cc03-4807-99a7-a43f52ff5579)

From the tasks displayed above, the following were not implemented:  
- Combat Sound
- Reverb & Occulision Effects
- Day/Night Cycle
- Lip Syncing



# Monthly Log

## February
In February the project was set up on GitHub and FMOD was updated to a newer version. Work began on adding footstep sounds, starting with solving a bug where audio wasn't playing. Grass footsteps were implemented successfully. A system was then added to switch between different surface sounds like grass and dirt. 
Objects in Unity were given tags, and if a tag matched an FMOD parameter label, the correct sound would play. This allowed the footstep audio to respond to different environments. 

## March
In March new footstep sounds were added for rock and concrete surfaces, along with 3D sound effects for fire particles. The main menu was set up including layout, working buttons, and scene transitions. Audio settings were added to the menu. Work began on area-based audio triggers and the pause menu. The pause menu toggle key was not functioning correctly and the area audio would not stop when switching zones, which was noted for later fixes. The FMOD and Unity versions were changed for better compatibility, and a new FMOD project from Luke was integrated successfully. 

Area sound triggers began working with box collisions, though audio stopped abruptly so fade-in and fade-out functionality was planned. Volume control using VCAs was added with working sliders in the pause menu. Player preferences were saved and mute toggle was implemented. Later, area triggers were improved by merging Luke's FMOD project with the current one and switching to using FMOD event emitters instead of custom logic.

## April
Not much work was done in April. Some early progress was made toward adding dialogue using FMOD. A basic layout for the dialogue system was created in the FMOD project, and a test script was set up to try out how NPCs could play voice lines either randomly or when interacted with. The system was not fully finished or added into the game yet. Overall, development slowed down this month due to limited time spent on the project.

## May
In May, significant progress was made on adding and refining sound design throughout the project. Sound effects for NPC actions like training and hitting the boxing pole were implemented using box colliders to trigger the audio. Idle NPC dialogues were introduced, along with interactable doors that display a popup and play knock sounds when the player is nearby. A set of bridge guard warnings was added, featuring multiple voice lines that play based on the player’s distance, with timers to prevent audio overlap or crashes. 

Footstep sounds were expanded to include water surfaces, and footsteps now properly stop while jumping. The village audio was enhanced with additional 3D ambient sounds, carefully organized to avoid overlapping as the player moves through the environment. UI sound effects were added and volume settings are now saved using PlayerPrefs. 

Custom voice lines and foley recordings were integrated into FMOD, with several already implemented in Unity. Finally, walking sounds for wood and rock surfaces were added along with a dialogue volume slider in the UI, improving player control over audio experience.

## Individual Contributions

## Zeeshan
- Version Control (GitHub)
- Recording Voice Lines / Sound Effects (Foley Room) 

[Unity]
- Designed All Graphical User Interface
- Implemented Sound Zone
- 3D Audio (Houses, Fire, NPC etc.) 
- Dynamic Footsteps (Surfaces)  
- NPC Dialogue & Sound Effects
- User Interface Sound Effects
- Volume Control (Settings: Pause & Main Menu)
- Interactable Environment (Gong, Doors)
- Area Sound Triggers
- Object Step Sound Effect (Wood, Rocks)

[FMOD]
- Organised Folders 
- Managed Parameters
- Modified Sounds For Realism (Pitch & 3D Spatializer Settings)
- Set-up Banks For Volume Control

## Luke Leach
[Pro Tools]
- Review and edit dialogue
- Find voice actors for studio sessions
- Book and organise studio time
- Edit session for dialogue
- Process and improve characters voices
- Export out all dialogue
- Organise into folders
- Review and create list of foley needed
- Book and manage studio time
- Edit session for foley
- Process sounds for clean short takes with variation in sound
- Export out foley clips
- Organise into folders

[FMOD]
- Import dialogue and foley into FMOD
- Organise into folders for each character
- Import foley into FMOD to replace temporary sounds

## Luke Cannon
[FMOD]

[WWise]


## Lewis French
[Absent]




## References:
- Footsteps:  
JanKoehel (2009) walk-grass [online] Available at: https://freesound.org/people/JanKoehl/sounds/85603/ [Accessed 15 May 2025]  
DasDeer (2012) Sand walk [online] Available at: https://freesound.org/people/DasDeer/sounds/161815/ [Accessed 15 May 2025]  
Leafs67 (2012) Walking in Long Grass [online] Available at: https://freesound.org/people/Leafs67/sounds/155589/ [Accessed 15 May 2025]  
Slave2TheLight (2012) Running through grass [online] Available at: https://freesound.org/people/Slave2theLight/sounds/157037/ [Accessed 15 May 2025]
Walking on pebbles and grass [online] Available at: https://freesound.org/people/LukaCafuka/sounds/752867/ [Accessed 15 May 2025]  
LukaCafuka (2024) [online] Available at: https://freesound.org/people/Nox_Sound/sounds/530385/ [Accessed 15 May 2025]  
LittleRobotSoundFactory (2015) Footsteps Water [online] Available at: https://freesound.org/people/LittleRobotSoundFactory/packs/16687/ [Accessed 15 May 2025]  

- Ambiance:  
reception (2008) Japanese Mejiro [online] Available at: https://freesound.org/people/reception/sounds/54186/ [Accessed 15 May 2025]  
Vrymaa (2025) Tsuki ga Kirei - 月がきれい [online] Available at: https://freesound.org/people/Vrymaa/sounds/785129/ [Accessed 15 May 2025]  
InspectorJ (2016) Footsteps, Concrete, A [online] Available at: https://freesound.org/people/InspectorJ/sounds/336598/ [Accessed 15 May 2025]  
Porphyr (2013) Synthetic Fire Effect [online] Available at: https://freesound.org/people/Porphyr/sounds/209651/ [Accessed 15 May 2025]  
kangaroovindaloo (2013) Medium Wind [online] Available at: https://freesound.org/people/kangaroovindaloo/sounds/205966/ [Accessed 15 May 2025]  
InspectorJ (2017) Wind, Realistic, A [online] Available at: https://freesound.org/people/InspectorJ/sounds/405561/ [Accessed 15 May 2025]  
Zapsplat (2024) Childrens indoor soft lace centre ambience, children playing, excited [online] Available at: https://www.zapsplat.com/music/childrens-indoor-soft-lace-centre-ambience-children-playing-excited-3/ [Accessed 15 May 2025]  
Zapsplat (2024) Bar/pub (small) ambience – busy with people talking and laughing 1 [online] Available at: https://www.zapsplat.com/music/barpub-small-ambience-busy-with-people-talking-and-laughing-1/ [Accessed 15 May 2025]  
Zapsplat (2024) Bar/pub (small) ambience – busy with people talking and laughing 2 [online] Available at: https://www.zapsplat.com/music/barpub-small-ambience-busy-with-people-talking-and-laughing-2/ [Accessed 15 May 2025]  
Zapsplat (2024) Cafeteria (small) ambience – busy cafe with approx 30 people inside – people chattering, crockery clatter and noise of kitchen equipment 2 [online] Available at: https://www.zapsplat.com/music/cafeteria-small-ambience-busy-cafe-with-approx-30-people-inside-people-chattering-crockery-clatter-and-noise-of-kitchen-equipment-2/ [Accessed 15 May 2025]  
harleto (2013) man_breathing_asleep [online] Available at: https://freesound.org/people/harleto/sounds/207116/ [Accessed 15 May 2025]  

- NPC:  
craigsmith (2019) R27-23-Man Grunts and Strains [online] Available at: https://freesound.org/people/craigsmith/sounds/482799/ [Accessed 15 May 2025]  
Krokulator (2012) Wood [online] Available at: https://freesound.org/people/Krokulator/sounds/652615/ [Accessed 15 May 2025]  

- UI:  
wjtaylor (2015) door_knock [online] Available at: https://freesound.org/people/wjtaylor/sounds/268500/ [Accessed 15 May 2025]  
Zapsplat (2024) Game sound, button click, pop, could be a pop up tone 1 [online] Available at: https://www.zapsplat.com/music/game-sound-button-click-pop-could-be-a-pop-up-tone-1/ [Accessed 15 May 2025]  
