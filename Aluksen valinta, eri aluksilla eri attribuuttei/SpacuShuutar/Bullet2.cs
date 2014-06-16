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
    //SUPALAZUR BULLAT
    public class Bullet2
    {
        public Vector2 position;
        public Vector2 direction;
        public Vector2 origin;
        public Texture2D bulletTexture;
        public Player player;
        public bool Dead;
        public int damage;
        public float speed;
        public int ammo;

        public Bullet2(Vector2 spawn, Vector2 direction, Texture2D tex, Player player)
        {
            this.direction = direction;
            this.player = player;
            position = spawn;
            bulletTexture = tex;
            speed = 8f;
            damage = 150;
            Dead = false;
            origin = new Vector2(bulletTexture.Width / 2, bulletTexture.Height / 2);
        }

        public int Width
        {
            get { return bulletTexture.Width; }
        }
        public int Height
        {
            get { return bulletTexture.Height; }
        }
        public void Update()
        {
            direction.Normalize();
            position += direction * speed;
            if (position.Y < -Width)
                Dead = true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bulletTexture, position, null, Color.White,
                player.Vector2ToRadian(direction), origin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
