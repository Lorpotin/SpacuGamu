using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Audio;
using Windows.Devices.Input;
using Windows.UI.Xaml;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using Microsoft.Xna.Framework.Media;
using SpacuShuutar;
namespace SpacuShuutar
{
    public class Game1 : Game /*lol*/
    {
        #region variables

        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        //Use enum to make own data type -> lets get the state where we are
        public enum GameStates { Menu, Playing, GameOver, Pause, Highscores, Intro, Fade, Options, ShipChoose, Credits, Victory};
        public GameStates gameState = GameStates.Intro;
        public GameStates NextGameState = GameStates.Intro;
        public Texture2D ship1info, ship2info, ship3info;
        public Texture2D explosionTexture, particleTexture;
        public Texture2D menu;
        public Texture2D redLaser;
        public Texture2D star, star2, diamond, circle, foreGround, borders;
        public Texture2D pause;
        public Texture2D player;
        public Texture2D asteroid;
        public Texture2D bossTexture;
        public Texture2D bigBulletTexture;
        public Texture2D fadeTexture;
        public Texture2D bulletTexture;
        public Texture2D gameover, again;
        public Texture2D backGroundTexture;
        public Texture2D bigAsteroid;
        public Texture2D alien;
        public Texture2D supaGun;
        public Texture2D highScores;
        public Texture2D victory;
        public IntroVideo introScreen;
        public Texture2D plusAmmo;
        public Texture2D miniGun;
        public Texture2D mgunBulletTexture;
        public Texture2D crosshairTexture;
        public Texture2D ufoTexture;
        public Asteroid Asteroid;
        public StarField starfield;
        public Player Player;
        public Bullet Bullet;
        public Button play;
        public Button quit;
        public Button options;
        public Button ship1;
        public Button ship2;
        public Button ship3;
        public Button playAgain;
        public Texture2D Choose;
        public Texture2D ship_1, ship_2, ship_3, _credits;
        public Texture2D MenuBackground;
        public Texture2D playTexture;
        public Texture2D quitTexture;
        public Texture2D helpTexture;
        public Texture2D optionsTexture;
        public int spawnCounter;
        public bool bossActive = false;
        public Ufo ufo;
        public Boss boss;
        public Minigun MiniGun;
        public Highscore hiScores;
        public MiniGunBullet Bullet3;
        public int machineGunCounter;
        public int gunCounter, enemiesKilled;
        public float angle;
        public bool ship1active, ship2active, ship3active;
        public List<Asteroid> asteroidArray = new List<Asteroid>();
        public List<Boss> bossArray = new List<Boss>();
        public List<Bullet> bulletArray = new List<Bullet>();
        public List<MiniGunBullet> mgunBulletArray = new List<MiniGunBullet>();
        public List<HomingMinigunPowarUp> homingArray = new List<HomingMinigunPowarUp>();
        public List<Ufo> ufoArray = new List<Ufo>();
        public List<Texture2D> ParticleTextures = new List<Texture2D>();
        public List<SpriteAnimation> explosions = new List<SpriteAnimation>();
        public TimeSpan asteroidSpawnTime;
        public TimeSpan previousSpawnTime;
        public TimeSpan lastBulletShot;
        public TimeSpan ShootInterval;
        public SoundEffect exp1, exp2, exp3, laser, machinegun;
        Random random;
        EpicHealthBar healthBar;
        SpriteFont font, epicfont;
        public int shootCounter = 20;
        public int mGunCounter = 10;
        public Song menuSong, gameSong, bossSong, winner, gamuover;
   
        public Texture2D intro;
        public float timer;
        public float startGameTimer, minigunTimer, hsTimer;
        public float gameTimer;
        public JetParticle particleEngine;
        public SpriteAnimation spriteAnimation;
        

        
        
        #endregion
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            
        }

        protected override void Initialize()
        {
            previousSpawnTime = TimeSpan.Zero;
            asteroidSpawnTime = TimeSpan.FromSeconds(1.0f);
            ShootInterval = TimeSpan.FromSeconds(1);
            IsMouseVisible = true;
            
          
            
            
            base.Initialize();
        }
 
