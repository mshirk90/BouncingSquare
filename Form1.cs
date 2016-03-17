using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingSquare
{
    public partial class formBouncingSquare : Form
    {
        //declare variables
        Guid id = new Guid();
        Random rnd = new Random();
        Paddle paddle = null;
        Int32 iCount = 0;
        List<Square> squares = new List<Square>();

        public formBouncingSquare()
        {
            //starts form and sets key and mouse events
            InitializeComponent();
            this.KeyDown += FormBouncingSquare_KeyDown;
            this.Load += FormBouncingSquare_Load;
            this.MouseMove += FormBouncingSquare_MouseMove;
            Cursor.Hide();        
        }

        private void FormBouncingSquare_MouseMove(object sender, MouseEventArgs e)
        {
            //sets paddle location on x axis
            paddle.Location = e.Location.X;
        }

        private void FormBouncingSquare_Load(object sender, EventArgs e)
        {
            // creates paddle
            paddle = new Paddle(this, rnd);
        }

        public void FormBouncingSquare_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //key and mouse event handlers
            if (e.KeyData == Keys.Escape)
            {
                Application.Exit();
            }

            else if (e.KeyData == Keys.N)
            {
                if (squares.Count < 6)
                {
                    iCount++;
                    Square square = new Square(this, rnd, paddle, id);
                    square.score += Square_score;
                    
                    squares.Add(square);
                }
            }
           

            if (e.KeyData == Keys.N)
            {
          
                
            }
            else if (e.KeyData == Keys.Left || e.KeyData == Keys.Right)
            {
                paddle.Key = e.KeyData; 
            }
        }

        private void Square_score(object sender, ScoreEventArgs e)
        {            
            int score = Convert.ToInt32(lblScore.Text);
            score += e.Points;
            lblScore.Text = score.ToString();

            if (e.Points < 0)
            {
                Square sq = (Square)sender;
                Guid id = sq.Id;                
                for (int i = 0; i < squares.Count; i++)
                {
                    
                    if (squares[i].Id == id)
                    {
                        squares.RemoveAt(i);
                        break;
                    }
                }
            }
        }
    }
}
