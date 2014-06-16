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
    public class Asteroid
    {
        public Vector2 position;
        public Vector2 direction;
        public Texture2D asteroidTexture;
        public Texture2D bigAsteroidTexture;
        public bool active;
        public int health;
        public int health2;
        public int damage;
        public int score;
        float speed;
        Player Player;
        Random random = new Random();
        
        
        public Asteroid(Texture2D tex, Texture2D bigTex, Player player)
        {
            asteroidTexture = tex;
            bigAsteroidTexture = bigTex;
            position = CreateSpawnPoint();
            active = true;
            health = 100;
            health2 = 500;
            damage = 10;
            speed = 5f;
            score = 100;
            Player = player;
            
        }
        

        public int Width
        {
            get { return asteroidTexture.Width; }
        }
        public int Height
        {
            get { return asteroidTexture.Height; }
        }

        public Vector2 CreateSpawnPoint()
        {

            //Tehdään sittenkin semmonen spawni, että vihut tulee joka puolelta
            //Ja alkaa seuraamaan sua.

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
                    spawnPoint = new Vector2(random.Next(100,1080), 1000);
                    break;

                case 4:
                    spawnPoint = new Vector2(0, random.Next(50, 1030));
                    break;
            }

            return spawnPoint;
        }

        public void Update(GameTime gameTime)
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
        public void DrawBig(SpriteBatch spriteBatch)
        {
            //animation.Draw(spriteBatch);
            spriteBatch.Draw(bigAsteroidTexture, position, Color.White);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(asteroidTexture, position, Color.White);
        }
    }
}
