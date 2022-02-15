# InfiniteFanPublic
Section 1 - Summary
------------
Tentatively named "Infinite Fan" is a personal project I'm working on to improve my own skills with C# and Unity, and to hopefully create something fun and interesting in the process!
This game takes inspiration from infinite jumpers like Doodle Jump, but the player uses a fan to constantly propel a ball-shaped character upwards and past obstacles.
I'll be keeping track of my changes and thought process in this read me as a dev log-esque document.  
-Bryce T.

Section 2 - Changelog
---------------------
(2/14/22) 0.7.6 - Public version released (+readme update)  
(12/4/21) 0.7.5 - Credits finished (+ readme update)  
(11/6/21) 0.7.4 - BGM volume control and SFX (+ readme update)  
(11/5/21) 0.7.3 - Particle direction fix  
(11/3/21) 0.7.2 - Credits UI update (+ readme update)  
(11/3/21) 0.7.1 - Background music functionality and credits  
(11/1/21) 0.7.0 - Aesthetic overhaul (+ readme update)  
(10/23/21) 0.6.5 - Added SFX packs and audio files  
(10/23/21) 0.6.4 - Added UI asset packs  
(10/23/21) 0.6.3 - Added main assets packs  
(10/23/21) 0.6.2 - High score save and display (+ readme update)  
(10/22/21) 0.6.1 - Hardcoded subchunks and preliminary ball stuck logic  
(10/20/21) 0.6.0 - Ball change feature (+ readme update)  
(10/4/21) 0.5.3 - Clean-up pass (+ readme update)  
(9/29/21) 0.5.2 - Subchunking logic (+ readme update)  
(9/22/21) 0.5.1 - Chunk fixed movement and obstacle rotation  
(9/22/21) 0.5.0 - Chunk generation  
(9/15/21) 0.4.0 - Game over and score (+ readme update)  
(9/15/21) 0.3.1 - Object movement and updated fan physics  
(9/13/21) 0.3.0 - Obstacles (+ readme update)  
(9/6/21) 0.2.1 - Movement clamps (+ readme update)  
(9/3/21) 0.2.0 - Basic fan movement (+ readme update)  
(9/1/21) 0.1.1 - Android SDK build fix (+ readme update)  
(9/1/21) 0.1.0 - Basic menus and fan physics  
(9/1/21) 0.0.0 - First push of Unity project  

Section 3 - Personal Notes
--------------------------
2/14/21 (0.7.6)
Though I've made updates to the game since my last entry, I was having issues with Github and was uncertain whether or not this dev log would even be viewable, so I halted updating it while I focused on my Unity certification and prepping my other professional material. Luckily the only changes I've made since have been small and in prep for showcasing my work, namely bug fixing, UI adjustments, etc. I'm including all of those changes under the umbrella of 0.7.6 for the sake of convenience and considering this my first version I'm using for public showcasing. So if you're here from my resume/website, thank you for visiting and feel free to peruse my notes and code!

12/4/21 (0.7.5)
It's been quite some time since my last edit, but I've finally returned to do some cleaning up! I mainly wrestled with content fitters and vertical layout groups in order to make the scrollbars work.
Interestingly, since I was using the same box, I ran into an issue where the content container wouldn't shrink to accomodate smaller amounts of text after holding a longer group of text.
After some experimentation I was able to lock the height of the vertical layout group and all was well, though I discovered it somewhat accidentally as I messed with the properties of the layout group and content fitter. Went ahead and added descriptions under each person's info box while I was in there, as well.
Also made some other minor tweaks, such as a minor change to the chunking to hopefully reduce places where the ball can be stuck (by trying to separate obstacles by shape size and ball size) and fixed some sounds that were automatically being triggered on load, as well.
Now that the semester is coming to an end, I may retire this project in order to start a new one and pick up some new skills. However, I may also decide to expand on it and add collectibles/unlockables, but I'm not certain yet.
In case this is my last update, thank you for taking the time to check out my project, and I hope you enjoy playing!

11/6/21 (0.7.4)
Thanks to a UI slider players can now control the volume of the background music on the customization menu, and their adjustments will be remembered between play sessions. Additionally, all buttons now have audio bites that play when clicked on, though volume control will come for these later.
Even the ball has its own sound effects when colliding with other objects. There are actually five different possible sounds, and a random one is chosen to be played when a collision is detected.
Ironicially this is currently in the script meant for when the ball gets stuck, which brought my attention to the fact that I will very soon need to do another pass for naming, conventions, cleanliness, etc.
A scrollbar has been added to the info box for the credits scene, but unfortunately I struggled a little bit with getting it to actually scroll and decided to focus on SFX. I'll have to do more research and hit this in the next update.
After letting a friend playtest I also realized that the fan had some issues, adjustments during the aesthetics updates changed the area effector and the particles didn't rotate with the fan, both of which are resized and aligned properly now.
The next update will make that scrollbar work and will need to be tested in a mobile build for sure, followed by some much needed internal cleanup!

