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
        //public Texture2D asteroidTexture;
        //public Texture2D bigAsteroidTexture;
        public Color color;
        public bool active;
        public int health;
        public int health2;
        public int damage;
        public int score;
        float speed;
        Player Player;
        Random random = new Random();
        private int timeUntilStart = 60;
        SpriteAnimation enemyAnimation;
        
        
        public Asteroid(Player player, SpriteAnimation animation)
        {
           
            position = CreateSpawnPoint();
            active = true;
            health = 100;
            health2 = 500;
            damage = 10;
            speed = randomizeSpeed();
            score = 100;
            Player = player;
            color = Color.Transparent;
            enemyAnimation = animation;
            
        }
        

        public int Width
        {
            get { return enemyAnimation.FrameWidth; }
        }
        public int Height
        {
            get { return enemyAnimation.FrameHeight; }
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
        public float randomizeSpeed()
        {
            int number = random.Next(1, 4);
            float speed = 0f;
            switch (number)
            {
                case 1:
                    speed = 2f;
                    break;

                case 2:
                    speed = 5f;
                    break;

                case 3:
                    speed = 8f;
                    break;

                case 4:
                    speed = 11f;
                    break;

            }
            return speed;
        }
      
     

        public void Update(GameTime gameTime)
        {
            if (timeUntilStart <= 0)
            {
                if ((position - Player.Position).Length() > 3f)
                {
                    direction = Vector2.Normalize(Player.Position - position) * speed;
                    position += direction;
                }
                enemyAnimation.Position = position;
                enemyAnimation.Update(gameTime);
                


                if (health <= 0)
                {
                    active = false;
                } 
            }
            else
            {
                timeUntilStart--;
                color = Color.White * (1 - timeUntilStart / 60f);
            }
            
                
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(asteroidTexture, position, color);
            enemyAnimation.Draw(spriteBatch);
        }
    }
}
