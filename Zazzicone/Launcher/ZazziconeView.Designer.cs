namespace Launcher
{
    partial class ZazziconeView
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
            this.nud1 = new System.Windows.Forms.NumericUpDown();
            this.nud2 = new System.Windows.Forms.NumericUpDown();
            this.nud3 = new System.Windows.Forms.NumericUpDown();
            this.nud4 = new System.Windows.Forms.NumericUpDown();
            this.nud5 = new System.Windows.Forms.NumericUpDown();
            this.btnRollDices = new System.Windows.Forms.Button();
            this.btnAddScore = new System.Windows.Forms.Button();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.btnAddNewPlayer = new System.Windows.Forms.Button();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.lvwGame = new System.Windows.Forms.ListView();
            this.txtLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nud1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud5)).BeginInit();
            this.SuspendLayout();
            // 
            // nud1
            // 
            this.nud1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nud1.Location = new System.Drawing.Point(52, 38);
            this.nud1.Name = "nud1";
            this.nud1.Size = new System.Drawing.Size(30, 20);
            this.nud1.TabIndex = 4;
            // 
            // nud2
            // 
            this.nud2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nud2.Location = new System.Drawing.Point(88, 38);
            this.nud2.Name = "nud2";
            this.nud2.Size = new System.Drawing.Size(30, 20);
            this.nud2.TabIndex = 5;
            // 
            // nud3
            // 
            this.nud3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nud3.Location = new System.Drawing.Point(124, 38);
            this.nud3.Name = "nud3";
            this.nud3.Size = new System.Drawing.Size(30, 20);
            this.nud3.TabIndex = 6;
            // 
            // nud4
            // 
            this.nud4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nud4.Location = new System.Drawing.Point(160, 38);
            this.nud4.Name = "nud4";
            this.nud4.Size = new System.Drawing.Size(30, 20);
            this.nud4.TabIndex = 7;
            // 
            // nud5
            // 
            this.nud5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nud5.Location = new System.Drawing.Point(196, 38);
            this.nud5.Name = "nud5";
            this.nud5.Size = new System.Drawing.Size(30, 20);
            this.nud5.TabIndex = 8;
            // 
            // btnRollDices
            // 
            this.btnRollDices.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRollDices.Location = new System.Drawing.Point(12, 38);
            this.btnRollDices.Name = "btnRollDices";
            this.btnRollDices.Size = new System.Drawing.Size(34, 20);
            this.btnRollDices.TabIndex = 3;
            this.btnRollDices.Text = "Roll";
            this.btnRollDices.UseVisualStyleBackColor = true;
            this.btnRollDices.Click += new System.EventHandler(this.btnRollDices_Click);
            // 
            // btnAddScore
            // 
            this.btnAddScore.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddScore.Location = new System.Drawing.Point(232, 38);
            this.btnAddScore.Name = "btnAddScore";
            this.btnAddScore.Size = new System.Drawing.Size(82, 20);
            this.btnAddScore.TabIndex = 10;
            this.btnAddScore.Text = "Add";
            this.btnAddScore.UseVisualStyleBackColor = true;
            this.btnAddScore.Click += new System.EventHandler(this.btnAddScore_Click);
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlayerName.Location = new System.Drawing.Point(12, 12);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(214, 20);
            this.txtPlayerName.TabIndex = 0;
            this.txtPlayerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlayerName_KeyDown);
            // 
            // btnAddNewPlayer
            // 
            this.btnAddNewPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddNewPlayer.Location = new System.Drawing.Point(232, 11);
            this.btnAddNewPlayer.Name = "btnAddNewPlayer";
            this.btnAddNewPlayer.Size = new System.Drawing.Size(34, 20);
            this.btnAddNewPlayer.TabIndex = 1;
            this.btnAddNewPlayer.Text = "Add";
            this.btnAddNewPlayer.UseVisualStyleBackColor = true;
            this.btnAddNewPlayer.Click += new System.EventHandler(this.btnAddNewPlayer_Click);
            // 
            // btnStartGame
            // 
            this.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStartGame.Location = new System.Drawing.Point(272, 11);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(42, 20);
            this.btnStartGame.TabIndex = 2;
            this.btnStartGame.Text = "Start";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // lvwGame
            // 
            this.lvwGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwGame.Location = new System.Drawing.Point(12, 64);
            this.lvwGame.Name = "lvwGame";
            this.lvwGame.Size = new System.Drawing.Size(302, 371);
            this.lvwGame.TabIndex = 11;
            this.lvwGame.UseCompatibleStateImageBehavior = false;
            this.lvwGame.View = System.Windows.Forms.View.Details;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 441);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(302, 72);
            this.txtLog.TabIndex = 12;
            // 
            // ZazziconeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 525);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lvwGame);
            this.Controls.Add(this.txtPlayerName);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.btnAddNewPlayer);
            this.Controls.Add(this.btnAddScore);
            this.Controls.Add(this.btnRollDices);
            this.Controls.Add(this.nud5);
            this.Controls.Add(this.nud4);
            this.Controls.Add(this.nud3);
            this.Controls.Add(this.nud2);
            this.Controls.Add(this.nud1);
            this.Name = "ZazziconeView";
            this.Text = "Zazzicone";
            ((System.ComponentModel.ISupportInitialize)(this.nud1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown nud1;
        private System.Windows.Forms.NumericUpDown nud2;
        private System.Windows.Forms.NumericUpDown nud3;
        private System.Windows.Forms.NumericUpDown nud4;
        private System.Windows.Forms.NumericUpDown nud5;
        private System.Windows.Forms.Button btnRollDices;
        private System.Windows.Forms.Button btnAddScore;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Button btnAddNewPlayer;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.ListView lvwGame;
        private System.Windows.Forms.TextBox txtLog;
    }
}

