using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Audio;
using Windows.Devices.Input;
using Windows.UI.Xaml;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using Microsoft.Xna.Framework.Media;
using SpacuShuutar;

namespace SpacuShuutar
{
    public class IntroVideo
    {
        Texture2D introTexture;
        Vector2 screen;
        Rectangle screenRectangle;
        //GraphicsDevice graphics = new GraphicsDevice();
        Color colour;
        int level = 0;
        public bool down;

        public IntroVideo(Texture2D text)
        {
            introTexture = text;
            colour = new Color(0, 0, 0);
            screen = new Vector2(1920, 1080);
        }
        public int Level
        {
            get { return level; }
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState State = Keyboard.GetState();
            screenRectangle = new Rectangle(0,0,1920,1080);
            switch (level)
            {
                case 0:
                    if (State.IsKeyDown(Keys.Escape))
                        level = 1;
                    //colour.R++;
                    if (colour.R == 255)
                        down = false;
                    if (colour.R == 0)
                        down = true;
                    if (down) colour.R++;
                    else
                    {
                        colour.R--;
                        if (colour.R == 0)
                            level = 1;
                        
                    }
                    
                    break;
                case 1:
                    break;

            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(introTexture, screenRectangle, Color.White);
            spriteBatch.Draw(introTexture, screenRectangle, colour);

        }

    }
}
