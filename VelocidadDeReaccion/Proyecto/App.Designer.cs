
namespace Proyecto
{
    partial class App
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
            this.lblComenzar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAhora = new System.Windows.Forms.Label();
            this.lblEspere = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblComenzar
            // 
            this.lblComenzar.Enabled = false;
            this.lblComenzar.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblComenzar.Location = new System.Drawing.Point(166, 321);
            this.lblComenzar.Name = "lblComenzar";
            this.lblComenzar.Size = new System.Drawing.Size(949, 49);
            this.lblComenzar.TabIndex = 0;
            this.lblComenzar.Text = "¡Haga click para comenzar en cualquier lugar para comenzar!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(615, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 1;
            // 
            // lblAhora
            // 
            this.lblAhora.AutoSize = true;
            this.lblAhora.Enabled = false;
            this.lblAhora.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAhora.Location = new System.Drawing.Point(511, 321);
            this.lblAhora.Name = "lblAhora";
            this.lblAhora.Size = new System.Drawing.Size(277, 38);
            this.lblAhora.TabIndex = 2;
            this.lblAhora.Text = "¡Haga click ahora!";
            // 
            // lblEspere
            // 
            this.lblEspere.AutoSize = true;
            this.lblEspere.Enabled = false;
            this.lblEspere.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblEspere.Location = new System.Drawing.Point(581, 321);
            this.lblEspere.Name = "lblEspere";
            this.lblEspere.Size = new System.Drawing.Size(119, 38);
            this.lblEspere.TabIndex = 3;
            this.lblEspere.Text = "Espere";
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.lblEspere);
            this.Controls.Add(this.lblAhora);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblComenzar);
            this.Name = "App";
            this.Text = "App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblComenzar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAhora;
        private System.Windows.Forms.Label lblEspere;
    }
}