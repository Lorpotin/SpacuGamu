using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Xml.Serialization;
using Windows.Devices.Input;
using Windows.UI.Xaml;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using Microsoft.Xna.Framework.Audio;
using Windows.Storage;







namespace SpacuShuutar
{
    
    public class Highscores
    {
        SpriteFont font;
        public string playerName { get; set; }
        public int score { get; set; }
        public List<Highscores> highScores = new List<Highscores>();
        private const string fileName = "highscore.txt";
        


        public Highscores()
        {
                       
        }
        
       
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.DrawString(font, "YOUR POINTS: ", new Vector2(600, 600), Color.White);
            for (int i = 0; i < 10; i++)
            {
                /*spriteBatch.DrawString(font, (i + 1).ToString() + ".", new Vector2(50, (650 + (30 * i))), Color.White);
                if (i < scoreArray.Count)
                {
                    spriteBatch.DrawString(font, scoreArray[i], new Vector2(70, (650 + (30 * i))), Color.White);
                }*/
            }
        }
    }
}
