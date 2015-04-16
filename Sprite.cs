using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Scarab_Commando
{
    public class Sprite
    {
        // Construtor da classe
        public Sprite()
        {
          
        }

        // Vari�vel para rota��o
        private float rotation=0;
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        // A posi��o atual do sprite
        public Vector2 position = new Vector2(0, 0);
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        // A velocidade do sprite
        public Vector2 speed;
        public Vector2 Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        // A textura usada para desenhar o sprite
        public Texture2D mSpriteTexture;

        // O nome do arquivo de textura na pasta Content
        public string AssetName;

        // A vida do sprite
        private int life;
        public int Life
        {
            get { return life; }
            set { life = value; }
        }

        // O tamanho do sprite com a escala aplicada
        public Rectangle size;
        public Rectangle Size
        {
            get { return size; }
            set { size = value; }
        }
        
        // O aumento ou a redu��o do sprite. Quando alterado pela propriedade, o tamanho do sprite � automaticamente recalculado
        protected float mScale = 1.0f;
        public float Scale
        {
            get { return mScale;}
            set 
            { 
                mScale = value;
                // Recalcula o tamanho do sprite com a nova escala
                size = new Rectangle(0, 0, (int)(mSpriteTexture.Width * Scale), (int)(mSpriteTexture.Height * Scale));
            }
        }

        // Carrega o conte�do do sprite
        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            // Carrega a textura e determina seu tamanho
            mSpriteTexture = theContentManager.Load<Texture2D>(theAssetName);
            // Atribui o nome da imagem a uma propriedade
            AssetName = theAssetName;
            // Determina o tamanho do sprite baseado na imagem
            size = new Rectangle(0, 0, (int)(mSpriteTexture.Width * Scale), (int)(mSpriteTexture.Height * Scale));
        }


        
        // Atualiza o sprite e muda sua posi��o de acordo com a velocidade, o tempo e o �ngulo de rota��o passado
        public void Update(GameTime theGameTime, Vector2 theSpeed, float theRotation)
        {
            speed = theSpeed;
            // O Co-seno do �ngulo � a varia��o da velocidade no eixo X, devendo ser multiplicado pela velocidade desse eixo
            position.X += speed.X*(float)Math.Cos(Rotation) * (float)theGameTime.ElapsedGameTime.TotalSeconds;
            // O seno do �ngulo � a varia��o da velocidade no eixo Y, devendo ser multiplicado pela velocidade desse eixo
            position.Y += speed.Y * (float)Math.Sin(Rotation) * (float)theGameTime.ElapsedGameTime.TotalSeconds;
            // Atualiza o tamanho do sprite
            size = new Rectangle(0, 0, (int)(mSpriteTexture.Width * Scale), (int)(mSpriteTexture.Height * Scale));
        }

        // Atualiza o sprite e muda sua posi��o sem mudar de dire��o
        public void Update(GameTime theGameTime, Vector2 theSpeed)
        {
            speed = theSpeed;
            position.X += speed.X * (float)theGameTime.ElapsedGameTime.TotalSeconds;
            position.Y += speed.Y  * (float)theGameTime.ElapsedGameTime.TotalSeconds;
            size = new Rectangle(0, 0, (int)(mSpriteTexture.Width * Scale), (int)(mSpriteTexture.Height * Scale));
        }

        // Desenha o sprite sem rota��o
        public void Draw(SpriteBatch theSpriteBatch)
        {            
            theSpriteBatch.Draw(mSpriteTexture, Position, 
                new Rectangle(0, 0, mSpriteTexture.Width, mSpriteTexture.Height), 
                Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

        // Desenha o sprite com rota��o
        public void Draw(SpriteBatch theSpriteBatch, float theRotation)
        {
            theSpriteBatch.Draw(mSpriteTexture, Position,
                new Rectangle(0, 0, mSpriteTexture.Width, mSpriteTexture.Height),
                Color.White, theRotation, new Vector2(size.Width/2,size.Height/2), Scale, SpriteEffects.None, 0);
        }

        // Testa colis�o com outro sprite usando seu tamanho
        public bool Collision(Sprite sprite)
        {
            // Caso os sprites n�o se encostem, retorna falso. Caso contr�rio, retorna verdadeiro.
            if ((this.Position.X > sprite.Position.X + sprite.size.Width)
                || (this.Position.Y > sprite.Position.Y + sprite.size.Height)
                || (this.Position.X + this.size.Width < sprite.Position.X)
                || (this.Position.Y + this.size.Height < sprite.Position.Y))
                return false;
            else return true;
        }

        // Testa colis�o com sprite determinando sua �rea
        public bool Collision(Sprite sprite,float spriteWidth, float spriteHeight)
        {
            // Caso os sprites n�o se encostem, retorna falso. Caso contr�rio, retorna verdadeiro.
            if ((this.Position.X > sprite.Position.X + spriteWidth)
                || (this.Position.Y > sprite.Position.Y + spriteHeight)
                || (this.Position.X + this.size.Width < sprite.Position.X)
                || (this.Position.Y + this.size.Height < sprite.Position.Y))
                return false;
            else return true;
        }

        // Testa se o sprite saiu da tela, pedindo o objeto GraphicsDevice do jogo (este fornece largura e altura da tela)
        public bool OutOfSight(GraphicsDevice g)
        {
            if ((this.Position.X > g.Viewport.Width) || (this.Position.X < 0) || (this.Position.Y > g.Viewport.Height) || (this.Position.Y < 0))
                return true;
            else return false;

        }
    }
}
