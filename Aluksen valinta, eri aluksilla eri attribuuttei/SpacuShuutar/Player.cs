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
using SpacuShuutar;

namespace SpacuShuutar
{
    public class Player
    {
        public Texture2D playerTexture;
        Texture2D crossHairTexture;

        //Näillä lähetään rakentamaan vähän hienompaa lentelyä..
        public Vector2 arrowPosition;   //Kohde mihin piirretään
        public Vector2 direction;  //Kohde mihin matkustetaan
        public Vector2 origin;
        //public float velocity;
        public float angle;  //Rotaatio
        public Vector2 acceleration;
        public Vector2 velocity;
        public float decelleration;
        public float rotationAcceleration;
        public float rotationDecceleration;
        public float topSpeed;
        //Penus
        public int damage;
        public float health;
        public int score;
        //public Healthbar healthBar;
        public SoundEffect splat;
        public bool active;
        public int ammo;
        public int homingammo;
        public Bullet bullet;

        //Lähetään kokeilemaan vähän hiirellä tähtäystä.
        public Vector2 arrowDirection;
        //public Vector2 arrowPosition;
        public Vector2 mousePosition;
        float arrowRotationInRadians;
        public MouseState mouse;
        public float timer;
       
        
        public Vector2 Position
        {
            get { return arrowPosition; }
            
        }
        public int Damage
        {
            get { return damage; }
        }
        public int Width
        {
            get { return playerTexture.Width; }
        }
        public int Height
        {
            get { return playerTexture.Height; }
        }
        public Player(Bullet bullet, Texture2D text)
        {
            
            this.bullet = bullet;
            crossHairTexture = text;
            arrowPosition = new Vector2(960,700);
            health = 10000;
            score = 0;
            ammo = 5;
            topSpeed = 5;
            homingammo = 500;
            rotationAcceleration = 0.5f;
            velocity = new Vector2(0, 0);
            acceleration = new Vector2(0, 0);
            direction = new Vector2(0, 0);
            angle = 0;  //Rotaatio
        }

        public float Vector2ToRadian(Vector2 direction)
        {
            return (float)Math.Atan2(direction.X, -direction.Y);
            
        }

        public Vector2 SetOrigin(Vector2 origin)
        {
            origin = new Vector2(playerTexture.Width / 2, playerTexture.Height / 2);
            return origin;
        }
        public void Update(GameTime gameTime)
        {
            //Timeri eeppistä "Lähtöä" varten, alotetaan peli kun musassa droppi, lel.
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= 12.5)
            {
                float radius = playerTexture.Width / 2;
                float deltaTime = 0.5f;
                deltaTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

                KeyboardState State = Keyboard.GetState();
                mouse = Mouse.GetState();
                mousePosition = new Vector2(mouse.X, mouse.Y);      //Hiiren sijainti, eli kohde johon halutaan vaikka ampua.
                arrowDirection = (Vector2)mousePosition - arrowPosition;    //Otetaan talteen suunta lentskarista hiireen, ja tehdään siitä yksikkövektori
                arrowDirection.Normalize();
                arrowRotationInRadians = Vector2ToRadian(arrowDirection);


                //Tapahtuu ns. taikoja. Kiihtyvyys, nopeus ja suuntavektori. Joka kierroksella lasketaan kiihtyvyysvektorin summa. Kiihtyvyyteen vaikuttaa ainoastaan moottorin työntövoima. Lentsikan nopeusvektori kerrotaan
                //Kiihtvyydellä. Tärkeintähän tässä nyt oli se (tovin kesti tajuta...) että suunta johon liikutaan, on aina nopeuden suunta eikä se suunta mihin suuntaan pelaajan nokka osoittaa. Nopeuden suunta muuttuu kun 
                //aloitamme kiihdytyksen, jolloin myös kone siirtyy.
                Vector2 up = new Vector2(0f, -1f);
                Matrix rotationMatrix = Matrix.CreateRotationZ(arrowRotationInRadians);
                arrowDirection = Vector2.Transform(up, rotationMatrix) * 0.7f;
                acceleration = arrowDirection;
                arrowPosition += velocity * deltaTime;

                if (State.IsKeyDown(Keys.W) && Vector2.Distance(arrowPosition, arrowDirection) > 64)
                {
                    velocity += arrowDirection * deltaTime * deltaTime;
                }
                if (State.IsKeyDown(Keys.S) && Vector2.Distance(arrowPosition, arrowDirection) > 64)
                {
                    velocity -= arrowDirection * deltaTime * deltaTime;
                }

                //Tarkastellaan ettei mennä ulos ruudusta

                arrowPosition.X = MathHelper.Clamp(arrowPosition.X, playerTexture.Width, 1980 - playerTexture.Width);
                if (arrowPosition.X >= 1980 - playerTexture.Width)
                {
                    velocity.X *= -0.3f;
                }
                if (arrowPosition.X <= playerTexture.Width)
                {
                    velocity.X *= -0.3f;
                }
                arrowPosition.Y = MathHelper.Clamp(arrowPosition.Y, playerTexture.Height, 1080 - playerTexture.Height);
                if (arrowPosition.Y >= 1080 - playerTexture.Height)
                {
                    velocity.Y *= -0.3f;
                }
                if (arrowPosition.Y <= playerTexture.Height)
                {
                    velocity.Y *= -0.3f;
                }
            }
   
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTexture, arrowPosition, null, Color.White,
                arrowRotationInRadians, SetOrigin(origin), 1.0f, SpriteEffects.None, 0);

            spriteBatch.Draw(crossHairTexture, mousePosition, Color.White);
            
        }

    }
}
