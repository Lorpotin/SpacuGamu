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
    public class MoreAmmo
    {

        public Texture2D ammoTexture;
        public Texture2D speedUpTexture;
        public Vector2 position;
        public int plusAmmo;
        public float plusSpeed;
        public bool active;
        public bool pickedUp;

        public MoreAmmo(Texture2D ammon, Vector2 pos)
        {
            ammoTexture = ammon;
            position = pos;
            plusAmmo = 5;
            plusSpeed = 10f;
            active = true;
            pickedUp = false;

        }

        public int Width
        {
            get { return ammoTexture.Width; }
        }
        public int Height
        {
            get { return ammoTexture.Height; }
        }

        public void Update()
        {
            if (pickedUp == true)
                active = false;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ammoTexture, position, Color.White);
        }


    }
}