        protected override void LoadContent()
        {
            //Luodaan uusi SpriteBatch, jota käytetään grafiikoiden piirtämiseen
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Ladataan grafiikat Content-pipelineen
            star = Content.Load<Texture2D>("star");
            pause = Content.Load<Texture2D>("pause");
            player = Content.Load<Texture2D>("ship");
            asteroid = Content.Load<Texture2D>("asteroid");
            bigAsteroid = Content.Load<Texture2D>("bigasteroid");
            gameover = Content.Load<Texture2D>("gameover");
            font = Content.Load<SpriteFont>("font");
            epicfont = Content.Load<SpriteFont>("SpriteFont1");
            bulletTexture = Content.Load<Texture2D>("bullet");
            bigBulletTexture = Content.Load<Texture2D>("bigbullet");
            exp1 = Content.Load<SoundEffect>("exp1");
            exp2 = Content.Load<SoundEffect>("exp2");
            exp3 = Content.Load<SoundEffect>("exp3");
            laser = Content.Load<SoundEffect>("laser1");
            machinegun = Content.Load<SoundEffect>("machinegun1");
            highScores = Content.Load<Texture2D>("highscore");
            plusAmmo = Content.Load<Texture2D>("plusammo");
            miniGun = Content.Load<Texture2D>("minigun");
            supaGun = Content.Load<Texture2D>("arrowtower");
            foreGround = Content.Load<Texture2D>("hpforeground");
            borders = Content.Load<Texture2D>("hpborders");
            mgunBulletTexture = Content.Load<Texture2D>("mgunbullet");
            crosshairTexture = Content.Load<Texture2D>("crosshair");
            bossTexture = Content.Load<Texture2D>("bosstexture");
            menuSong = Content.Load<Song>("menu");
            bossSong = Content.Load<Song>("pomo");
            gameSong = Content.Load<Song>("game");
            alien = Content.Load<Texture2D>("alien_2");
            Choose = Content.Load<Texture2D>("Choose");
            intro = Content.Load<Texture2D>("intro");
            explosionTexture = Content.Load<Texture2D>("explosion");
            playTexture = Content.Load<Texture2D>("PLAY");
            quitTexture = Content.Load<Texture2D>("QUIT");
            optionsTexture = Content.Load<Texture2D>("OPTIONS");
            ufoTexture = Content.Load<Texture2D>("alien");
            gamuover = Content.Load<Song>("gamuovar");
            victory = Content.Load<Texture2D>("VICTORY");
            winner = Content.Load<Song>("winrar");
            bossSong = Content.Load<Song>("biisu3");
            diamond = Content.Load<Texture2D>("diamond");
            redLaser = Content.Load<Texture2D>("redlaser");
            circle = Content.Load<Texture2D>("circle");
            star2 = Content.Load<Texture2D>("star2");
            again = Content.Load<Texture2D>("AGAIN");
            ship_1 = Content.Load<Texture2D>("Ship_1");
            ship_2 = Content.Load<Texture2D>("Ship_2");
            ship_3 = Content.Load<Texture2D>("Ship_3");
            _credits = Content.Load<Texture2D>("Credits");
            ship3info = Content.Load<Texture2D>("ship3info");
            ship2info = Content.Load<Texture2D>("ship2info");
            ship1info = Content.Load<Texture2D>("ship1info");
            //Luodaan erilaisia olioita
            Player = new Player(Bullet, crosshairTexture);
            starfield = new StarField(1920,1080, 300, new Vector2(0,75), star, new Rectangle(1920, 1080, 2, 2));
            MiniGun = new Minigun(supaGun, Player, false);
            hiScores = new Highscore(font);
            introScreen = new IntroVideo(intro);
            boss = new Boss(bossTexture);
            bossArray.Add(boss);
            //Menu-valikon näppäimet
            play = new Button(playTexture, new Vector2(700, 300), new Vector2(500,250));
            quit = new Button(quitTexture, new Vector2(660, 600), new Vector2(500, 250));
            options = new Button(optionsTexture, new Vector2(700, 450), new Vector2(500, 250));
            playAgain = new Button(again, new Vector2(700, 100), new Vector2(700, 350));
            //Aluksen valinnan näppäimet
            ship1 = new Button(ship_1, new Vector2(200, 600), new Vector2(150, 267));
            ship2 = new Button(ship_2, new Vector2(600, 600), new Vector2(150, 212));
            ship3 = new Button(ship_3, new Vector2(1000, 600), new Vector2(150, 212));
            //"Pakokaasun" partikkeleita
            ParticleTextures.Add(circle);
            ParticleTextures.Add(star2);
            ParticleTextures.Add(diamond);
            particleEngine = new JetParticle(ParticleTextures, new Vector2(Player.Position.X, Player.Position.Y -45));
            //Luodaan hpBar, kesken
            healthBar = new EpicHealthBar(foreGround, borders, Player);
            //Luetaan tiedostosta nykyinen highscore
            hiScores.ReadFile();
            
          
           
        }

        public void AddExplosion(Vector2 position)
        {
            //Luodaan räjähdysanimaatio
            SpriteAnimation explosion = new SpriteAnimation(explosionTexture, 134, 134, 12, 45, Color.White, 1f, false);
            explosion.Initialize(position);
            explosions.Add(explosion);
        }
        //Luodaan uusi asteroidi
        public void AddAsteroid()
        {
            //Luodaan animaatio asteroidille, luodaan uusi Asteroidi-olio jolle annetaan parametrina luotu animaatio
            random = new Random();
            SpriteAnimation enemyAnimation = new SpriteAnimation(asteroid, 128, 128, 64, 40, Color.White, 1f, true);
            Asteroid = new Asteroid(Player, enemyAnimation);
            asteroidArray.Add(Asteroid);
        }
        //Luodaan uusi ufo
        public void AddUfos()
        {
                //Luodaan ufoja, ei luoda enempää kuin 4 ufoa kerrallaan näytölle
                if (timer >= 2)
                {
                    timer = 0;
                    if (ufoArray.Count < 4)
                    {
                        Ufo ufo = new Ufo(ufoTexture, alien, Player);
                        ufoArray.Add(ufo);
                    }
                } 
        }
        public void UpdateUfos(GameTime gameTime)
        {
            gameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (gameTimer >= 12.5)
            {
                if (gameTimer <= 60)
                    AddUfos();

                if (ufoArray != null)
                {
                    for (int i = ufoArray.Count - 1; i >= 0; i--)
                    {
                        ufoArray[i].Update();
                        
                        if (ufoArray[i].active == false)
                        {
                            AddExplosion(ufoArray[i].position);
                            ufoArray.RemoveAt(i);
                        }
                        
                    }
                }
                foreach (Ufo u in ufoArray)
                {
                    if (u.position.Y == 1000)
                        MiniGun.target = null;
                }
            }
        }

