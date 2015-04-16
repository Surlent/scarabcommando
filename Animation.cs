using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Scarab_Commando
{
    class Animation:Sprite
    {
        // N�mero de frames na anima��o
        protected int frameCount;
        public int FrameCount
        { get { return frameCount; } set { frameCount = value; } }

        // Contador do tempo restante at� o frame seguinte
        protected float timer = 0f;
        public float Timer
        { get { return timer; } set { timer = value; } }


        // Tempo entre dois frames da anima��o
        protected float interval = 100f;
        public float Interval
        { get { return interval; } set { interval = value; } }

     
        // Posi��o inicial da anima��o
        protected Vector2 initialPosition;
        public Vector2 InitialPosition
        {
            get { return initialPosition; }
            set { initialPosition = value; }
        }

        // Frame atual da anima��o
        protected int currentFrame = 0;
        public int CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }

        // Largura de cada frame
        protected int width;
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        // Altura de cada frame
        protected int height;
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        // Ret�ngulo que percorrer� a imagem
        protected Rectangle SourceRect;
        // Ret�ngulo aonde a anima��o ser� desenhada na tela
        protected Rectangle DestRect;

        
        private bool isOn, isGoing;
        
        // Ativada para preparar a anima��o
        public bool IsOn
        {
            get { return isOn; }
            set { isOn = value; }
        }

        // Mostra que a anima��o est� ocorrendo
        public bool IsGoing
        {
            get { return isGoing; }
            set { isGoing = value; }
        }

        // M�todo da anima��o propriamente dita
        public void Animate(GameTime gameTime, Vector2 position)
        {
            // Diminui o tempo restante at� o frame seguinte
            Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            // Checa se o tempo passado � maior que o intervalo. Se sim, passa para o frame seguinte.
            if (Timer > Interval)
            {

                CurrentFrame++;

                // Se o frame for o �ltimo, volta para o primeiro frame, desativa a anima��o e zera a vibra��o do GamePad
                if (CurrentFrame > FrameCount - 1)
                {

                    CurrentFrame = 0;
                    IsGoing = false;
                    GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
                }
                // Zera o timer a cada frame trocado
                Timer = 0f;
            }



            // O ret�ngulo percorre a imagem e usa a largura de cada frame e o n�mero do frame atual para determinar qual ser� desenhado
           SourceRect = new Rectangle(CurrentFrame * Width, 0, Width, Height);

            // O ret�ngulo aonde a anima��o ser� desenhada na tela
           DestRect = new Rectangle((int)position.X, (int)position.Y, Width, Height);

            
        }

        // Desenha a anima��o com base nos ret�ngulos de fonte(SourceRect) e destino(DestRect) passados
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(mSpriteTexture, DestRect, SourceRect, Color.White);
        }
    }
}
