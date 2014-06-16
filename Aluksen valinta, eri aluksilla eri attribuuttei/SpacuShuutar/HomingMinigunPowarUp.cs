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
    public class HomingMinigunPowarUp
    {

        public Texture2D gunTexture;
        public Vector2 position;
        public bool active;
        public bool pickedUp;
        public int plusAmmo;


        public HomingMinigunPowarUp(Texture2D text, Vector2 pos)
        {
            gunTexture = text;
            position = pos;
            active = true;
            pickedUp = false;
            plusAmmo = 100;

        }

        public int Width
        {
            get { return gunTexture.Width; }
        }
        public int Height
        {
            get { return gunTexture.Height; }
        }

        public void Update()
        {
            if (pickedUp == true)
                active = false;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(gunTexture, position, Color.White);
        }


    }

    
    
}
