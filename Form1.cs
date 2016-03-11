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
        Random rnd = new Random();
        Paddle paddle = null;
        Int32 iCount = 0;

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

        private void FormBouncingSquare_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //key and mouse event handlers
            if (e.KeyData == Keys.Escape)
            {
                Application.Exit();
            }

            else if (e.KeyData == Keys.N)
            {
                iCount++;
                Square square = new Square(this, rnd, paddle);          
                label1.Text = iCount.ToString() + " Squares"; //counter
            }

            if (e.KeyData == Keys.N)
            {
                iCount = iCount++;
                
            }
            else if (e.KeyData == Keys.Left || e.KeyData == Keys.Right)
            {
                paddle.Key = e.KeyData; 
            }
        }     
    }
}