        //Päivitetään asteroideja
        public void UpdateEnemies(GameTime gameTime)
        {
            startGameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (startGameTimer >= 12.5)
            {
                if (gameTime.TotalGameTime - previousSpawnTime > asteroidSpawnTime)
                {
                    previousSpawnTime = gameTime.TotalGameTime;
                    //BOSSIA VARTEN@@
                    if (startGameTimer <= 60)
                        AddAsteroid();
                }
                for (int i = asteroidArray.Count - 1; i >= 0; i--)
                {

                    asteroidArray[i].Update(gameTime);
                   
                    if (asteroidArray[i].active == false)
                    {
                        if (asteroidArray[i].health <= 0)
                        {
                            AddExplosion(asteroidArray[i].position);
                        }
                        asteroidArray.RemoveAt(i);
                    }
                    
                }
                foreach (Asteroid a in asteroidArray)
                {
                    if (a.position.Y == 1000)
                    {
                        MiniGun.target = null;
                    }
                }
            }
        }
        //Yritetään tehä hakeutuvaa tykkiä..Melkein jopa toimiikin...
        public void ClosestEnemy(List<Asteroid> asteroidArray, List<Ufo> ufoArray, List<Boss> bossArray)
        {
            MiniGun.target = null;
            float smallestRange = 1000;
            foreach (Asteroid asteroid in asteroidArray)
            {
                if (Vector2.Distance(MiniGun.position, asteroid.position) < smallestRange)
                {
                    smallestRange = Vector2.Distance(MiniGun.position, asteroid.position);
                    MiniGun.target = asteroid;
                }
            }
        }

        private void UpdateCollisions(GameTime gameTime)
        {
            Rectangle rectangle1;
            Rectangle rectangle2;
            Rectangle ufoRectangle;
            Rectangle homingRectangle;
            Rectangle bossRectangle;


            rectangle1 = new Rectangle((int)Player.Position.X, (int)Player.arrowPosition.Y, Player.Width, Player.Height);
            for (int a = 0; a < homingArray.Count; a++)
            {
                homingRectangle = new Rectangle((int)homingArray[a].position.X, (int)homingArray[a].position.Y, homingArray[a].Width, homingArray[a].Height);
                if (rectangle1.Intersects(homingRectangle))
                {
                    Player.homingammo += homingArray[a].plusAmmo;
                    homingArray[a].pickedUp = true;
                }
               
            }
            for (int q = 0; q < ufoArray.Count; q++)
            {
                ufoRectangle = new Rectangle((int)ufoArray[q].position.X, (int)ufoArray[q].position.Y, ufoArray[q].Width, ufoArray[q].Height);
                if (rectangle1.Intersects(ufoRectangle))
                {
                    int number = random.Next(1, 3);
                    switch (number)
                    {
                        case 1:
                            exp1.Play();
                            break;

                        case 2:
                            exp2.Play();
                            break;

                        case 3:
                            exp3.Play();
                            break;
                    }
                    Player.health -= ufoArray[q].damage;
                    ufoArray[q].health = 0;
                    healthBar.Width -= 10;
                }

            }
            for (int i = 0; i < asteroidArray.Count; i++)
            {
                rectangle2 = new Rectangle((int)asteroidArray[i].position.X, (int)asteroidArray[i].position.Y, asteroidArray[i].Width, asteroidArray[i].Height);
                //Katsotaan törmääkö rectanglet
                if (rectangle1.Intersects(rectangle2))
                {
                    int number = random.Next(1, 3);
                    switch (number)
                    {
                        case 1:
                            exp1.Play();
                            break;

                        case 2:
                            exp2.Play();
                            break;

                        case 3:
                            exp3.Play();
                            break;
                    }
                    Player.health -= asteroidArray[i].damage;
                    asteroidArray[i].health = 0;
                    healthBar.Width -= 10;
                }
                if (Player.health <= 0)
                {
                    Player.active = false;
                    //hiScores.WriteAndReadTextFile(""+Player.score);
                }
            }
            for (int i = 0; i < bossArray.Count; i++)
            {
                bossRectangle = new Rectangle((int)bossArray[i].position.X, (int)bossArray[i].position.Y, bossArray[i].Width, bossArray[i].Height);
                if (rectangle1.Intersects(bossRectangle))
                {
                    Player.health -= 100;
                    bossArray[i].hit = true;
                    healthBar.Width -= 5;
                    if (bossArray[i].health <= 0)
                    {
                        Player.score += 5000;
                        bossArray[i].active = false;
                        boss.victory = true;
                    }
                }
            }
        }

       

