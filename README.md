# Tarkov-Twitch-Bot 1.0.0.3alpha

This is my simple to use and open source twitch bot designed to be used with tarkov for now  
It features chat commands to interact with you as you play. Only a few right now but more are coming. It also includes a trader reset screen for the true sweats to track exactly when traders reset and twitch chat reminders for it also!  
Readme and other info currently incomplete. This app has zero error exception handling so if it crashes, it may lock up!



# How To Use
1. First step is to create a account on Twitch.tv that you want to use as the bot account
2. Go to your Twitch chat and mod the bot you have created
3. Go to a website or use twitches tool to generate a Access Token that has all the permissions you want the bot to have
and then copy the token info into the Access Token field on the app and then hit save

WARNING - DO NOT SHARE YOUR ACCESS TOKEN WITH ANYONE AS IT ALLOWS THEM TO USE YOUR BOT TO ACCESS YOUR TWITCH CHANNEL WITH MODERATOR PERMISSIONS. I AM NOT RESPONSABLE IF YOU SHARE THE TOKEN   
4. Open the EXE in the folder
5. Click on the settings wheel in the bottom left
6. Enter the channel token for the bot, hit save, then enter the channel name you want the bot to join in the Channel Name field and hit save
5. You can enable any of the fun commands before or after the bot is running
6. Hit the Start button and it should connect right away if all info is correct

FOR THE GOOSE COMMAND TO WORK YOU MUST GO TO THIS SITE AND DOWNLOAD THE FILE.
https://samperson.itch.io/desktop-goose
1. Once the game is downloaded all the files inside the folder named "Goose"
2. Once the files are in there, delete the folder called "FOR MOD-MAKERS" as it opens a pop up everytime the command runs

# Commands
Normal Commands:

!mybits

!traders: Displays the remaining time till traders reset.

!drop: Opens your menu and drops all your items. Has a 20-minute cooldown.

!goose: Spawns a goose to walk around your screen for 2 to 6 minutes. Has a 10-minute cooldown.

!killgoose: Kills the goose if it gets out of hand.

!help: Displays help commands.

!randomkeys: Inputs one of these keys (W, A, S, D, E, Q, C, TAB, G, 2, 3) for 250ms to 1 second. Has a cooldown ranging from 2 to 15 minutes.

!roll: Rolls a number between 1-6 and posts it in chat.

!stats: Posts stats for deaths, escapes, kills, and deaths this wipe.

!turn: Turns left or right for 2 seconds. Has a cooldown ranging from 30 seconds to 5 minutes.

!wiggle: Wiggles the mouse back and forth a few times. Has a cooldown ranging from 30 seconds to 5 minutes.

Mod Commands:

!help: Displays help commands.

!death: Records a death.

!escape: Records an escape.

!resetdeath: Resets the death count.

!pop: Shoots your gun once by left-clicking. Has a cooldown ranging from 1 to 15 minutes.

Broadcaster Commands:

!help: Displays help commands.

!hi: Says hi to the bot.

!death: Records a death.

!escape: Records an escape.

!resetdeath: Resets the death count.

!escape: Records an escape.

!resetallstats: Resets all stats, even saved death stats.



# Changelog

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
