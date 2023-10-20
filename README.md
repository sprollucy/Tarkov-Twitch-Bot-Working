# Tarkov-Twitch-Bot 1.0.0.62alpha

This is my simple to use and open source twitch bot designed to be used with tarkov for now  
It features chat commands to interact with you as you play. Only a few right now but more are coming. It also includes a trader reset screen for the true sweats to track exactly when traders reset and twitch chat reminders for it also!  
Readme and other info currently incomplete. This app has zero error exception handling so if it crashes, it may lock up!  

## Features
-Some bitbot cloned features  
-A trader reset timer that tracks when items are restocked for the real sweats  
-Twitch chat incorporation  
-Twitch Bits for commands(not fully working)  
-Easy to use UI  
-Fun and easy commands  

## Upcoming Features
-Bot moderation  
-Customizable commands  
-Extra game setups?  
-Possibly add profiles  
-More commands  
-Follower services  

### Download Latest Here
[1.0.0.05a](https://github.com/sprollucy/Tarkov-Twitch-Bot-Working/releases/tag/1.0.0.05a)

## Some of this readme is outdated!


## How To Use
1. First step is to create a account on Twitch.tv that you want to use as the bot account. I use this site but twitch also offers their own  
https://twitchtokengenerator.com/  
  
2. Go to your Twitch chat and mod the bot you have created  

3. Go to a website or use twitches tool to generate a Access Token that has all the permissions you want the bot to have and then copy the token info into the Access Token field on the app and then hit save  

WARNING - DO NOT SHARE YOUR ACCESS TOKEN WITH ANYONE AS IT ALLOWS THEM TO USE YOUR BOT TO ACCESS YOUR TWITCH CHANNEL WITH MODERATOR PERMISSIONS. I AM NOT RESPONSABLE IF YOU SHARE THE TOKEN  
   
4. Open the EXE in the folder  

5. Click on the settings wheel in the bottom left  

6. Enter the channel token for the bot, hit save, then enter the channel name you want the bot to join in the Channel Name field and hit save  

5. Next click the Command Menu button on the left hand side(hit the 3 lines button to see the names) and configure any of the commands  
	-The auto message has a way to format and send seperate messages using \\  
	-The Random Keys command has a default format of "W,A,S,D,E,Q,C,{TAB},G,2,3"  
	-Default times are set to 300 seconds which is 5 minutes  

8. Open tarkov and go a offline and open your menu. Then open the "Drop Config.exe" to configure the mouse position for the drop command. Using the DOWN ARROW key, go over each of the items you with to drop(each weapon, armor, body armor, bag ect...)  
All together there is 9 items to select. Once this is finished restart the app.  

7. Next select the Connect Menu on the left hand side and hit the connect button.  

FOR THE GOOSE COMMAND TO WORK YOU MUST GO TO THIS SITE AND DOWNLOAD THE FILE. 
https://samperson.itch.io/desktop-goose  

8. Once the game is downloaded all the files inside the folder named "Goose"  

9. Once the files are in there, delete the folder called "FOR MOD-MAKERS" as it opens a pop up everytime the command runs  


## Commands
Normal Commands:  

!mybits  

!about: About the app.  


!traders: Displays the remaining time till traders reset.  

!drop: Opens your menu and drops all your items. Has a 20-minute cooldown.  

!goose: Spawns a goose to walk around your screen for 2 to 6 minutes. Has a 10-minute cooldown.  

!killgoose: Kills the goose if it gets out of hand.  

!help: Displays help commands.  

!randomkeys: Inputs Selected keys

!roll: Rolls a number between 1-6 and posts it in chat.  

!stats: Posts stats for deaths, escapes, kills, and deaths this wipe.  

!turn: Turns left or right for 2 seconds. Has a cooldown ranging from 30 seconds to 5 minutes.  

!wiggle: Wiggles the mouse back and forth a few times. Has a cooldown ranging from 30 seconds to 5 minutes.  

!grenade: plays grenade sound.  

!dropbag: drops your bag.  

!pop: Shoots your gun once by left-clicking.  

Mod Commands:  

!death: Records a death.  

!escape: Records an escape.  

!kill: Counts player kills and saves them.  


Broadcaster Commands:  

!hi: Says hi to the bot.  

!death: Records a death.  

!escape: Records an escape.  

!resettoday: Resets the death, kills, and escapes for the day.  

!escape: Records an escape.  

!resetallstats: Resets all stats, even saved death stats.  

!kill: Counts player kills and saves them.  


## Changelog
1.0.0.62-alpha 10-20-23  
-All timer systems are now under a unified system and use less cpu  
-Corrected !drop timer  
-Corrected typo in !goose cooldown  
-Corrected !dropbag timer  
-Corrected !grenade timer  
-Corrected !pop timer  
-Corrected !randomkeys timer  
-Added kill counter and tracker  
-Renamed  !resetdeath to !resettoday and added kill reset to it  
-Added !about  
-Added !kill counter command  
-Added !wipestats to read stats saved for this wipe  
-Changed !stats to only show daily stats  
-Added anti spam features to some of the commands(help, traders, stats, wipestats, about)  
-Updated kit drop to accept any input key  
-Reorganized Mainbot code for sanity  
-Created a new app thats used for configuration of the drop feature. It allows for 9 seperate points on the screen to be set depending on where you select using the down arrow key. Currently it reads and loads from a seperate json and is its own exe file. Will add into the main app later  
-Added minimize button  
-Updated close and minimize look  

1.0.0.6-alpha 10-6-23
-Fixed numerous dumb errors(made more probably)
-Fixed wiggle command not always working
-Changed cooldown format to not read the float
-Updated trader ui
-Updated starting screen
-Updated how to use
-Simplified some code used
-Added bag drop command. Currently uses z as the default drop key
-Added grenade command. Currently you cannot adjust the volume but you can modify the sound file
-Modified the trader logic on load so the sound doesnt lock the application up or crash if the info cannot be retrieved

1.0.0.5-alpha 09-17-2023
-Added individual configs for each trader so you only hear the notifications for which ones you want
-Added a way to apply this configuration to the twitch bot
-Added a config under commands for random keys to configure what buttons it holds and hits. Currently it just spams buttons for 5 seconds
-Added notification mute for traders
-Added ability to turn off trader auto notifications on twitch
-Finished up a Auto Messaging command to the commands menu. The cooldown timer reads in seconds so 300 seconds = 5 minutes. Added a syntax to be able to send multiple messages at a time by typing \\ after any message you want to send. I will probably expand its funtionality to send more messages on seperate timers.
-Removed old files used for prototyping


1.0.0.03-alpha hotfix 09-11-2023
-Added catch for crashing if you connect without putting login info in
-Fixed trader menu timers to keep the timers in memory and not be cleared out as long as they run
-Started working on a automessage system - it will send and save a message, but not resend messages
-Added notification system for trader timer updates


1.0.0.3-alpha 09-10-2023
-Rebuild Commands and unified most of the timer systems
-Added in adjustable timers for each of the commands(currently you have to restart to update all the cooldowns)
-Overhauled UI to a more modern style to support expandability

-Added trader menu
	-Traders now have their own interface to track their stock resets so you dont have to run the app connected to twitch to see this info
	-Will be adding a alert system with a sound notification and some form of notification in the UI
-Reworked most of the backend to make things work with the new system

-Added Command menu
	-Added a new menu that show the commands and lets you change their cool downs and prices for bits
	-Cool downs are to be entered in how many seconds you want it to cooldown for till you can use it again. Set to 0 for no cooldown
	-Added bit payments to commands. Now when chat membered cheer with bits or pay in anyway, the bits will be added to a file with their name. When bits is enabled, the bits they have spent, can be used on a commands!
	-They can use !mybits to see how many they have
		-None of this is tested as i dont have bit payments enabled on twitch and havent enrolled in their developer thing PLEASE GIVE FEEDBACK IF THIS WORKS


1.0.0.1-alpha 09-06-2023
-Added basic command features
-Added trader reset fetching and auto updating using api.tarkov.dev
-Incorporated basic ui features
-Added some fun commands to mess with your game
-Wrote How to use - may have missed some info
-Added command list
-Added show/hide info for access token and channel
-Fixed some cooldowns accidentally triggering another when certain commands are used
-Refactored most of the original code for readability
Remember to report any bugs or new feature request on the github page!

Next feature update will include more bug fixes and hopefully I will start working on a way to adjust and edit cooldown timers
