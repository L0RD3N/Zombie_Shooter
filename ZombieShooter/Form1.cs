using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombieShooter
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }
        bool goUp = false, goDown = false, goLeft = false, goRight = false, shooting = false;
        int playerSpeed = 10, zombieSpeed = 2, bulletSpeed = 12, seconds = 0, ammo = 10, kills = 0;
        PictureBox ammoPack = new PictureBox();
        bool facingLeft= false, facingRight = false, facingDown = true, facingUp = false;
        SoundPlayer shotSound = new SoundPlayer(), zombiedead = new SoundPlayer(), playerdead = new SoundPlayer(), reload = new SoundPlayer();

        private void resetGame()
        {
            
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();

		}

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32)
                SpawnBullet();
        }

		private void timerZombie_Tick(object sender, EventArgs e)
		{
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox)
                {
                    string t = control.Tag as string;
                    PictureBox pb = control as PictureBox;
                    if (t == "z")
                    {
                        if (pb.Left < pBoxPlayer.Left)
                        {
                            pb.Image = Properties.Resources.zright;
                            pb.Left += zombieSpeed;
                        }
                        if (pb.Left > pBoxPlayer.Left)
                        {
                            pb.Image = Properties.Resources.zleft;
                            pb.Left -= zombieSpeed;
                        }
                        if (pb.Top < pBoxPlayer.Top)
                        {
                            pb.Image = Properties.Resources.zdown;
                            pb.Top += zombieSpeed;
                        }
                        if (pb.Top > pBoxPlayer.Top)
                        {
                            pb.Image = Properties.Resources.zup;
                            pb.Top -= zombieSpeed;
                        }
                    }
                }
            }
		}

		private void spawnZombie()
        {
            PictureBox zombie = new PictureBox();
            zombie.Image = Properties.Resources.zdown;
            Random rnd = new Random();
			int x = rnd.Next(50, this.ClientSize.Width - 50);
			int y = rnd.Next(50, this.ClientSize.Height - 50);
            zombie.Location = new Point(x, y);
            zombie.Tag = "z";
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombie.BringToFront();
            this.Controls.Add(zombie);
		}

        private void checkZombieCollision(PictureBox pb)
        {
            foreach (Control control1 in this.Controls)
            {

                if (control1 is PictureBox)
                {
                    string t = control1.Tag.ToString();
                    if (t == "z")
                    {
                        if (pb.Bounds.IntersectsWith(control1.Bounds))
                        {
                            this.Controls.Remove(control1);
                            this.Controls.Remove(pb);
                            kills++;
                            zombiedead.Play();
                            updateLabel();
                            spawnZombie();
                        }
                    }
                }
            }
        }

        private void timerBullet_Tick(object sender, EventArgs e)
        {

            foreach (Control control in this.Controls)
            {

                if (control is PictureBox)
                {
                    string t = control.Tag.ToString();
                    if (control.Tag.ToString() == "1" || control.Tag.ToString() == "2" || control.Tag.ToString() == "3" || control.Tag.ToString() == "4")
                    {
                        if (control.Left <= 0 || control.Left >= this.ClientSize.Width || control.Top >= this.ClientSize.Height || control.Top <= 0)
                        { this.Controls.Remove(control); }

                        if (t == "1")
                        {
                            control.Top -= bulletSpeed;
                        }
                        if (t == "2")
                            control.Left += bulletSpeed;

                        if (t == "3")
                            control.Top += bulletSpeed;
                        if (t == "4")
                            control.Left -= bulletSpeed;

                        checkZombieCollision((PictureBox) control);

                    }
                        
                }
                    
            }
        }

        private void SpawnAmmo()
        {
            
            if (ammoPack.Enabled)
            {
                this.Controls.Remove(ammoPack);
                ammoPack.Enabled = false;
            }
            Random rnd = new Random();
            int x = rnd.Next(50, this.ClientSize.Width - 50);
            int y = rnd.Next(50, this.ClientSize.Height - 50);
            
            ammoPack.Location = new Point(x, y);
            ammoPack.SizeMode = PictureBoxSizeMode.AutoSize;
            ammoPack.Size = new Size(30, 30);
            ammoPack.Enabled = true;
            ammoPack.Tag = "ammo";
            ammoPack.Image = Properties.Resources.ammo_Image;
            this.Controls.Add(ammoPack);
            
        }

        private void SpawnBullet()
        {
            if (ammo > 0)
            {
                //MessageBox.Show("yes");
                shotSound.Play();
                PictureBox bullet = new PictureBox();
                bullet.BackColor = Color.White;
                bullet.Size = new Size(5, 5);
                int width = pBoxPlayer.Width;
                int height = pBoxPlayer.Height;
                int locX = pBoxPlayer.Location.X, locY = pBoxPlayer.Location.Y;
                bullet.Tag = "0";

                if (facingDown)
                {
                    bullet.Location = new Point(locX + width / 2 - 5, locY + height);
                    bullet.Tag = "3";
                }

                if (facingUp)
                {
                    bullet.Location = new Point(locX + width / 2 + 1, locY);
                    bullet.Tag = "1";
                }

                if (facingRight)
                {
                    bullet.Location = new Point(locX + width, locY + height / 2);
                    bullet.Tag = "2";
                }

                if (facingLeft)
                {
                    bullet.Location = new Point(locX, locY + height / 2 - 3);
                    bullet.Tag = "4";
                }

                this.Controls.Add(bullet);
                bullet.BringToFront();
                ammo--;
                updateLabel();
            }
            
            
        }

        private void timerBoost_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (seconds % 7 == 0 && seconds > 0)
            {
                SpawnAmmo();
				seconds = 0;
			}

            if (seconds % 3 == 0 && seconds > 0)
            {
				spawnZombie();
			}
        }

        private void updateLabel()
        {
            lblAmmo.Text = "Ammo: " + ammo.ToString();
            lblKills.Text = "Kills: " + kills.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to zombie shooter!\n Use WASD to move around, and Space to shoot.\nKill as many zombies as you can. Ammo packs will spawn periodically.\nGood luck!", "How to play", MessageBoxButtons.OK, MessageBoxIcon.Information);
            prBarHealth.Value = 110;
            timerGame.Start();
            timerBoost.Start();
            timerBullet.Start();
            timerZombie.Start();
            string path = AppDomain.CurrentDomain.BaseDirectory + @"sounds\shot.wav";
            shotSound.SoundLocation = path;
			path = AppDomain.CurrentDomain.BaseDirectory + @"sounds\playerdeath.wav";
            playerdead.SoundLocation = path;
			path = AppDomain.CurrentDomain.BaseDirectory + @"sounds\zombiedeath.wav";
            zombiedead.SoundLocation = path;
			path = AppDomain.CurrentDomain.BaseDirectory + @"sounds\reload.wav";
            reload.SoundLocation = path;
		}

        private void checkCollision()
        {

            foreach (Control control in this.Controls)
            {

                if (control is PictureBox)
                {
                    string t = control.Tag.ToString();
                    if (pBoxPlayer.Bounds.IntersectsWith (control.Bounds))
                    {
                        if (t == "ammo" && control.Enabled)
                        {
                            ammo += 5;
                            reload.Play();
                            this.Controls.Remove(ammoPack);
                            ammoPack.Enabled = false;
                            updateLabel();
                        }

                        if (t == "z" && control.Enabled == true)
                        {
                            pBoxPlayer.BringToFront();

                            if (prBarHealth.Value > 0)
                            { prBarHealth.Value -= 1; }
                            if (prBarHealth.Value == 0)
                            {
                                timerGame.Stop();
                                timerBoost.Stop();
                                timerBullet.Stop();
								timerZombie.Stop();
                                pBoxPlayer.Image = Properties.Resources.dead;
                                pBoxPlayer.BringToFront();
                                playerdead.Play();
								DialogResult dr = MessageBox.Show("You managed to kill " + kills.ToString() + " zombies! Good job!\nWould you like to play again?", "You died!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dr == DialogResult.Yes)
                                {
                                    resetGame();
                                }
                                else
                                {
                                    Application.Exit();
                                }
                            }
                        }
                    }
                    
                }

            }
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            if (goLeft)
            {
                facingLeft = true;
                facingDown = false;
                facingUp = false;
                facingRight = false;
                if (pBoxPlayer.Left - playerSpeed > 0)
                    pBoxPlayer.Left -= playerSpeed;
            }
            if (goRight)
            {
                facingRight = true;
                facingDown = false;
                facingUp = false;
                facingLeft = false;
                if (pBoxPlayer.Left + playerSpeed < this.ClientSize.Width - pBoxPlayer.Width)
                    pBoxPlayer.Left += playerSpeed; 
            }
            if (goUp)
            {
                facingUp = true;
                facingDown = false;
                facingRight = false;
                facingLeft = false;
                if (pBoxPlayer.Top - playerSpeed > 0)
                    pBoxPlayer.Top -= playerSpeed; 
            }
            if (goDown)
            {
                facingDown = true;
                facingUp = false;
                facingLeft = false;
                facingRight = false;
                if (pBoxPlayer.Top + playerSpeed < this.ClientSize.Height - pBoxPlayer.Height)
                    pBoxPlayer.Top += playerSpeed;
            }

            checkCollision();
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                { goUp = false; }

            if (e.KeyCode == Keys.S)
                { goDown = false; }

            if (e.KeyCode == Keys.D)
                { goRight = false; }

            if (e.KeyCode == Keys.A)
                { goLeft = false; }

            //if (e.KeyCode == Keys.Space)
            //    { shooting = false; }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                pBoxPlayer.Image = Properties.Resources.up;
                lblDir.Text = "U";
                goUp = true;
            }
            if (e.KeyCode == Keys.S)
            {
                pBoxPlayer.Image = Properties.Resources.down;
                lblDir.Text = "D";
                goDown = true;
            }
            if (e.KeyCode == Keys.A)
            {
                pBoxPlayer.Image = Properties.Resources.left;
                lblDir.Text = "L";
                goLeft = true;
            }
            if (e.KeyCode == Keys.D)
            {
                pBoxPlayer.Image = Properties.Resources.right;
                lblDir.Text = "R";
                goRight = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                timerGame.Stop();
                timerZombie.Stop();
                timerBullet.Stop();
                timerBoost.Stop();
                goUp = goDown = goLeft = goRight = false;
                DialogResult dr = MessageBox.Show("Are you sure you want to quit?", "Quit game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    timerGame.Start();
					timerZombie.Start();
					timerBullet.Start();
					timerBoost.Start();
				}
            }
        }
    }
}
