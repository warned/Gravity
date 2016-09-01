//TODO
//1.Add last position so that point where ball touches ground can be calculated exactly
//2.Change delete algorithm to add ball numbers to queue

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gravity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Start Structs & Lists
        public struct Ball
        {
            public double[] fPos;
            public double[] fVel;
            public double[] fAcc;
            public double fMass;
            public double fDiam;
            public Color cFill;
            public Color cOutline;
            public Boolean bDelete;
            public Boolean bBadPos;
            public Timer tmrBeforeDelete;
            public int iExpired;
            //Constructor
            public Ball(double[] fPos, double[] fVel, double[] fAcc, double fMass, double fDiam, Color cFill, Color cOutline, Boolean bDelete, Boolean bBadPos, Timer tmrBeforeDelete, int iExpired)
            {
                this.fPos = fPos;
                this.fVel = fVel;
                this.fAcc = fAcc;
                this.fMass = fMass;
                this.fDiam = fDiam;
                this.cFill = cFill;
                this.cOutline = cOutline;
                this.bDelete = bDelete;
                this.bBadPos = bBadPos;
                this.tmrBeforeDelete = tmrBeforeDelete;
                this.iExpired = iExpired;
            }
        }
        public struct Force
        {
            public double[] fTotal;
            public double[] fNoise;
            public double[] fRand;
            public Force(double[] fTotal, double[] fNoise, double[] fRand)
            {
                this.fTotal = fTotal;
                this.fNoise = fNoise;
                this.fRand = fRand;
            }
        }
        public struct Control
        {
            public DateTime dPLastUpdate;
            public DateTime dVLastUpdate;

            public Control(DateTime dPLastUpdate, DateTime dVLastUpdate)
            {
                this.dPLastUpdate = dPLastUpdate;
                this.dVLastUpdate = dPLastUpdate;
            }
        }
        public struct SysVars
        {
            public double fGravity;
            public double iGround;
            public int iGap;
            public double fRandForce;
            public int iHeader;
            public SysVars(double fGravity, int iGround, int iGap, double fRandForce, int iHeader)
            {
                this.fGravity = fGravity;
                this.iGround = iGround;
                this.iGap = iGap;
                this.fRandForce = fRandForce;
                this.iHeader = iHeader;
            }
        }
        //
        public List<Ball> myBalls = new List<Ball>();
        public SysVars mySysVars = new SysVars();
        public List<Force> myForces = new List<Force>();
        public List<Control> myControls = new List<Control>();
        // End Structs & Lists

        // Start Initialize
        private void Form1_Load(object sender, EventArgs e)
        {
            pb1.Paint += new System.Windows.Forms.PaintEventHandler(this.pb1_Paint);
            pb1.Dock = DockStyle.Fill;
            pb1.BackColor = Color.Black;
            InitializeSysVars();
            tmrUpdate.Enabled = true;
            tmrMouseCoords.Enabled = true;
            UpdateRandomForce();
        }
        private void InitializeSysVars()
        {
            mySysVars.iGround = 30;
            mySysVars.fGravity = 1;
            mySysVars.iGap = 200;
            mySysVars.iHeader = 100;
        }
        // End Initialize
        
        private void pb1_Click(object sender, EventArgs e)
        {

            Point p = this.PointToScreen(new Point(0, 0));
            if (MousePosition.Y - p.Y < mySysVars.iHeader)
            {
                myBalls.Add(new Ball(new double[2] { MousePosition.X - p.X, MousePosition.Y - p.Y }, new double[2] { 0, 0 }, new double[2] { 0, 0 }, 1, 20, Color.Blue, Color.Blue, false, false, new Timer(), 0));
                myBalls[myBalls.Count - 1].tmrBeforeDelete.Interval = 4000;
                myBalls[myBalls.Count - 1].tmrBeforeDelete.Tick += new System.EventHandler(this.tmrBeforeDelete_Tick);
                myForces.Add(new Force(new double[2] { 0, 0 }, new double[2] { 0, 0 }, new double[2] {mySysVars.fRandForce, 0 }));
                UpdateForces(myForces[myForces.Count - 1]);
                myControls.Add(new Control(System.DateTime.Now, System.DateTime.Now));
            }
        }
     
        // Start Handle Bad Balls
        private void CheckIfPosIsValid(int i)
        {
            Ball ballTemp;
            int iMaxEx;

            ballTemp = myBalls[i];
            if (!ballTemp.bBadPos)
            {
                // if Ball hits left side of screen
                if ((ballTemp.fPos[0] - ballTemp.fDiam) < 0) 
                {
                    //b.fPos[0] = b.fDiam;
                    ballTemp.cFill = Color.Red;
                    HaltBall(ballTemp, myForces[i]);
                    lblCountBad.Text = Convert.ToString(Convert.ToInt32(lblCountBad.Text) + 1);
                    UpdateRandomForce();
                    ballTemp.bBadPos = true;
                }
                // if Ball hits right side of screen
                if (ballTemp.fPos[0] + ballTemp.fDiam > pb1.Width)
                {
                    //b.fPos[0] = pb1.Width - b.fDiam;
                    ballTemp.cFill = Color.Red;
                    HaltBall(ballTemp, myForces[i]);
                    lblCountBad.Text = Convert.ToString(Convert.ToInt32(lblCountBad.Text) + 1);
                    UpdateRandomForce();
                    ballTemp.bBadPos = true;
                }
                // if ball hits ground level ground
                if (ballTemp.fPos[1] + (ballTemp.fDiam / 2) > (pb1.Height - mySysVars.iGround))
                {
                    // if ball hits left side of ground
                    if ((ballTemp.fPos[0] < ((pb1.Width - (mySysVars.iGap - ballTemp.fDiam)) / 2)))
                    {
                        //b.fPos[1] =  (pb1.Height - mySysVars.iGround)- (b.fDiam / 2);
                        //b.fPos[0] = ((pb1.Width - (mySysVars.iGap - b.fDiam)) / 2);
                        ballTemp.cFill = Color.Red;
                        HaltBall(ballTemp, myForces[i]);
                        lblCountBad.Text = Convert.ToString(Convert.ToInt32(lblCountBad.Text) + 1);
                        UpdateRandomForce();
                        ballTemp.bBadPos = true;
                    }
                    // if ball hits right side of ground
                    if (ballTemp.fPos[0] > ((pb1.Width + mySysVars.iGap - ballTemp.fDiam) / 2))
                    {
                        //b.fPos[1] =  (pb1.Height - mySysVars.iGround)- (b.fDiam / 2);
                        //b.fPos[0] = ((pb1.Width + mySysVars.iGap - b.fDiam) / 2);
                        ballTemp.cFill = Color.Red;
                        HaltBall(ballTemp, myForces[i]);
                        lblCountBad.Text = Convert.ToString(Convert.ToInt32(lblCountBad.Text) + 1);
                        UpdateRandomForce();
                        ballTemp.bBadPos = true;
                    }
                }
                if(ballTemp.fPos[1] > (pb1.Height + (ballTemp.fDiam/2)))
                {
                    lblCountGood.Text = Convert.ToString(Convert.ToInt32(lblCountGood.Text) + 1);
                    UpdateRandomForce();
                    ballTemp.bDelete = true;
                }
            }
            if (ballTemp.bBadPos)
            {
                iMaxEx = 0;
                for (int i2 = 0; i2 < myBalls.Count; i2++)
                {
                    if (myBalls[i2].iExpired > iMaxEx)
                    {
                        iMaxEx = myBalls[i2].iExpired;
                    }
                }
                if (ballTemp.iExpired == 0)
                {
                    ballTemp.iExpired = iMaxEx + 1;
                    ballTemp.tmrBeforeDelete.Enabled = true;
                }
            }
            myBalls[i] = ballTemp;
        }
        private void HaltBall(Ball b, Force f)
        {
            for (int i = 0; i < b.fAcc.Length; i++)
            {
                b.fAcc[i] = 0;
                b.fVel[i] = 0;
                f.fTotal[i] = Convert.ToDouble(0);
            }
        }
        private void PurgeBalls()
        {
            List<Ball> lstTempBalls = new List<Ball>();
            List<Force> lstTempForces = new List<Force>();
            List<Control> lstTempControls = new List<Control>();

            for (int i = 0; i < myBalls.Count; i++)
            {
                if (myBalls[i].bDelete == false)
                {
                    lstTempBalls.Add(myBalls[i]);
                    lstTempControls.Add(myControls[i]);
                    lstTempForces.Add(myForces[i]);
                }
            }
            myBalls = lstTempBalls;
            myControls = lstTempControls;
            myForces = lstTempForces;
        }
        private void tmrBeforeDelete_Tick(Object sender, EventArgs e)
        {
            Ball ballTemp;
            for (int i = 0; i < myBalls.Count; i++)
            {
                if (myBalls[i].iExpired == 1)
                {
                    ballTemp = myBalls[i];
                    ballTemp.bDelete = true;
                    ballTemp.tmrBeforeDelete.Enabled = false;
                    myBalls[i] = ballTemp;
                }
                else if (myBalls[i].iExpired > 1)
                {
                    ballTemp = myBalls[i];
                    ballTemp.iExpired -= 1;
                    myBalls[i] = ballTemp;
                }
            }
        }
        // End Handle Bad Balls
        
        private void pb1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //Pen p = System.Drawing.Pens.Blue;
            SolidBrush b = new SolidBrush(Color.White);

            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;
            b = new SolidBrush(Color.Green);
            g.FillRectangle(b, new Rectangle(0, (int)(pb1.Height - mySysVars.iGround), (int)((pb1.Width) / 2 - (mySysVars.iGap / 2)), (int)mySysVars.iGround));
            //g.FillRectangle(b, new Rectangle((int)((pb1.Width) / 2 - 50), (int)(pb1.Height - mySysVars.iGround), 100, (int)mySysVars.iGround));
            g.FillRectangle(b, new Rectangle((int)((pb1.Width) / 2 + (mySysVars.iGap / 2)), (int)(pb1.Height - mySysVars.iGround), (int)((pb1.Width) / 2 - (mySysVars.iGap / 2)), (int)mySysVars.iGround));

            for (int i = 0; i < myBalls.Count; i++)
            {
                b = new SolidBrush(myBalls[i].cFill);
                //g.DrawEllipse(p, (int)((ball.fPos[0]) - ((ball.fDiam) / 2)), (int)((ball.fPos[1]) - ((ball.fDiam) / 2)), (int)ball.fDiam, (int)ball.fDiam);
                g.FillEllipse(b, (int)((myBalls[i].fPos[0]) - ((myBalls[i].fDiam) / 2)), (int)((myBalls[i].fPos[1]) - ((myBalls[i].fDiam) / 2)), (int)myBalls[i].fDiam, (int)myBalls[i].fDiam);
                //g.FillEllipse(b,)
            }
            //g.FillRectangle(b, new Rectangle(0, 0, (int)pb1.Width, (int)mySysVars.iGround));
              Pen p;

            p = new System.Drawing.Pen(System.Drawing.Color.White);
            g.DrawLine(p, 0, mySysVars.iHeader, pb1.Width, mySysVars.iHeader);
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            tmrUpdate.Enabled = false;
            for (int i = 0; i < myBalls.Count; i++)
            {
                UpdateAcceleration(myBalls[i],myForces[i]);
                UpdateVelocity(myBalls[i], myControls[i]);
                UpdatePosition(myBalls[i], myControls[i]);
                CheckIfPosIsValid(i);
            }
            PurgeBalls();
            pb1.Invalidate();
            tmrUpdate.Enabled = true;
        }

        private void tmrMouseCoords_Tick(object sender, EventArgs e)
        {
            Point screenCoordinates = this.PointToScreen(new Point(0, 0)); 

            lblMouseX.Text = Convert.ToString(MousePosition.X - screenCoordinates.X);
            lblMouseY.Text = Convert.ToString(MousePosition.Y - screenCoordinates.Y);
        }

        // Start Update Ball Movement
        private void UpdateRandomForce()
        {
            Random r = new Random();
            double d;
            d = r.Next(-500, 500);
            mySysVars.fRandForce = d/1000;
            lblRandX.Text = Convert.ToString(mySysVars.fRandForce);
        }
        private void UpdateForces(Force f)
        {
            f.fTotal[0] = f.fRand[0]; 
            f.fTotal[1] = mySysVars.fGravity;
        }
        private void UpdateAcceleration(Ball b, Force f)
        {
            //a = F/m
            b.fAcc[0] = f.fTotal[0] / b.fMass;
            b.fAcc[1] = f.fTotal[1] / b.fMass;
        }
        private void UpdateVelocity(Ball b, Control c)
        {
            double fmSElapsed;

            TimeSpan dTimeElapsed;
            if (c.dVLastUpdate != new DateTime())
            {
                dTimeElapsed = System.DateTime.Now.Subtract(c.dVLastUpdate);
                fmSElapsed = dTimeElapsed.Milliseconds + (dTimeElapsed.Seconds * 1000);
                b.fVel[0] += (fmSElapsed * b.fAcc[0]) / 1000;
                b.fVel[1] += (fmSElapsed * b.fAcc[1]) / 1000;
            }
            c.dVLastUpdate = System.DateTime.Now;
        }
        private void UpdatePosition(Ball b, Control c)
        {
            double fmSElapsed;
            TimeSpan dTimeElapsed;

            if (c.dPLastUpdate != new DateTime())
            {
                dTimeElapsed = System.DateTime.Now.Subtract(c.dPLastUpdate);
                fmSElapsed = dTimeElapsed.Milliseconds + (dTimeElapsed.Seconds) * 1000;
                b.fPos[0] += (fmSElapsed * b.fVel[0]) / 1000;
                b.fPos[1] += (fmSElapsed * b.fVel[1]) / 1000;
            }
            c.dPLastUpdate = System.DateTime.Now;
        }
        // End Update Ball Movement
    }
}
