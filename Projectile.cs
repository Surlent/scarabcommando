using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Scarab_Commando
{
    // A classe Projectile herda todas as caracter�sticas de Sprite
    
    public class Projectile: Sprite
    {
        // Constr�i o proj�til pedindo seu tipo como par�metro
        public Projectile(string theType)
        { type = theType; }

        private bool shoot, shooting;
        // Ativada no in�cio de cada tiro
        public bool Shoot
        {
            get { return shoot; }
            set { shoot = value; }
        }

        // Ativada durante cada tiro
        public bool Shooting
        {
            get { return shooting; }
            set { shooting = value; }

        }

        // Tipo do proj�til
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        // Som a ser executado
        private string cue;
        public string Cue
        {
            get { return cue; }
            set { cue = value; }
        }
        
       

       
    }
}
