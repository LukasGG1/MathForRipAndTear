﻿using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGame3D
{
    class Game
    {
        private static bool _gameOver;
        private Camera3D _camera = new Camera3D();

        public static bool GameOver
        {
            get
            {
                return _gameOver;
            }
            set
            {
                _gameOver = value;
            }

        }

        private void Start()
        {
            Raylib.InitWindow(1024, 760, "Math for Games");
            Raylib.SetTargetFPS(60);

            //Camera
            _camera.position = new System.Numerics.Vector3(0.0f, 10.0f, 10.0f);
            _camera.target = new System.Numerics.Vector3(0.0f, 0.0f, 0.0f);
            _camera.up = new System.Numerics.Vector3(0.0f, 1.0f, 0.0f);
            _camera.fovy = 45.0f;
            _camera.type = CameraType.CAMERA_PERSPECTIVE;
        }

        private void Update()
        {

        }

        private void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.BeginMode3D(_camera);

            Raylib.ClearBackground(Color.RAYWHITE);

            Raylib.DrawSphere(new System.Numerics.Vector3(), 1, Color.DARKGRAY);
            Raylib.DrawGrid(10, 1.0f);

            Raylib.EndMode3D();
            Raylib.EndDrawing();
        }

        private void End()
        {

        }

        public void Run()
        {
            Start();

            while(!_gameOver)
            {
                Update();
                Draw();
            }

            End();
        }
    }
}
