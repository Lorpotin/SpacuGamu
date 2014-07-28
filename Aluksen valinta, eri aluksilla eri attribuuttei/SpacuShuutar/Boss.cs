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
    public class Boss
    {

        public Texture2D bossTexture;
        public Vector2 position;
        public Vector2 velocity, direction, origin, shootingDirection;
        public bool active = false;
        public int health;
        public int damage;
        private float speed, timer;
        public float rotation;
        public Color bossColor;
        public bool hit;
        public bool victory;
        Random random = new Random();
        public Player target;

        public Boss(Texture2D texture, Player player)
        {
            bossTexture = texture;
            health = 10000;
            damage = 10;
            speed = 7f;
            hit = false;
            victory = false;
            position = new Vector2(900, 0);
            origin = new Vector2(bossTexture.Width / 2, bossTexture.Height / 2);
            target = player;
        

        }
     
        public int Width
        {
            get { return bossTexture.Width; }
        }
        public int Height
        {
            get { return bossTexture.Height; }
        }

      
        
        public void SpinAroundAndShoot()
        {
            rotation += 5;
        }
        public void ShootPlayer()
        {
            shootingDirection = Vector2.Normalize(position - target.arrowPosition);
        }
        public Vector2 Evade()
        {
            int number = random.Next(1, 4);
            Vector2 evadePoint = new Vector2();

            switch (number)
            {
                case 1:
                    evadePoint = new Vector2(random.Next(100, 1800), 0);
                    break;

                case 2:
                    evadePoint = new Vector2(1800, random.Next(50, 1030));
                    break;

                case 3:
                    evadePoint = new Vector2(random.Next(100, 1080), 1000);
                    break;

                case 4:
                    evadePoint = new Vector2(0, random.Next(50, 1030));
                    break;
            }

            return evadePoint;
        }   
        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 18)
                position.Y += 0.4f;
            if (timer >= 18)
            {
                SpinAroundAndShoot();
            }

        }
        public void Shot(GameTime gameTime)
        {
            //Tarkastetaan osuuko, jos osuu niin "Väläytetään" sen merkiksi
            if (hit)
            {
                bossColor.R -= 10;
            }
            if (bossColor.R <= 10)
            {
                hit = false;
                bossColor = Color.White;
            }
            if (health <= 0)
            {
                active = false;
                victory = true;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bossTexture, position, null, bossColor, rotation, origin, 1.0f,  SpriteEffects.None, 0);
        }

    }
}
