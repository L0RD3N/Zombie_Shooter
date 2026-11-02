namespace ZombieShooter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.pBoxPlayer = new System.Windows.Forms.PictureBox();
			this.timerGame = new System.Windows.Forms.Timer(this.components);
			this.timerBoost = new System.Windows.Forms.Timer(this.components);
			this.lblAmmo = new System.Windows.Forms.Label();
			this.lblKills = new System.Windows.Forms.Label();
			this.prBarHealth = new System.Windows.Forms.ProgressBar();
			this.lblHealth = new System.Windows.Forms.Label();
			this.lblDir = new System.Windows.Forms.Label();
			this.timerBullet = new System.Windows.Forms.Timer(this.components);
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.timerZombie = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pBoxPlayer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pBoxPlayer
			// 
			this.pBoxPlayer.Image = global::ZombieShooter.Properties.Resources.down;
			this.pBoxPlayer.Location = new System.Drawing.Point(659, 421);
			this.pBoxPlayer.Margin = new System.Windows.Forms.Padding(4);
			this.pBoxPlayer.Name = "pBoxPlayer";
			this.pBoxPlayer.Size = new System.Drawing.Size(71, 100);
			this.pBoxPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pBoxPlayer.TabIndex = 0;
			this.pBoxPlayer.TabStop = false;
			this.pBoxPlayer.Tag = "player";
			// 
			// timerGame
			// 
			this.timerGame.Interval = 20;
			this.timerGame.Tick += new System.EventHandler(this.timerGame_Tick);
			// 
			// timerBoost
			// 
			this.timerBoost.Interval = 1000;
			this.timerBoost.Tick += new System.EventHandler(this.timerBoost_Tick);
			// 
			// lblAmmo
			// 
			this.lblAmmo.AutoSize = true;
			this.lblAmmo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAmmo.Location = new System.Drawing.Point(16, 11);
			this.lblAmmo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblAmmo.Name = "lblAmmo";
			this.lblAmmo.Size = new System.Drawing.Size(101, 20);
			this.lblAmmo.TabIndex = 1;
			this.lblAmmo.Text = "Ammo: 10";
			// 
			// lblKills
			// 
			this.lblKills.AutoSize = true;
			this.lblKills.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblKills.Location = new System.Drawing.Point(16, 52);
			this.lblKills.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblKills.Name = "lblKills";
			this.lblKills.Size = new System.Drawing.Size(70, 20);
			this.lblKills.TabIndex = 3;
			this.lblKills.Text = "Kills: 0";
			// 
			// prBarHealth
			// 
			this.prBarHealth.Location = new System.Drawing.Point(1188, 2);
			this.prBarHealth.Margin = new System.Windows.Forms.Padding(4);
			this.prBarHealth.Maximum = 110;
			this.prBarHealth.Name = "prBarHealth";
			this.prBarHealth.Size = new System.Drawing.Size(241, 28);
			this.prBarHealth.TabIndex = 4;
			this.prBarHealth.Value = 110;
			// 
			// lblHealth
			// 
			this.lblHealth.AutoSize = true;
			this.lblHealth.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHealth.Location = new System.Drawing.Point(1113, 7);
			this.lblHealth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblHealth.Name = "lblHealth";
			this.lblHealth.Size = new System.Drawing.Size(65, 20);
			this.lblHealth.TabIndex = 5;
			this.lblHealth.Text = "Health";
			// 
			// lblDir
			// 
			this.lblDir.AutoSize = true;
			this.lblDir.Enabled = false;
			this.lblDir.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDir.Location = new System.Drawing.Point(16, 95);
			this.lblDir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDir.Name = "lblDir";
			this.lblDir.Size = new System.Drawing.Size(70, 20);
			this.lblDir.TabIndex = 6;
			this.lblDir.Text = "Kills: 0";
			this.lblDir.Visible = false;
			// 
			// timerBullet
			// 
			this.timerBullet.Interval = 20;
			this.timerBullet.Tick += new System.EventHandler(this.timerBullet_Tick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::ZombieShooter.Properties.Resources.zup;
			this.pictureBox1.Location = new System.Drawing.Point(825, 52);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(71, 71);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Tag = "z";
			// 
			// timerZombie
			// 
			this.timerZombie.Interval = 15;
			this.timerZombie.Tick += new System.EventHandler(this.timerZombie_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.SlateGray;
			this.ClientSize = new System.Drawing.Size(1445, 937);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblDir);
			this.Controls.Add(this.lblHealth);
			this.Controls.Add(this.prBarHealth);
			this.Controls.Add(this.lblKills);
			this.Controls.Add(this.lblAmmo);
			this.Controls.Add(this.pBoxPlayer);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Zombie Shooter";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.pBoxPlayer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBoxPlayer;
        private System.Windows.Forms.Timer timerGame;
        private System.Windows.Forms.Timer timerBoost;
        private System.Windows.Forms.Label lblAmmo;
        private System.Windows.Forms.Label lblKills;
        private System.Windows.Forms.ProgressBar prBarHealth;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.Label lblDir;
        private System.Windows.Forms.Timer timerBullet;
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Timer timerZombie;
	}
}

