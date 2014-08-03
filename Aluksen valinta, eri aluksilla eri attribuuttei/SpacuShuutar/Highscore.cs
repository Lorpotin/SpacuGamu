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

    public class Highscore
    {
        public StorageFolder localFolder = KnownFolders.DocumentsLibrary;
        SpriteFont font;
        //StreamReader reader;
        public string playerName { get; set; }
        public int score { get; set; }
        public List<string> scores = new List<string>();
        public int scoreCounter;





        public Highscore(SpriteFont fontz)
        {
            font = fontz;
        }
        public async void ReadFile()    //Toimii
        {
            try
            {

                //StorageFile file = await StorageFile.GetFileFromPathAsync(@"C:\myFile.txt");
                var folder = KnownFolders.DocumentsLibrary;
                var file = await folder.CreateFileAsync("Highscore.txt", CreationCollisionOption.OpenIfExists);
                var contents = await FileIO.ReadLinesAsync(file);
                foreach (var line in contents)
                {
                    scores.Add(line);                 
                }
            }
            catch (FileNotFoundException exception)
            {
                Debug.WriteLine(exception);
            }
        }
        public async void WriteFile(int score)      //Toimii?
        {
            scores.Add(score.ToString());
            var folder = KnownFolders.DocumentsLibrary;
            var file = await folder.CreateFileAsync("Highscore.txt", CreationCollisionOption.OpenIfExists);
            await FileIO.WriteLinesAsync(file, scores);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.DrawString(font, "HIGHSCORES", new Vector2(600, 50), Color.White);
            spriteBatch.DrawString(font, "1. " + scores[0], new Vector2(600, 300), Color.White);
            spriteBatch.DrawString(font, "2. " + scores[1], new Vector2(600, 500), Color.White);
            spriteBatch.DrawString(font, "3. " + scores[2], new Vector2(600, 700), Color.White);    
        }
    }
}