        //Hoidetaan ampuminen ja ammusten collisionit
        private void updateBulletCollisionsAndShoot(GameTime gameTime)
        {
            Rectangle rectangle1;
            Rectangle rectangle2;
            Rectangle UfoRectangle;
            Rectangle bossRectangle;
            MouseState mouse;
            mouse = Mouse.GetState();
            Random random;
            if (Player.gunStage == 1)
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    //Purkka jolla poistetaan "railgun"
                    if (shootCounter > 20)
                    {

                        Bullet bull = new Bullet(new Vector2(Player.arrowPosition.X + 55, Player.arrowPosition.Y), Player.arrowDirection, bulletTexture, Player, graphics);
                        laser.Play(0.2f, 0.0f, 0.0f);
                        bulletArray.Add(bull);
                        shootCounter = 0;

                    }
                    else
                        shootCounter++;
                }
            }
            if (Player.gunStage == 2)
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    //Purkka jolla poistetaan "railgun"
                    if (shootCounter > 20)
                    {

                        Bullet bull = new Bullet(new Vector2(Player.arrowPosition.X, Player.arrowPosition.Y), Player.arrowDirection, bulletTexture, Player, graphics);
                        Bullet bull3 = new Bullet(new Vector2(Player.arrowPosition.X + 25, Player.arrowPosition.Y), Player.arrowDirection, bulletTexture, Player, graphics);
                        Bullet bull2 = new Bullet(new Vector2(Player.arrowPosition.X + 50, Player.arrowPosition.Y), Player.arrowDirection, bulletTexture, Player, graphics);
                        laser.Play(0.2f, 0.0f, 0.0f);
                        bulletArray.Add(bull);
                        bulletArray.Add(bull2);
                        bulletArray.Add(bull3);
                        shootCounter = 0;

                    }
                    else
                        shootCounter++;
                }
            }
            if (Player.gunStage == 3)
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    //Purkka jolla poistetaan "railgun"
                    if (shootCounter > 20)
                    {

                        Bullet bull = new Bullet(new Vector2(Player.arrowPosition.X + 55, Player.arrowPosition.Y), Player.arrowDirection, bulletTexture, Player, graphics);
                        laser.Play(0.2f, 0.0f, 0.0f);
                        bulletArray.Add(bull);
                        shootCounter = 0;

                    }
                    else
                        shootCounter++;
                }
            }
                    //Käydään läpi kaikki ammutut luodit
                    for (int a = 0; a < bulletArray.Count; a++)
                    {
                        //Katsotaan luodin alkusijainti, ja käydään läpi asteroidit, jos nämä kaksi rectanglea collide -> tuhotaan luoti sekä asteroidi ja kasvatetaan scorea
                        rectangle1 = new Rectangle((int)bulletArray[a].position.X, (int)bulletArray[a].position.Y, bulletArray[a].Width, bulletArray[a].Height);
                        for (int i = 0; i < asteroidArray.Count; i++)
                        {
                            rectangle2 = new Rectangle((int)asteroidArray[i].position.X, (int)asteroidArray[i].position.Y, asteroidArray[i].Width, asteroidArray[i].Height);
                            if (rectangle1.Intersects(rectangle2))
                            {
                                Player.combo++;
                                enemiesKilled++;
                                bulletArray[a].Dead = true;
                                asteroidArray[i].health -= bulletArray[a].damage;
                                if (asteroidArray[i].health <= 0)
                                {
                                    random = new Random();
                                    int number = random.Next(1, 3);
                                    switch (number)
                                    {
                                        case 1:
                                            exp1.Play(0.5f, 0, 0);
                                            break;

                                        case 2:
                                            exp2.Play(0.5f, 0, 0);
                                            break;

                                        case 3:
                                            exp3.Play(0.5f, 0, 0);
                                            break;
                                    }
                                    //Mitä isompi combo, sitä enemmän saa pisteitä vihollisesta
                                    Player.score += asteroidArray[i].score + (Player.combo * 2);

                                    //Rollaillaan vähän ettei ihan liian helposti tule powarUpsei
                                    int letsRollaBitRare = random.Next(1, 15);
                                   
                                    if (letsRollaBitRare == 3 && MiniGun.isActive == false)
                                    {
                                        MiniGun.isActive = true;
                                        HomingMinigunPowarUp muchPower = new HomingMinigunPowarUp(supaGun, new Vector2(asteroidArray[i].position.X, asteroidArray[i].position.Y));
                                        homingArray.Add(muchPower);
                                    }
                                    
                                }
                            }
                        }
                        for (int i = 0; i < ufoArray.Count; i++)
                        {
                            UfoRectangle = new Rectangle((int)ufoArray[i].position.X, (int)ufoArray[i].position.Y, ufoArray[i].Width, ufoArray[i].Height);
                            if (rectangle1.Intersects(UfoRectangle))
                            {
                                bulletArray[a].Dead = true;
                                Player.combo++;
                                enemiesKilled++;
                                ufoArray[i].health -= bulletArray[a].damage;
                                if (ufoArray[i].health <= 0)
                                {
                                    random = new Random();
                                    int number = random.Next(1, 3);
                                    switch (number)
                                    {
                                        case 1:
                                            exp1.Play(0.5f, 0, 0);
                                            break;

                                        case 2:
                                            exp2.Play(0.5f, 0, 0);
                                            break;

                                        case 3:
                                            exp3.Play(0.5f, 0, 0);
                                            break;
                                    }
                                    //Mitä isompi combo, sitä enemmän saa pisteitä vihollisesta
                                    Player.score += ufoArray[i].score + (Player.combo * 2);
                                    
                                    int letsRollaBitRare = random.Next(1, 15);

                                    if (letsRollaBitRare == 3 && MiniGun.isActive == false)
                                    {
                                        MiniGun.isActive = true;
                                        HomingMinigunPowarUp muchPower = new HomingMinigunPowarUp(supaGun, new Vector2(asteroidArray[i].position.X, asteroidArray[i].position.Y));
                                        homingArray.Add(muchPower);
                                    }
                                }

                            }
                        }
                        for (int i = 0; i < bossArray.Count; i++)
                        {
                            bossRectangle = new Rectangle((int)bossArray[i].position.X, (int)bossArray[i].position.Y, bossArray[i].Width, bossArray[i].Height);
                            if (rectangle1.Intersects(bossRectangle))
                            {
                                bulletArray[a].Dead = true;
                                bossArray[i].health -= bulletArray[a].damage;
                                bossArray[i].hit = true;
                                if (bossArray[i].health <= 0)
                                {
                                    Player.score += 5000;
                                    bossArray[i].active = false;
                                }
                            }
                        }
                    }
        }
        public bool LetsSpawnThisBeast(GameTime gameTime)
        {
            MediaPlayer.Play(bossSong);
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= 10)
            {
                boss.active = true;
                return bossActive = true;
            }
            else
                return bossActive = false;
        }
        
        // JUU ELIKKÄS SE TOIMII...Bossille ei nyt ihan vielä ":D" :D::D:D
        
        private void UpdateHomingCollisions()
        {
            Rectangle rectangle1;
            Rectangle rectangle2;
            Rectangle UfoRectangle;
            Rectangle bossRectangle;


            if (Player.homingammo > 0 && mGunCounter > 10 && MiniGun.target != null && MiniGun.isActive)
            {
                
                MiniGunBullet bullet = new MiniGunBullet(mgunBulletTexture, Vector2.Subtract(MiniGun.center, new Vector2(mgunBulletTexture.Width / 2)), MiniGun.rotation, Player);
                machinegun.Play(0.2f, 0.0f, 0.0f);
                mgunBulletArray.Add(bullet);
                mGunCounter = 0;
                Player.homingammo--;
            }
            else
                mGunCounter++;
            for (int i = 0; i < mgunBulletArray.Count; i++)
            {
                if (!MiniGun.IsInRange(mgunBulletArray[i].center))
                {
                    MiniGun.target = null;
                    mgunBulletArray[i].Destroy();
                }
                rectangle1 = new Rectangle((int)mgunBulletArray[i].position.X, (int)mgunBulletArray[i].position.Y, mgunBulletArray[i].Width, mgunBulletArray[i].Height);
                for (int a = 0; a < asteroidArray.Count; a++)
                {
                    rectangle2 = new Rectangle((int)asteroidArray[a].position.X, (int)asteroidArray[a].position.Y, asteroidArray[a].Width, asteroidArray[a].Height);
                    if (rectangle1.Intersects(rectangle2))
                    {
                        mgunBulletArray[i].dead = true;
                        asteroidArray[a].health -= mgunBulletArray[i].damage;
                        if (asteroidArray[a].health <= 0)
                        {

                            Player.score += asteroidArray[a].score;
                            //Rollaillaan vähän ettei ihan liian helposti tule powarUpsei
                            random = new Random();
                            int number = random.Next(1, 3);
                            switch (number)
                            {
                                case 1:
                                    exp1.Play(0.5f, 0, 0);
                                    break;

                                case 2:
                                    exp2.Play(0.5f, 0, 0);
                                    break;

                                case 3:
                                    exp3.Play(0.5f, 0, 0);
                                    break;
                            }
                            int letsRoll = random.Next(1, 5);
                            int letsRollaBitRare = random.Next(1, 15);
                           
                            if (letsRollaBitRare == 3 && MiniGun.isActive == false)
                            {
                                MiniGun.isActive = true;
                                HomingMinigunPowarUp muchPower = new HomingMinigunPowarUp(supaGun, new Vector2(asteroidArray[a].position.X, asteroidArray[a].position.Y));
                                homingArray.Add(muchPower);
                            }

                        }
                    }
                }
                for (int b = 0; b < ufoArray.Count; b++)
                {
                    UfoRectangle = new Rectangle((int)ufoArray[b].position.X, (int)ufoArray[b].position.Y, ufoArray[b].Width, ufoArray[b].Height);
                    if (rectangle1.Intersects(UfoRectangle))
                    {
                        mgunBulletArray[i].dead = true;
                        ufoArray[b].health -= mgunBulletArray[i].damage;
                        if (ufoArray[b].health <= 0)
                        {
                            Player.score += ufoArray[b].score;
                            random = new Random();
                            int number = random.Next(1, 3);
                            switch (number)
                            {
                                case 1:
                                    exp1.Play(0.5f, 0, 0);
                                    break;

                                case 2:
                                    exp2.Play(0.5f, 0, 0);
                                    break;

                                case 3:
                                    exp3.Play(0.5f, 0, 0);
                                    break;
                            }
                            int letsRoll = random.Next(1, 5);
                            int letsRollaBitRare = random.Next(1, 15);

                            if (letsRollaBitRare == 3 && MiniGun.isActive == false)
                            {
                                MiniGun.isActive = true;
                                HomingMinigunPowarUp muchPower = new HomingMinigunPowarUp(supaGun, new Vector2(asteroidArray[b].position.X, asteroidArray[b].position.Y));
                                homingArray.Add(muchPower);
                            }
                        }
                    }
                }
                
                for (int c = 0; c < bossArray.Count; c++)
                {
                    if (bossArray[c].active == true)
                    {
                        bossRectangle = new Rectangle((int)bossArray[c].position.X, (int)bossArray[c].position.Y, bossArray[c].Width, bossArray[c].Height);
                        if (rectangle1.Intersects(bossRectangle))
                        {
                            mgunBulletArray[i].dead = true;
                            bossArray[c].health -= bulletArray[i].damage;
                            bossArray[c].hit = true;
                            if (bossArray[c].health <= 0)
                            {
                                Player.score += 5000;
                                bossArray[c].active = false;
                            }
                        }
                    }
                }
            }
        }

        private void UpdateExplosions(GameTime gameTime)
        {
            for (int i = explosions.Count - 1; i >= 0; i--)
            {
                explosions[i].Update(gameTime);
                if (explosions[i].Active == false)
                {
                    explosions.RemoveAt(i);
                }
            }
        }
         
        //Kaippa tätäkin vois käyttää... :D
        public void ClearEverything()
        {
            for (int z = 0; z < mgunBulletArray.Count; z++)
            {
                mgunBulletArray.Clear();
            }
            for (int i = 0; i < asteroidArray.Count; i++)
            {
                asteroidArray.Clear();
            }
            for (int u = 0; u < bulletArray.Count; u++)
            {
                bulletArray.Clear();
            }
         
            
            for (int x = 0; x < homingArray.Count; x++)
            {
                homingArray.Clear();
            }
            for (int y = 0; y < bossArray.Count; y++)
            {
                bossArray.Clear();
            }
            for (int e = 0; e < ufoArray.Count; e++)
            {
                ufoArray.Clear();
            }
            Player.acceleration = new Vector2(0, 0);
            Player.velocity = new Vector2(0, 0);
            Player.direction = new Vector2(0, 0);
            Player.arrowPosition = new Vector2(900, 700);
            Player.health = 100;
            Player.score = 0;
            Player.ammo = 5;
            Player.homingammo = 50;
            startGameTimer = 0;
            gameTimer = 0;
            Player.timer = 0;
            boss.active = false;
            boss.victory = false;
        }
        #region PÄIVITYKSET
        protected override void Update(GameTime gameTime)
        {
            MouseState mouse;
            mouse = Mouse.GetState();

            //Katotaan missä mennään ja perus päivittelyt
            switch (gameState)
            {
               
                case GameStates.Intro:
                    introScreen.Update(gameTime);
                    if (introScreen.Level == 1)
                    {
                        gameState = GameStates.Menu;
                        MediaPlayer.Play(menuSong);
                    }
                    break;
                
                
                case GameStates.Menu:

                    starfield.Update(gameTime);
                    play.Update(mouse);
                    options.Update(mouse);
                    quit.Update(mouse);
                  
                    if (play.isClicked == true)
                    {
                        //MediaPlayer.Stop();
                        //MediaPlayer.Play(gameSong);
                        gameState = GameStates.ShipChoose;
                       
                    }
                    if (options.isClicked == true)
                        gameState = GameStates.Options;
                    
                    if (quit.isClicked)
                    {
                        Exit();
                    }

                    if ((Keyboard.GetState().IsKeyDown(Keys.Enter)))
                    {
                        gameState = GameStates.Highscores;
                        //hiScores.ReadTextFile();
                    }
                    break;

                case GameStates.ShipChoose:
                    if ((Keyboard.GetState().IsKeyDown(Keys.Escape)))
                    {
                        gameState = GameStates.Menu;
                    }
                    ship1.Update(mouse);
                    ship2.Update(mouse);
                    ship3.Update(mouse);
                    if (ship1.isClicked == true)
                    {
                        Player.playerTexture = ship_1;
                        Player.damage = 100;
                        Player.health = 100;
                        MediaPlayer.Stop();
                        MediaPlayer.Play(gameSong);
                        gameState = GameStates.Playing;
                        
                    }
                    if (ship2.isClicked == true)
                    {
                        Player.playerTexture = ship_2;
                        Player.damage = 50;
                        Player.health = 200;
                        MediaPlayer.Stop();
                        MediaPlayer.Play(gameSong);
                        gameState = GameStates.Playing;
                       
                    }
                    if (ship3.isClicked == true)
                    {
                        Player.playerTexture = ship_3;
                        Player.health = 500;
                        Player.damage = 25;
                        MediaPlayer.Stop();
                        MediaPlayer.Play(gameSong);
                        gameState = GameStates.Playing;
                        
                    }
                    if (ship1.showInfo)
                    {
                        ship1active = true;
                        ship2active = false;
                        ship3active = false;
                    }
                    if (ship2.showInfo)
                    {
                        ship1active = false;
                        ship2active = true;
                        ship3active = false;
                    }
                    if (ship3.showInfo)
                    {
                        ship1active = false;
                        ship2active = false;
                        ship3active = true;
                    }
                    break;
                   

                case GameStates.Playing:
                    {
                        
                        //starfield.Update(gameTime);
                        UpdateEnemies(gameTime);
                        UpdateUfos(gameTime);
                        particleEngine.EmitterLocation = new Vector2(Player.Position.X, Player.Position.Y);
                        particleEngine.Update();
                        //spriteAnimation.Update(gameTime);
                        if (gameTimer > 60)
                        {
                            LetsSpawnThisBeast(gameTime);
                            if (bossActive == true)
                            {
                                boss.Initialize(new Vector2(900, 600));
                                for (int i = 0; i < bossArray.Count; i++)
                                    bossArray[i].Update(gameTime);
                            }
                        }
 
                        if (Player.ready)
                            updateBulletCollisionsAndShoot(gameTime);

                        if (bulletArray != null)
                        {
                            for (int i = 0; i < bulletArray.Count; i++)
                            {
                                bulletArray[i].Update();
                                if (bulletArray[i].Dead)
                                {
                                    bulletArray.RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                        if (mgunBulletArray != null)
                        {
                            for (int i = 0; i < mgunBulletArray.Count; i++)
                            {
                                mgunBulletArray[i].SetRotation();
                                mgunBulletArray[i].Update(gameTime);
                                if (!MiniGun.IsInRange(mgunBulletArray[i].center))
                                {
                                    mgunBulletArray[i].Destroy();
                                }
                                if (mgunBulletArray[i].dead == true)
                                {
                                    mgunBulletArray.RemoveAt(i);
                                    i--;
                                }
                                
                            }
                        }

                        //Poistetaan powerUp kun kerätty!

                        //Poistetaan minigun powerup kun kerätty!
                        if (homingArray != null)
                        {
                            for (int i = 0; i < homingArray.Count; i++)
                            {
                                homingArray[i].Update();
                                if (homingArray[i].active == false)
                                {
                                    homingArray.RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                        if (boss.victory == true)
                        {
                            MediaPlayer.Play(winner);
                            hiScores.ReadFile();
                            hiScores.WriteFile(Player.score);
                            gameState = GameStates.Victory;
                            
                        }
                        UpdateCollisions(gameTime);
                        Player.Update(gameTime);
                        if (MiniGun.isActive)
                            MiniGun.Update(gameTime);
                        ClosestEnemy(asteroidArray, ufoArray, bossArray);
                        UpdateHomingCollisions();
                       
                        if ((Keyboard.GetState().IsKeyDown(Keys.Escape)))
                        {
                            gameState = GameStates.Pause;
                            
                        }
                        if (Player.health <= 0)
                        {
                           
                            string points = Player.score.ToString();
                            gameState = GameStates.GameOver;
                            MediaPlayer.Play(gamuover);
                            hiScores.WriteFile(Player.score);
                        }
                        UpdateExplosions(gameTime);

                        base.Update(gameTime);
                    }
                    break;

             
                case GameStates.Pause:
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.Enter)))
                        {
                            gameState = GameStates.Playing;
                        }
                        else if ((Keyboard.GetState().IsKeyDown(Keys.X)))
                        {
                            gameState = GameStates.Menu;
                            ClearEverything();
                            boss.active = false;
                            boss.victory = false;
                            MediaPlayer.Play(menuSong);
                        }
                    }
                    break;
                case GameStates.Victory:
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.Escape)))
                        {
                            ClearEverything();
                            gameState = GameStates.Menu;
                            MediaPlayer.Play(menuSong);
                        }
                    }
                    break;
                case GameStates.GameOver:
                    {
                        //Jos valitaan uusi peli, tuhotaan kaikki vanhat tiedot ja alustetaan uusi peli :)
                        quit.Update(mouse);
                        playAgain.Update(mouse);
                        if (quit.isClicked)
                        {
                            MediaPlayer.Play(menuSong);
                            ClearEverything();
                            gameState = GameStates.Menu;
                        }
                        if (playAgain.isClicked)
                        {
                            //Edelleenkin tuhotaan kaikki paska ja aloitetaan uusi peli.
                            ClearEverything();
                            boss.active = false;
                            boss.victory = false;
                            gameState = GameStates.Playing;
                            MediaPlayer.Play(gameSong);
                        }
                    }
                    break;
                case GameStates.Highscores:
                    {
                        hiScores.ReadFile();
                        /*int score = 5998;
                        hiScores.WriteFile(score);*/
                        if ((Keyboard.GetState().IsKeyDown(Keys.Escape)))
                        {
                            gameState = GameStates.Menu;
                            MediaPlayer.Play(menuSong);
                        }
                       
                    }
                    break;
            }
            base.Update(gameTime);
        }
