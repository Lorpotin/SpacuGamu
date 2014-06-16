using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
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
        public string playerName;
        public string score;
        

        public string CurrentFileBuffer
        {
            get;
            private set;
        }
       
        public List<string> scores = new List<string>(10);

        public async void ReadTextFile()
        {
            var folder = KnownFolders.DocumentsLibrary;
            var file = await folder.GetFileAsync("hiscores.txt");
            string read = await Windows.Storage.FileIO.ReadTextAsync(file);
            scores.Add(read);
            //scores.Sort((a, b) => Convert.ToInt32(a).CompareTo(Convert.ToInt32(b)));
            //scores.Reverse();
        }

        public async void ReadOldDataToList()
        {
            var folder = KnownFolders.DocumentsLibrary;
            var file = await folder.GetFileAsync("hiscores.txt");
            string read = await Windows.Storage.FileIO.ReadTextAsync(file);
            scores.Add(read);
            //await file.DeleteAsync();
        }

        public async void WriteAndReadTextFile(string points)
        {
            var folder1 = KnownFolders.DocumentsLibrary;
            var file1 = await folder1.GetFileAsync("hiscores.txt");
            string read = await Windows.Storage.FileIO.ReadTextAsync(file1);
            scores.Add(read);
            string tempPoints = points;
            scores.Add(tempPoints);
            var folder = KnownFolders.DocumentsLibrary;
            var option = CreationCollisionOption.ReplaceExisting;
            var file = await folder.CreateFileAsync("hiscores.txt", option);
            for (int i = 0; i < scores.Count; i++)
                await Windows.Storage.FileIO.WriteTextAsync(file,scores[i]);
            
        }
        public Highscores(SpriteFont spriteFont)
        {
            spriteFont = font;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.DrawString(font, "YOUR POINTS: ", new Vector2(600, 600), Color.White);
            for (int i = 0; i < 10; i++)
            {
                spriteBatch.DrawString(font, (i + 1).ToString() + ".", new Vector2(50, (650 + (30 * i))), Color.White);
                if (i < scores.Count)
                {
                    spriteBatch.DrawString(font, scores[i], new Vector2(70, (650 + (30 * i))), Color.White);
                }
            }
        }
    }
}
