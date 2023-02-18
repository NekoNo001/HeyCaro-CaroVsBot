using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro
{
    //thong tin nguoi choi
    public class Player
    {
        private string name;

        public string Name { get => name; set => name = value; }

        private Image mark;

        public Image Mark { get => mark; set => mark = value; }

        private int score;

        public int Score { get => score; set => score = value; }

        private string mode;

        public string Mode { get => mode; set => mode = value; }

        public Player(string name, Image mark,int Score,string mode)
        {
            this.Name = name;
            this.Mark = mark;
            this.Score = Score;
            this.Mode = mode;
        }
    }
}
