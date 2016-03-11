using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BouncingSquare
{
    public class Paddle
    {

    #region  Private Members 
        //declares variables
        private Form _form = null;
        private PictureBox _box = null;
        private Random _rnd = null;
        #endregion

    #region  Public Properties
        public PictureBox Box
        {
            get { return _box; }
        }

        public Keys Key
        { // sets location/direction of paddle when keys are pressed and sets value for mouse move
            set
            {
                if (value == Keys.Left)
                {
                    Point location = _box.Location;
                    location.X -= 80;
                    if (location.X >= 0)
                    {
                        _box.Location = location;
                    }
                    else
                    {
                        location.X = 0;
                        _box.Location = location;
                    }
                    //      _box.Location = location;
                }
                else if (value == Keys.Right)
                {
                    Point location = _box.Location;
                    location.X += 80;
                    if (location.X <= _form.Width - _box.Width)
                    {
                        _box.Location = location;
                    }
                    else
                    {
                        location.X = _form.Width - _box.Width - 20;
                        _box.Location = location;
                    }
                }
            }
        }            
      
        public int Location        {
            set
            {
                Point location = _box.Location;
                location.X = value;
                _box.Location = location;
            }
        }   
    #endregion

    #region  Private Methods 

    #endregion

    #region Public Methods

    #endregion

    #region Public Events

    #endregion

    #region Public Event Handlers

    #endregion

    #region Construction

    public Paddle(Form frm, Random rnd)
        {
            //creates new picture box, and establishes parameters
            _box = new PictureBox();
            _form = frm;
            _rnd = rnd;
            Size size = new Size(500, 5);
            int x = (_form.Width / 2) - (_box.Width);
            int y = (_form.Height) - (_box.Height);
            Point location = new Point(x, y);
            _box.Location = location;
            _box.BackColor = Color.Lime;
            _form.Controls.Add(_box);

        }
        #endregion

    }
}
