namespace Dragons2
{
    partial class Form1
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
            this.dgvPlayField = new System.Windows.Forms.DataGridView();
            this.dgvPlayerCards = new System.Windows.Forms.DataGridView();
            this.pbCardDeck = new System.Windows.Forms.PictureBox();
            this.pb5 = new System.Windows.Forms.PictureBox();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.pb2 = new System.Windows.Forms.PictureBox();
            this.pb3 = new System.Windows.Forms.PictureBox();
            this.pb4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblRedCardCount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblGoldCardCount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblBlackCardCount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblGreenCardCount = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblBlueCardCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayerCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlayField
            // 
            this.dgvPlayField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayField.ColumnHeadersVisible = false;
            this.dgvPlayField.Location = new System.Drawing.Point(12, 12);
            this.dgvPlayField.Name = "dgvPlayField";
            this.dgvPlayField.RowHeadersVisible = false;
            this.dgvPlayField.Size = new System.Drawing.Size(1330, 977);
            this.dgvPlayField.TabIndex = 1;
            this.dgvPlayField.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlayField_CellClick);
            this.dgvPlayField.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPlayField_CellMouseClick);
            // 
            // dgvPlayerCards
            // 
            this.dgvPlayerCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayerCards.ColumnHeadersVisible = false;
            this.dgvPlayerCards.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPlayerCards.Location = new System.Drawing.Point(1359, 532);
            this.dgvPlayerCards.Name = "dgvPlayerCards";
            this.dgvPlayerCards.RowHeadersVisible = false;
            this.dgvPlayerCards.Size = new System.Drawing.Size(324, 457);
            this.dgvPlayerCards.TabIndex = 2;
            this.dgvPlayerCards.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlayerCards_CellClick);
            this.dgvPlayerCards.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPlayerCards_CellMouseClick);
            // 
            // pbCardDeck
            // 
            this.pbCardDeck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCardDeck.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbCardDeck.Image = global::Dragons2.Properties.Resources.Deck;
            this.pbCardDeck.Location = new System.Drawing.Point(1489, 280);
            this.pbCardDeck.Name = "pbCardDeck";
            this.pbCardDeck.Size = new System.Drawing.Size(182, 237);
            this.pbCardDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCardDeck.TabIndex = 3;
            this.pbCardDeck.TabStop = false;
            this.pbCardDeck.Click += new System.EventHandler(this.pbCardDeck_Click);
            // 
            // pb5
            // 
            this.pb5.Location = new System.Drawing.Point(1551, 12);
            this.pb5.Name = "pb5";
            this.pb5.Size = new System.Drawing.Size(64, 110);
            this.pb5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb5.TabIndex = 4;
            this.pb5.TabStop = false;
            this.pb5.Click += new System.EventHandler(this.pb1_Click);
            // 
            // pb1
            // 
            this.pb1.Location = new System.Drawing.Point(1439, 37);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(64, 110);
            this.pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb1.TabIndex = 5;
            this.pb1.TabStop = false;
            this.pb1.Click += new System.EventHandler(this.pb1_Click);
            // 
            // pb2
            // 
            this.pb2.Location = new System.Drawing.Point(1489, 164);
            this.pb2.Name = "pb2";
            this.pb2.Size = new System.Drawing.Size(64, 110);
            this.pb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb2.TabIndex = 6;
            this.pb2.TabStop = false;
            this.pb2.Click += new System.EventHandler(this.pb1_Click);
            // 
            // pb3
            // 
            this.pb3.Location = new System.Drawing.Point(1619, 164);
            this.pb3.Name = "pb3";
            this.pb3.Size = new System.Drawing.Size(64, 110);
            this.pb3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb3.TabIndex = 7;
            this.pb3.TabStop = false;
            this.pb3.Click += new System.EventHandler(this.pb1_Click);
            // 
            // pb4
            // 
            this.pb4.Location = new System.Drawing.Point(1656, 37);
            this.pb4.Name = "pb4";
            this.pb4.Size = new System.Drawing.Size(64, 110);
            this.pb4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb4.TabIndex = 8;
            this.pb4.TabStop = false;
            this.pb4.Click += new System.EventHandler(this.pb1_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(1381, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(1381, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(1381, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(1381, 391);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Round";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(1381, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Player";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(1381, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "Number of players";
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(1359, 478);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 39);
            this.label7.TabIndex = 15;
            // 
            // lblRedCardCount
            // 
            this.lblRedCardCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRedCardCount.Location = new System.Drawing.Point(1439, 152);
            this.lblRedCardCount.Name = "lblRedCardCount";
            this.lblRedCardCount.Size = new System.Drawing.Size(39, 15);
            this.lblRedCardCount.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(1369, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "Red color:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(1369, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Gold color:";
            // 
            // lblGoldCardCount
            // 
            this.lblGoldCardCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGoldCardCount.Location = new System.Drawing.Point(1439, 167);
            this.lblGoldCardCount.Name = "lblGoldCardCount";
            this.lblGoldCardCount.Size = new System.Drawing.Size(39, 15);
            this.lblGoldCardCount.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(1369, 199);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 15);
            this.label11.TabIndex = 23;
            this.label11.Text = "Black color:";
            // 
            // lblBlackCardCount
            // 
            this.lblBlackCardCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBlackCardCount.Location = new System.Drawing.Point(1439, 198);
            this.lblBlackCardCount.Name = "lblBlackCardCount";
            this.lblBlackCardCount.Size = new System.Drawing.Size(39, 15);
            this.lblBlackCardCount.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Location = new System.Drawing.Point(1369, 184);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 15);
            this.label13.TabIndex = 21;
            this.label13.Text = "Green color:";
            // 
            // lblGreenCardCount
            // 
            this.lblGreenCardCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGreenCardCount.Location = new System.Drawing.Point(1439, 183);
            this.lblGreenCardCount.Name = "lblGreenCardCount";
            this.lblGreenCardCount.Size = new System.Drawing.Size(39, 15);
            this.lblGreenCardCount.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(1369, 214);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 15);
            this.label15.TabIndex = 25;
            this.label15.Text = "Blue color:";
            // 
            // lblBlueCardCount
            // 
            this.lblBlueCardCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBlueCardCount.Location = new System.Drawing.Point(1439, 213);
            this.lblBlueCardCount.Name = "lblBlueCardCount";
            this.lblBlueCardCount.Size = new System.Drawing.Size(39, 15);
            this.lblBlueCardCount.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1797, 1001);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblBlueCardCount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblBlackCardCount);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblGreenCardCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblGoldCardCount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblRedCardCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb4);
            this.Controls.Add(this.pb3);
            this.Controls.Add(this.pb2);
            this.Controls.Add(this.pb1);
            this.Controls.Add(this.pb5);
            this.Controls.Add(this.pbCardDeck);
            this.Controls.Add(this.dgvPlayerCards);
            this.Controls.Add(this.dgvPlayField);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayerCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPlayField;
        private System.Windows.Forms.DataGridView dgvPlayerCards;
        private System.Windows.Forms.PictureBox pbCardDeck;
        private System.Windows.Forms.PictureBox pb5;
        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.PictureBox pb2;
        private System.Windows.Forms.PictureBox pb3;
        private System.Windows.Forms.PictureBox pb4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblRedCardCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblGoldCardCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblBlackCardCount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblGreenCardCount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblBlueCardCount;
    }
}