11/3/21 (0.7.2)
Players can now choose from a number of background tracks that will play while they have the app open! Just like there are 9 animals there are also 9 free-use songs from Kevin McLeod.
To make sure that I am guaranteed complying with the music liscences I went ahead and added a credits scene as well to list proper attribution to Kenney and McLeod and give a description about myself (to fill in later) as well.
The next updates will expand on this and add volume control, a scroll bar for the credit descriptions, and SFX for the UI.

11/1/21 (0.7.0)
Imported a ton of asset packs as a part of this update and it's looking great! Later on I'll remove the assets I don't need but having all of this art available to experiment with is really nice.
There are now more animals (which are now also loaded from a Resources folder like the chunk obstacles), and the obstacles have a new look. I removed the capsule obstacle because I didn't have a sprite to match, but I now have even more shapes to play with like triangles and pentagons.
The UI is more refined as well, with stylized text and buttons. I'll likely make more updates in the future to the UI, but that will likely just be focused on cleaner layouts where needed.
I was worried if the fan would be able to be portrayed accurately with the assets I have considering I don't actually have a fan or wind sprites, but I discovered some particle effects I could use for wind and a paddle that subs in well for a fan.
While I was updating the game scene I decided to make some changes to the ball's physics. It's much less intense now and feels more like it floats now, where before it felt constantly launched against obstacles and the walls.
The next update will be about audio and background music. I've downloaded a few (copyright free, of course) and I think it would be great for players to be able to unlock tracks in addition to new animals.

10/23/21 (0.6.2)
Made the changes I mentioned in the last entry! Subchunks are functioning properly now and the game ends when the ball gets stuck for too long. High score is also now stored and displayed on the home menu and on game over!
It turns out my subchunks weren't dividing properly due to another comparison error (where two numbers of the same value were not returning as equal), so I scrapped the loop where that was occuring.
With the loop causing the issues gone, I just hardcoded the 9 subchunks, which was lucky since there weren't more than those but would've been tedious if I decided to subdivide further.
In the future if I know hardcoding will work and the "fancy" way isn't working or even necessary, perhaps I'll just do it the way I know it will work first and then go back and refine it as I see fit later.
Unfortunately I did find that in very rare scenarios two chunks will overlap (no longer a subchunk issue but two separate chunks), but since it's rarely noticable and doesn't cause huge clusters like the previous error I'm going to put it on the backburner for now.
For the ball being stuck, if the Rigidbody2D is asleep for too long the game will automatically game over.
This was the quick and easy way to handle that scenario, but I may change my mind in the future and create some logic to move the ball elsewhere when it gets stuck.
I'll have to consider where would be fair to move it, as well. Maintain its height but change its x? How do I avoid potentially moving it into a different scenario where it's stuck or inside another obstacle, or otherwise stop the game from progressing?
High score is now also stored and displayed at key times using PlayerPrefs, and will likely be used in the future for skin unlocks.
While I could continue to add functionality to this project, I'd like to go ahead and move on to visuals and audio for a couple reasons.
The main reason is that, with most of the core gameplay now working properly, the aesthetics are the most lacking area. Plus, this leads into the aforementioned skin unlocks for replayability with new sprites added.
Also, with other projects going on and planned for the next couple of months, I'd like to have the game in a state where I could stop developing if necessary and be satisfied with how it turned out. Without solid aesthetics it will always feel lacking.
Luckily there are lots of free assets I can use from Kenney, and will almost certainly spend the next update filling the project with those.

10/20/21 (0.6.0)
Continued work today after another hiatus due to other projects, more computer issues, and life in general. Added the functionality required to switch the ball into specific animals, and remember which animal the player last chose.
This is done from its own scene, where once a player taps on one of the available animals, their choice gets saved as a string in PlayerPrefs, and then assigned when the game starts to the ball's sprite.
I also took another look at my subchunk overlap issue, and tried restricting the bounds that obstacles could spawn by half of the obstacle's width/height. However, that didn't fix the issue.
Instead it appears that I'm only building 4 chunks instead of the full 9, and the remaining spaces in the array are all filled with zero vectors.
Also ran into the issue I've been anticipating for a while during playtesting, where the ball got stuck between some obstacles and couldn't be moved.
Will need to address both of these issues next time before moving forward with any more design updates.

