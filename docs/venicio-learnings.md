
## 17/Nov./2024
While working on the Map classes, I decided to do some research to find what would be the most efficient way to deal with the images.
I come to the decision of using TileMaps, I had to learn how to use it on MonoGame.

I found this vide: https://www.youtube.com/watch?v=Fbgimt5kFFg&list=PLvN4CrYN-8i4MhiXQMajViJoC5udFfNfA&index=12
That video served as a guide for the process of learning how to use TileMaps.

As a brief explanation:

I used a program called Tiled to help me build the map. 

For the drawing part, I drew the tiles of the map using Gimp.

Tiled, once I decided what block goes where, will generate a csv file (mostly -1,0,1,2) that hold the reference to the position of the blocks in my png (drawing).

That csv will be imported into the MonoGame project (not using MonoGame default tool), and the image itself as well (using MonoGame default tool).

Once in there I did the logic to figure everything out (described at the video).

## 18/Nov./2024
After the Map code was working smoothly, I decided to refactor it so it could follow the patterns of OOP (Object Oriented Programming).

Took everything that was not suppose to be at the Game1 class and put it back at the GameMap class.

I also decided not to create different classes for the different maps. 

Since most of the elements of the maps will come from csv files and the image we already have, there was no need for me to have a child class that would do only the same thing as the parent.

We might still have to get back to the Map class when we have the Enemy class working, but so far, the Map class is working great.

## 21/Nov./2024
Today was a day to make the player move.

We already some of the movement logic from the classes, but I wanted to make it a bit different, more akin to what I'm used to do in Unity.

The core idea stays the same, but I'm using speed and velocity as different variables, that gives me more control over the player movement and also will helps with the Animations.

The player class is now instantiable, meaning that the logic itself stays at the player class, and we just need to add a Player object at our main class.

## 22/Nov./2024
Today I added the animations.

This part was more of a challenge.

First I had to draw the player, I made a player chart that had all the images related to the player, including the Idle, and moving animations.

After that, it was time to figure it out the best way to actually use it in the class.

I made it a way that pass where in the player chart the image I want is, and the PlayerDraw method will draw it.

It was a good start, once that was figure out, I decided to make a different class to deal with the animation.
That way I could just pass to that class what frames I want to use for the animation and save different objects of that animation.

With the class done, I created a list of Animations at the Player class and add to the list objects of Animation referring to each different animation the game will have.

This way, the project is scalable, and if I want to, I can use that same Animation class to deal with Enemy animation, or any other animation from the game.

