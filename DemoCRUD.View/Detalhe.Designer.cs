namespace DemoCRUD.View
{
    partial class Detalhe
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
            this.lblNome = new System.Windows.Forms.Label();
            this.lblCpf = new System.Windows.Forms.Label();
            this.lblNascimento = new System.Windows.Forms.Label();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(93, 9);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(86, 31);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "label1";
            // 
            // lblCpf
            // 
            this.lblCpf.AutoSize = true;
            this.lblCpf.Location = new System.Drawing.Point(12, 68);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(35, 13);
            this.lblCpf.TabIndex = 1;
            this.lblCpf.Text = "label2";
            // 
            // lblNascimento
            // 
            this.lblNascimento.AutoSize = true;
            this.lblNascimento.Location = new System.Drawing.Point(12, 105);
            this.lblNascimento.Name = "lblNascimento";
            this.lblNascimento.Size = new System.Drawing.Size(35, 13);
            this.lblNascimento.TabIndex = 2;
            this.lblNascimento.Text = "label2";
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Location = new System.Drawing.Point(12, 142);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(35, 13);
            this.lblRegistro.TabIndex = 3;
            this.lblRegistro.Text = "label2";
            // 
            // Detalhe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 176);
            this.Controls.Add(this.lblRegistro);
            this.Controls.Add(this.lblNascimento);
            this.Controls.Add(this.lblCpf);
            this.Controls.Add(this.lblNome);
            this.Name = "Detalhe";
            this.Text = "Detalhe";
            this.Load += new System.EventHandler(this.Detalhe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.Label lblNascimento;
        private System.Windows.Forms.Label lblRegistro;
    }
}