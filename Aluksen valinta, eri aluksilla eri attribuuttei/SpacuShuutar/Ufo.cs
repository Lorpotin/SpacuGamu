using System;
using System.Collections.Generic;
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

namespace SpacuShuutar
{
    public class Ufo
    {
        public Texture2D ufoTexture;
        public Vector2 position;
        public Vector2 direction;
        public bool active;
        public int health;
        public float speed;
        public int damage;
        public int score;
        int randX, randY;
        Random random = new Random();
        Player Player;

        public Ufo(Texture2D texture,  Player player)
        {
            active = true;
            health = 200;
            damage = 10;
            score = 200;
            speed = 6f;
            this.Player = player;
            ufoTexture = texture;
            position = CreateSpawnPoint();
            randY = random.Next(2, 6);
            randX = random.Next(-4, 4);
        }

        public int Width
        {
            get { return ufoTexture.Width; }
        }
        public int Height
        {
            get { return ufoTexture.Height; }
        }

        public Vector2 CreateSpawnPoint()
        {

            //Tehdään sittenkin semmonen spawni, että vihut tulee joka puolelta ja alkaa seuraamaan pellaajaa.
            

            int number = random.Next(1, 4);
            Vector2 spawnPoint = new Vector2();
            switch (number)
            {
                case 1:
                    spawnPoint = new Vector2(random.Next(100, 1800), 0);
                    break;

                case 2:
                    spawnPoint = new Vector2(1800, random.Next(50, 1030));
                    break;

                case 3:
                    spawnPoint = new Vector2(random.Next(100, 1080), 1000);
                    break;

                case 4:
                    spawnPoint = new Vector2(0, random.Next(50, 1030));
                    break;
            }

            return spawnPoint;
        }


        public void Update()
        {
            if ((position - Player.Position).Length() > 3f)
            {
                direction = Vector2.Normalize(Player.Position - position) * speed;
                position += direction;
            }
            if (health <= 0)
            {
                active = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ufoTexture, position, Color.White);
        }



    }
}
