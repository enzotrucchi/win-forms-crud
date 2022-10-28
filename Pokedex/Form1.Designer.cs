namespace Pokedex
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pcbPokemon = new System.Windows.Forms.PictureBox();
            this.cmbPokemon = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPokemon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbPokemon
            // 
            this.pcbPokemon.Location = new System.Drawing.Point(52, 116);
            this.pcbPokemon.Name = "pcbPokemon";
            this.pcbPokemon.Size = new System.Drawing.Size(242, 200);
            this.pcbPokemon.TabIndex = 0;
            this.pcbPokemon.TabStop = false;
            // 
            // cmbPokemon
            // 
            this.cmbPokemon.FormattingEnabled = true;
            this.cmbPokemon.Location = new System.Drawing.Point(52, 66);
            this.cmbPokemon.Name = "cmbPokemon";
            this.cmbPokemon.Size = new System.Drawing.Size(242, 28);
            this.cmbPokemon.TabIndex = 1;
            this.cmbPokemon.SelectedIndexChanged += new System.EventHandler(this.cmbPokemon_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(431, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(376, 398);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 567);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmbPokemon);
            this.Controls.Add(this.pcbPokemon);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbPokemon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pcbPokemon;
        private ComboBox cmbPokemon;
        private PictureBox pictureBox1;
    }
}