#endregion
        #region PIIRROT
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            if (gameState == GameStates.Intro)
                introScreen.Draw(spriteBatch);
           
            if (gameState == GameStates.Menu)
            {
                play.Draw(spriteBatch);
                options.Draw(spriteBatch);
                quit.Draw(spriteBatch);
                starfield.Draw(spriteBatch);
                
            }

            else if (gameState == GameStates.ShipChoose)
            {
                spriteBatch.Draw(Choose, new Rectangle(0, 0, 1920, 1080), Color.White);
                ship1.Draw(spriteBatch);
                ship2.Draw(spriteBatch);
                ship3.Draw(spriteBatch);
                if (ship1active)
                    spriteBatch.Draw(ship1info, new Rectangle(700, 200, 450, 275), Color.White);
                if (ship2active)
                    spriteBatch.Draw(ship2info, new Rectangle(700, 200, 450, 275), Color.White);
                if (ship3active)
                    spriteBatch.Draw(ship3info, new Rectangle(700, 200, 450, 275), Color.White);
            }
            else if (gameState == GameStates.Playing)
            {
                //Purkka jolla muutetaan hiscore.scores listasta stringi intiks. 
                int hiscore;
                Int32.TryParse(hiScores.scores[0], out hiscore);

                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                

                //starfield.Draw(spriteBatch);
                particleEngine.Draw(spriteBatch);
                if (bossActive == true)
                {
                    for (int i = 0; i < bossArray.Count; i++)
                    {
                        bossArray[i].Draw(spriteBatch);
                        spriteBatch.DrawString(font, "Boss Health " + bossArray[i].health, new Vector2(900, 15), Color.White);
                    }

                }
                //Piirrellään ja päivitellään tietoja pelaajan statistiikoista.
                healthBar.Draw(spriteBatch);
                
                spriteBatch.DrawString(font, "Health " + Player.health, new Vector2(50, 30), Color.White);
                spriteBatch.DrawString(font, "Score " + Player.score, new Vector2(50, 150), Color.White);
                spriteBatch.DrawString(font, "HighScore " + hiScores.scores[0], new Vector2(50, 200), Color.White);
                spriteBatch.DrawString(font, "Combo " + Player.combo, new Vector2(50, 100), Color.White);
                spriteBatch.DrawString(font, "Gun: " + Player.currentGun, new Vector2(50, 250), Color.White);
                if (Player.homingammo > 0)
                    spriteBatch.DrawString(font, "HomingAmmo: " + Player.homingammo, new Vector2(50, 300), Color.White);
                else if (Player.homingammo == 0)
                    spriteBatch.DrawString(font, "You are out of ammunition!", new Vector2(50, 300), Color.White);
                spriteBatch.DrawString(font, "Enemies killed: " + enemiesKilled, new Vector2(50, 400), Color.White);
                spriteBatch.DrawString(font, "Velocity " + Player.velocity, new Vector2(50, 500), Color.White);
                spriteBatch.DrawString(font, "Position " + Player.arrowPosition, new Vector2(50, 550), Color.White);
                //Pelin alkuspiikkei
                if (startGameTimer > 2 && startGameTimer < 7)
                    spriteBatch.DrawString(epicfont, "WELCOME....", new Vector2(650, 400), Color.White);
                else if (startGameTimer > 7 && startGameTimer < 11)
                    spriteBatch.DrawString(epicfont, "KEEP UP COMBO TO " + "\n" + "UPGRADE YOUR WEAPON!", new Vector2(650, 400), Color.White);
                else if (startGameTimer > 11.5 && startGameTimer < 13)
                    spriteBatch.DrawString(epicfont, "LETS GO!", new Vector2(650, 400), Color.White);
                if (Player.score > hiscore)
                {
                    hsTimer++;
                    if (hsTimer < 35)
                        spriteBatch.DrawString(epicfont, "New Highscore!!", new Vector2(650, 400), Color.White);
                }
                else if (MiniGun.isActive)
                {
                    minigunTimer++;
                    if (minigunTimer < 35)
                        spriteBatch.DrawString(epicfont, "Minigun Activated!", new Vector2(650, 400), Color.White);
                }
               

                foreach (MiniGunBullet b in mgunBulletArray)
                {
                    if (b != null)
                        b.Draw(spriteBatch);
                }

                foreach (HomingMinigunPowarUp d in homingArray)
                {
                    if (d != null)
                        d.Draw(spriteBatch);
                }
                
              

                for (int i = 0; i < asteroidArray.Count; i++)
                {
                    asteroidArray[i].Draw(spriteBatch);
                }
                foreach (Ufo u in ufoArray)
                {
                    if (u != null)
                        u.Draw(spriteBatch);
                }

                foreach (Bullet b in bulletArray)
                {
                    if (b != null)
                        b.Draw(spriteBatch);
                }
                for (int i = 0; i < explosions.Count; i++)
                {
                    explosions[i].Draw(spriteBatch);
                }
                Player.Draw(spriteBatch);
                if (MiniGun.isActive)
                    MiniGun.Draw(spriteBatch);
                

            }
            else if (gameState == GameStates.Victory)
            {
                spriteBatch.Draw(victory, new Rectangle(0, 0, 1920, 1080), Color.White);
                spriteBatch.DrawString(epicfont, "Your score is: " + Player.score , new Vector2(700, 700), Color.White);
            }
            else if (gameState == GameStates.Pause)
            {
                spriteBatch.Draw(pause, new Rectangle(0, 0, 1920, 1080), Color.White);
            }

            else if (gameState == GameStates.GameOver)
            {
                quit.Draw(spriteBatch);
                playAgain.Draw(spriteBatch);
                spriteBatch.DrawString(font, "Your Score is " + Player.score, new Vector2(900, 900), Color.White);
            }
            else if (gameState == GameStates.Highscores)
            {
                spriteBatch.Draw(highScores, new Rectangle(0, 0, 1920, 1080), Color.White);
                hiScores.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
       
    }
}
        #endregion