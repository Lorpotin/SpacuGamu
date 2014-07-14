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
        //private StorageFolder localFolder;
        SpriteFont font;
        //StreamReader reader;
        public string playerName { get; set; }
        public int score { get; set; }
        public List<string> scores = new List<string>();
        public int scoreCounter;
        
        


        public Highscores(SpriteFont fontz)
        {
            font = fontz;
        }
        public async void ReadFile()
        {
            try
            {
                var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                var file = await folder.GetFileAsync("highscores.txt");
                var contents = await FileIO.ReadLinesAsync(file);
                foreach (var line in contents)
                {
                    scores.Add(line);                  
                }       
            }
            catch(FileNotFoundException exception)
            {
                Debug.WriteLine(exception);
            }
        }
        public async void WriteFile(int score)
        {
            try
            {
                scores.Add((score.ToString()));
                //var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                //var file = await folder.GetFileAsync("highscores.txt");
                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("highscores.txt");
                await PathIO.WriteLinesAsync(file.Path, scores);
            }
            catch(FileNotFoundException exception)
            {
                Debug.WriteLine(exception);
            }
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "YOUR POINTS: ", new Vector2(600, 600), Color.White);
            for (int i = 0; i < 10; i++)
            {
                spriteBatch.DrawString(font, (i + 1).ToString() + ".", new Vector2(50, (650 + (30 * i))), Color.White);
                if (i < scores.Count)
                {
                    //Purkkaa, jolla saadaan poistettua kymmenennen pelaajan päällekkäisyys
                    if (i != 9)
                        spriteBatch.DrawString(font, scores[i], new Vector2(70, (650 + (30 * i))), Color.White);
                    else
                        spriteBatch.DrawString(font, scores[i], new Vector2(85, (650 + (30 * i))), Color.White);
                         
                }
                
                    
                
            }
        }
    }
}
