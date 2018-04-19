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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1797, 1001);
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
    }
}

