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
        public Vector2 velocity, direction;
        public bool active = false;
        public int health;
        public int damage;
        private float speed, timer;
        public Color bossColor;
        public bool hit;
        public bool victory;

        public Boss(Texture2D texture)
        {
            bossTexture = texture;
            health = 3000;
            damage = 10;
            speed = 7f;
            hit = false;
            victory = false;

        }
        public int Width
        {
            get { return bossTexture.Width; }
        }
        public int Height
        {
            get { return bossTexture.Height; }
        }

        public void Initialize(Vector2 position)
        {
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= 5)
            {
                direction = Vector2.Normalize(position - new Vector2(500, 100));
                position += direction * speed;
            }

            if (hit)
                bossColor.R -= 10;
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

            spriteBatch.Draw(bossTexture, position, bossColor);
        }

    }
}