10/4/21 (0.5.3)
Since a lot of the basic functionality that I want in the game is already here, I went ahead and did a pass on everything I've made so far to clean it up a bit.
As part of this, I standardized how scripts were named, added comments to scripts and functions where I felt like they were necessary, and cleared out unused lines of code.
Last time I also mentioned a bug where the countdown wasn't working properly on mobile, so I converted that script to FixedUpdate and the timing is consistent both in engine and on mobile now.
With this, I have a functionally sound project, but there are still more features I'd like to add.
In the immediate future, I want to refine my subchunking logic, account for the ball getting stuck and becoming immovable by the player, and allow the player to choose different ball skins.
From a design perspective, I also want to experiment with a collectible that could be used to unlock skins, or even pickups that give you some sort of powerup.
I'll need to add art for these skins, as well as for just about everything else in this game.

9/29/21 (0.5.2)
It's been almost two weeks since I updated this dev log (yikes!), thanks to a combination of some continued computer issues and getting stumped by my own code. Because it's been a minute, this entry will likely be longer.'
The focus of my work since I last wrote here has been on chunks of obstacles and subchunking them - creating smaller areas of my chunks in which to spawn obstacles to hopefully reduce overlap.
At first I was just going to create 16-point grid on the screen and use those to make a 3x3 grid of subchunks, but I discovered I only needed an array of 8 points to define the bounds for all 9 boxes. I identified those pretty quickly and noted where they would be located on the screen.
I spent some time trying to create a single loop that would seamlessly go from point-to-point to populate my grid with subchunks, but realized after some time due to the shape of their connections that was not possible.
Instead, I realized that I could treat the points like a tree, using the points directly beneath and to the left/right of a given point to create the squares that way.
I implemented that code, along with logic to select which subchunk an obstacle could use (thanks to a list of ints that I can pick from and remove once that subchunk is used, partially inspired by an answer on the Unity forums that used an array of values with Random.Range to skip specific values).
However, my if statement checking for appropriate x and y values between two points was failing. I decided to see what was going on using just their y-coordinates, where PointA's y-coordinate minus 2/3rds of the screen's half height should be equivalent to PointB's y-coordinate.
Even when both values were correct, though, I was still getting a false value. I showed the logic to a couple of people and we still were unsure why equivalent values would return a false result.
While out with another friend, who is a programmer in industry, I brought up my issue and they suggested that maybe my values weren't equivalent due to a very small decimal place that's mismatched. I gave this a shot and had no luck either.
But, it did make me consider after looking over it longer that this could somehow be caused by a type mismatch, where maybe the values are the same but the types being compared aren't compatable. And that was indeed the issue.
For reasons I'm still not sure of, the calculation for the distance between the two points (2/3rds of the screen's half height) was returning as a single instead of a float. This also turned PointA's y-coordinate into a single when subtracted, and could not be compared to PointB's y-coordinate, which is a float.
I'll have to do some research as to why a single can't be compared to a float, since it seems on the surface that those two types should be comparable. I'll also need to do more digging as to why an equation with all floats was being converted into a single.
Otherwise the logic works mostly as intended, the only issue I see right now is objects sometimes clustering in the middle, which may just be luck of the draw or another flaw in my code that I'll iron out in the future.
At the end of doing all this, I made another mobile test build which works as intended, despite the "Ready? Start!" screen lasting abnormally long.
While working on this snag, I didn't make pushes to Github like I should have while working and held off on making dev log entries instead of writing out my thoughts and issues in real-time.
I wanted to resolve this subchunking issue first before doing either, but especially for the dev log so I could list the problem encountered coupled with the solution in the same entry.
Neither of these are huge issues obviously, but it's safer and makes for better tracking and documentation if I remain on top of these things, so I'm making a note here so I remember to not repeat these missteps in the future.
While evaluating my own practices I also had doubts about how I've implemented versioning - iterating the middle number by every feature that gets added feels too frequent for these numbers to be as meaningful as they could be, especially if it's every feature added from scratch rather than a functioning version of the game.
I'll keep to the pattern I've established for now (and cut myself a little slack because I've never done version numbers before), but I should brainstorm and do research on better practices for future projects.
This is already double or triple the length of my previous entries so I'll stop writing here, but all in all I'm happy with the state of the game and the progress being made! It's coming together as a full project, and that's always exciting.

9/15/21 (0.4.0)
Made two sets of updates to the game today! In the first set, I changed how the fan pushes the ball, and created a script to be applied to any on-screen objects so they move downwards relative to the ball.
For the fan, I experimented with effectors for the first time. I thought it would be complicated and initially made a separate branch for experimenting with it, but it was fairly simple to get a handle on and I made my changes in main anyways.
To replicate and improve on the fan physics I had before, I now have a square on top of the fan with an Area Effector 2D attached, which pushes the ball with a 90* force (local) angle so it goes straight up.
This is better than my previous method, since it doesn't impact the ball unless it's directly in the fan's "line of fire" rather than simply near it, and has an added bonus of pushing the ball farther the longer it's exposed to the fan's area of effect.
The objects moving relative to the ball use the distance between the ball's previous Y position and it's current position to determine how far down to adjust.
This avoids a lot of the concerns I had in the previous update and was simple to implement, so I didn't test the camera/fan following the ball method, but will sometime after this push to determine if that method is equivalent or better, or as flawed as I believe it is.
The second set of updates added a game over condition (the ball completely leaves the screen) and adds a score component, which uses the same logic as the "relative movement" script and the ball's previous/current Y to increase the player's score.
A smaller tweak was also made to the fan using the Graphics Raycaster so that the fan doesn't move when the X button in the corner is pressed. I used some old Unity documentation as a reference for this functionality and, while it works, I would like to do some more research on the side as to why those particular lines were needed.

9/13/21 (0.3.0)
It's been about a week since I've worked on this, due to some unfortunate computer issues combined with dealing with a roommate getting COVID, but luckily I was able to use this document to easily remember where I left off.
This update focused on collisions and obstacles. The ball, when hitting an object with a collider, will bounce off with a proportion of the momentum it hit with thanks to a physics material on the ball.
The way the border works to keep the ball from leaving the screen has also been changed. Previously, the X or Y component of the ball's velocity would be changed to reflect it back onto the screen. Now, though, the script will build a border of invisible objects for the ball to bounce off of, making the collision identical to all other collisions the player will experience.
Obstacles of different shapes have already been quickly made so that in the future they can be used in pre-made chunks for the player to navigate.
In an update soon I need to try having the camera and fan follow the ball upwards as it moves in worldspace. I believe that with the fan applying force to the ball, yet chasing the ball higher to keep up with it as it climbs, it will constantly push on the ball and make it reach rocket speeds.
If that is the case, then the solution would be to have the chunks move downwards around the ball instead so the fan doesn't have to keep up with the ball, and the fan and ball remain in the confines of the screen space they spawn in.
I also introduced a small change to the start of the game, which now displays a "Ready? Go!" popup. When testing the game, the scene would try to load and play simultaneously, causing the ball to fall through the fan, so this feature gives the engine a second to catch up before starting with the ball physics. It also doubles to give the player a heads up that the game is starting.

9/6/21 (0.2.1)
Minor update this time, a first pass at clamping both the ball and fan.
The ball cannot escape via the top, right, or lefthand sides of the screen, and will reverse it's velocity in order to return to the screen when it reaches those borders. Not sure if I'll keep the restraint on the top of the screen, but for now I'll leave it for the sake of controlling some of the ball's chaos.
The fan will also only swing a percentage of the full potential arc (calculated as mentioned in the last update with the width of the screen) in order to make sure it stops cleanly on both ends.
Currently, the ball will reach somewhat high speeds as it remains close to the fan (i.e., bouncing horizontally over the fan repeadly builds a lot of momentum), so I'll definitely need some ways of better controlling that in the future.

9/3/21 (0.2.0)
This update introduces basic fan movement. The player can use touch input (or a mouse, for the sake of testing on my computer) to move the fan left and right.
The fan will travel in an arc at the bottom of the screen, rotating as it does so to create a smooth curve. This means that the ball is also pushed at an angle when it approaches the fan.
This is done by a combination of a couple of things. The arc is created by following the outline of an ellipses. Using the x component of the player's input, I calculate what the Y point would be on an ellipses of the appropriate width and height.
Currently, the height of the ellipses is determined by the starting distance of the platform from the origin, and the width uses the width of the screen. The height calculation will likely remain the same, but the width I plan to make adjustable in the future.
The rotation of the object is then done by changing it's upwards vector to point towards the opposite of its position (aka pointing at its mirror point across an xy-coordinate plane). I actually found this part of the solution on the Unity forums while looking for a 2D equivalent of LookAt(), and it took me a second to understand exactly why it worked at first.
This fan movement is currently set up to work as long as the camera is focused on (0, 0) in world space, and will need to be updated in order to follow the ball as it progresses upwards. 

9/1/21 (0.1.1)
Like I mentioned in the summary, I want to keep track of my thoughts while I work on (currently titled) "Infinite Fan", so this third section will be for that.
Today was, naturally, just starting set up. The project's now connected to GitHub and can properly build an Android SDK file, and I decided on a versioning scheme:
x.y.z, where increasing x marks a significant game milestone (i.e., 1.0.0 for when the game reaches its initial completion), y marks a newly introduced/implemented feature, and z is a feature improvement or bug fix.
It also has two scenes, a starting menu and a game scene, and navigation buttons between the two. In the game scene, there's a very basic "fan" and ball being pushed up with force applied to its rigidbody when it gets within a certain distance of the fan object.
Even if this game doesn't reach a "completed" state, I'm looking forward to continuing working on it! Thank you for checking it out.

Section 4 - To Do
-----------------
-SFX volume/toggle  
-Convention cleanup  
-Brainstorm potential collectibles/powerups  
-Experiment with other modes (like a no touch mode or a rotate-only fan)  
