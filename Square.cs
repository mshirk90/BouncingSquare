using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BouncingSquare
{
    public class Square : Event, IDisposable
    {
        #region Private Members
        //declare variables
        private Guid _id = Guid.Empty;
        private Form _form = null;
        private PictureBox _box = null;
        private Timer _timer = null;
        private int _xDir = 0;
        private int _yDir = 0;
        private Random _rnd = null;
        private Paddle _paddle = null;
      
        private int _value = 0;
        
        #endregion

        #region Public Properties
        public Guid Id
        {
            get
            {
                return _id;
            }
        }
        public PictureBox Box
        {
            get { return _box; }
        }
        public int xDir
        {
            get { return _xDir; }
            set { _xDir = value; }
        }
        public int yDir
        {
            get { return _yDir; }
            set { _yDir = value; }
        }
        public Paddle Paddle
        {
            get { return _paddle; }
        }
        public Random rnd
        {
            get
            {
                return _rnd;
            }
        }
        public Form frm
        {
            get
            {
                return _form;
            }
        }
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        //sets box location
        private void Move()
        {
            Point location = _box.Location;
            location.X += _xDir;
            location.Y += _yDir;
            _box.Location = location;

            if (location.Y > _form.Height - _box.Height)
            {
                Dispose();
                ScoreEventArgs e = new ScoreEventArgs(string.Empty, -this._value);
                RaiseEvent(this, e);
                
            }

            else if (location.Y <= 0)
            {
                _yDir = -_yDir;
            }

            else if (location.X >= _form.Width - _box.Width)
            {
                _xDir = -_xDir;
            }

            else if (location.X <= 0)
            {
                _xDir = -_xDir;
            }
            else if (_paddle.Box.Bounds.IntersectsWith(_box.Bounds))
            {
                _yDir = -_yDir;
           
                //change the score              
                
                    ScoreEventArgs e = new ScoreEventArgs(String.Empty, _value);
                    RaiseEvent(this, e);
                {
                    Square square = new Square(_form, _rnd, _paddle, _id);
                }
                
                
            }
          
        }
        #endregion

        #region Event Handlers
        //starts "Move" with timer tick
        private void _timer_Tick(object sender, EventArgs e)
        {
            Move();
        }       
        #endregion

        #region Construction

        public Square(Form frm, Random rnd, Paddle paddle, Guid id)
        {
            // creates a new picture box, and establishes parameters
            _id = id;
            _paddle = paddle;
            _rnd = rnd;
            _value = _rnd.Next(1, 10);
            _form = frm;
            _box = new PictureBox();
            _box.Paint += _box_Paint;
            _box.Width = _rnd.Next(11, 11);
            _box.Height = _rnd.Next(11, 11);
            _box.BackColor = Color.FromArgb(_rnd.Next(0, 256), _rnd.Next(0, 256), _rnd.Next(0, 256));
            Point location = new Point();
            
            //sets location
            location.X = _rnd.Next(0, _form.Width - _box.Width);
            location.Y = _rnd.Next(0, _form.Height - _box.Height);
            _box.Location = location;

            //sets timer
            _timer = new Timer();
            _timer.Interval = 1;
            _timer.Enabled = true;
            _timer.Tick += _timer_Tick;

            do
            {
                _xDir = _rnd.Next(-1, 20);

            } while (_xDir == 0);

            do
            {
                _yDir = _rnd.Next(-1, 23);

            } while (_yDir == 0);
            _form.Controls.Add(_box);
        }       
        private void _box_Paint(object sender, PaintEventArgs e)
        {
            using (Font myfont = new Font("Chiller", 20, FontStyle.Bold))
            {
                e.Graphics.DrawString(_value.ToString(),
                    myfont, Brushes.Black, new Point(10, 10));
            }
        }
        #endregion

        #region     IDisposable Support 
        // disposes squares that fall below bottom of screen       
        private bool disposedValue = false; 

           protected virtual void Dispose(bool disposing)
           {
               if (!disposedValue)
               {
                   if (disposing)
                   {
                       _timer.Enabled = false;
                       _box.Dispose();
                    
                       _form.Controls.Remove(_box);
                       _form = null;
                       _rnd = null;
                   }
                   disposedValue = true;
               }
           }           
           public void Dispose()
           {              
               Dispose(true);             
           }          
        #endregion

    }
}





