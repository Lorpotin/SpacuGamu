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
        public Vector2 velocity;
        public bool active = false;
        public int health;
        public int damage;
        public float speed;
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

        public void Update()
        {

            /*if (position.X <= 500)
                position.X += speed;
            if (position.X >= 1300)
                position.X -= speed;
             */

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
