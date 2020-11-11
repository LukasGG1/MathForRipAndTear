﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
        private static Scene[] _scenes;
        private static int _currentSceneIndex;

        public static int CurrentSceneIndex
        {
            get
            {
                return _currentSceneIndex;
            }
        }

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;  // None

        /// <summary>
        /// Used to set the value of game over.
        /// </summary>
        /// <param name="value">If this value is true, the game will end</param>
        public static void SetGameOver(bool value)  //None
        {
            _gameOver = value;
        }


        /// <summary>
        /// Returns the scene at the index given.
        /// Returns an empty scene if the index is out of bounds
        /// </summary>
        /// <param name="index">The index of the desired scene</param>
        /// <returns></returns>
        public static Scene GetScene(int index)
        {
            if (index < 0 || index >= _scenes.Length)
               return new Scene();

            return _scenes[index];
        }


        /// <summary>
        /// Returns the scene that is at the index of the 
        /// current scene index
        /// </summary>
        /// <returns></returns>
        public static Scene GetCurrentScene()
        {
            return _scenes[_currentSceneIndex];
        }

        /// <summary>
        /// Adds the given scene to the array of scenes.
        /// </summary>
        /// <param name="scene">The scene that will be added to the array</param>
        /// <returns>The index the scene was placed at. Returns -1 if
        /// the scene is null</returns>
        public static int AddScene(Scene scene)
        {
            //If the scene is null then return before running any other logic

            if (scene == null)
                return -1;

            //Create a new temporary array that one size larger than the original
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            //Copy values from old array into new array
            for(int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            //Store the current index
            int index = _scenes.Length;

            //Sets the scene at the new index to be the scene passed in
            tempArray[index] = scene;

            //Set the old array to the tmeporary array
            _scenes = tempArray;

            return index;
        }

        /// <summary>
        /// Finds the instance of the scene given that inside of the array
        /// and removes it
        /// </summary>
        /// <param name="scene">The scene that will be removed</param>
        /// <returns>If the scene was successfully removed</returns>
        public static bool RemoveScene(Scene scene)  //None
        {
            //If the scene is null then return before running any other logic
            if (scene == null)
                return false;

            bool sceneRemoved = false;

            //Create a new temporary array that is one less than our original array
            Scene[] tempArray = new Scene[_scenes.Length - 1];

            //Copy all scenes except the scene we don't want into the new array
            int j = 0;
            for(int i = 0; i < _scenes.Length; i++)
            {
                if (tempArray[i] != scene)
                {
                    tempArray[j] = _scenes[i];
                    j++;
                }
                else
                {
                    sceneRemoved = true;
                }
            }

            //If the scene was successfully removed set the old array to be the new array
            if(sceneRemoved)
                _scenes = tempArray;

            return sceneRemoved;
        }


        /// <summary>
        /// Sets the current scene in the game to be the scene at the given index
        /// </summary>
        /// <param name="index">The index of the scene to switch to</param>
        public static void SetCurrentScene(int index)
        {
            //If the index is not within the range of the the array return
            if (index < 0 || index < _scenes.Length)
                return;

            //Call end for the previous scene before changing to the new one
            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();

            //Update the current scene index
            _currentSceneIndex = index;
        }


        /// <summary>
        /// Returns true while a key is being pressed
        /// </summary>
        /// <param name="key">The ascii value of the key to check</param>
        /// <returns></returns>
        public static bool GetKeyDown(int key)
        {
            return Raylib.IsKeyDown((KeyboardKey)key);
        }


        /// <summary>
        /// Returns true while if key was pressed once
        /// </summary>
        /// <param name="key">The ascii value of the key to check</param>
        /// <returns></returns>
        public static bool GetKeyPressed(int key)
        {
            return Raylib.IsKeyPressed((KeyboardKey)key);
        }

        public Game()
        {
            _scenes = new Scene[0];
        }

        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            //Creates a new window for raylib
            Raylib.InitWindow(1024, 760, "Math For Games");
            Raylib.SetTargetFPS(60);

            //Set up console window
            Console.CursorVisible = false;
            Console.Title = "Math For Games";

            //Create a new scene for our actors to exist in
            Scene scene1 = new Scene();
            Scene scene2 = new Scene();

            //Create the actors to add to our scene
            Enemy enemyHigh = new Enemy(0, 5, Color.YELLOW, new Vector2(0,5), new Vector2(30, 5), ' ', ConsoleColor.Green);
            Enemy enemyMid = new Enemy(10, 10, Color.YELLOW, new Vector2(0, 10), new Vector2(30, 10), ' ', ConsoleColor.Green);
            Enemy enemyLow = new Enemy(3, 20, Color.YELLOW, new Vector2(0, 20), new Vector2(30, 20), ' ', ConsoleColor.Green);
            Player player = new Player(2, 5,Color.BLUE, ' ', ConsoleColor.Red);
            Goal goal = new Goal(30, 20,Color.GREEN, player, 'G', ConsoleColor.Green);
            Bullet bullet = new Bullet(20, 20, Color.GREEN, ' ');

            //Initialize the enmies starting values

            //Speed
            enemyHigh.Speed = 2.5f;
            enemyMid.Speed = 1.5f;
            enemyLow.Speed = 0.5f;
            player.Speed = 1.76f;
            
            //Target
            enemyHigh.Target = player;
            enemyMid.Target = player;
            enemyLow.Target = player;
            goal.Target = player;

            //Set Martix
            player.SetTranslate(new Vector2(10.0f, 10.0f));
            //player.SetRotation(0.1f);

            //player.Rotate(0.1f);
            //player.Rotate(0.2f);
            //player.Rotate(0.3f);
            //player.Rotate(0.4f);
            //player.Rotate(0.5f);
            //player.Rotate(0.6f);
            //player.Rotate(0.7f);
            //player.Rotate(0.8f);
            //player.Rotate(0.9f);
            //player.Rotate(1.0f);

            player.SetScale(1, 1);

            //Set player's starting speed
            
            
            //Add actors to the scenes
            scene1.AddActor(player);
            scene1.AddActor(enemyHigh);
            scene1.AddActor(enemyMid);
            scene1.AddActor(enemyLow);
            scene1.AddActor(goal);

            player.AddChild(enemyMid);
            //Bullet appear when player press button "SPACE"
            scene1.AddActor(bullet);
            
            //Sets the starting scene index and adds the scenes to the scenes array
            int startingSceneIndex = 0;
            startingSceneIndex = AddScene(scene1);
            AddScene(scene2);

            //Sets the current scene to be the starting scene index
            SetCurrentScene(startingSceneIndex);
        }



        /// <summary>
        /// Called every frame
        /// </summary>
        /// <param name="deltaTime">The time between each frame</param>
        public void Update(float deltaTime)
        {
            if (!_scenes[_currentSceneIndex].Started)  //<-- Index Out Of Range Expception
                _scenes[_currentSceneIndex].Start(deltaTime);

            _scenes[_currentSceneIndex].Update(deltaTime);

        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);
            Console.Clear();
            _scenes[_currentSceneIndex].Draw();

            Raylib.EndDrawing();
        }


        //Called when the game ends.
        public void End()
        {
            if (_scenes[_currentSceneIndex].Started)
            {
                _scenes[_currentSceneIndex].End();
                SetGameOver(true);
                
            }
                
        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            //Call start for all objects in game
            Start();

            //Loops the game until either the game is set to be over or the window closes
            while(!_gameOver || !Raylib.WindowShouldClose())
            {

                //Stores the current time between frames
                float deltaTime = Raylib.GetFrameTime();
                //Call update for all objects in game
                Update(deltaTime);
                //Call draw for all objects in game
                Draw();
                //Clear the input stream for the console window
                while (Console.KeyAvailable)
                    Console.ReadKey(true);
            }
            
            End();
            
        }
    }
}
