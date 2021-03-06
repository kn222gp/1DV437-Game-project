﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project.View
{
    class Camera
    {
        private Matrix transform;
        public Matrix Transform
        {
            get { return transform; }
        }

        private Vector2 center;
        public Vector2 Center
        {
            get { return center; }
        }
        private Viewport viewPort;

        private float screenWidth;
        private float screenHeight;

        public Camera(Viewport newViewPort)
        {
            viewPort = newViewPort;
            screenWidth = viewPort.Width;
            screenHeight = viewPort.Height;
        }

        public Vector2 getVisualCoords(Vector2 logicalCoords)
        {

            float visualX = (logicalCoords.X * screenWidth);
            float visualY = (logicalCoords.Y * screenHeight);

            return new Vector2(visualX, visualY);
        }

        public Vector2 getLogicalCoords(Vector2 visualCoords)
        {
            float logicalX = visualCoords.X / screenWidth;
            float logicalY = visualCoords.Y / screenHeight;

            return new Vector2(logicalX, logicalY);
        }

        public Vector2 getViewport()
        {
            return new Vector2(screenWidth, screenHeight);
        }


        public void Update(Vector2 position, int xOffset, int yOffset)
        {
            
            // X
            if (position.X < viewPort.Width / 2)
            {
                center.X = viewPort.Width / 2;
            }
            else if (position.X > xOffset - (viewPort.Width / 2))
            {
                center.X = xOffset - (viewPort.Width / 2);
            }
            else
            {
                center.X = position.X;
            }

            // Y
            if (position.Y < viewPort.Height/2)
            {
                center.Y = viewPort.Height/2;
            }
            else if (position.Y > yOffset - (viewPort.Height / 2))
            {
                center.Y = yOffset - (viewPort.Height / 2);
            }
            else
            {
                center.Y = position.Y;
            }

            transform = Matrix.CreateTranslation(new Vector3(-center.X + (viewPort.Width/2),
                                                             -center.Y + (viewPort.Height/2),0));
        }
    }
}