namespace InfraGuard_BO
{
    partial class Home
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
            this.txtboxUsuario = new System.Windows.Forms.TextBox();
            this.txtboxPassword = new System.Windows.Forms.TextBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelForgotPassword = new System.Windows.Forms.LinkLabel();
            this.labelSingIn = new System.Windows.Forms.LinkLabel();
            this.BtnLogIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtboxUsuario
            // 
            this.txtboxUsuario.Location = new System.Drawing.Point(44, 148);
            this.txtboxUsuario.Name = "txtboxUsuario";
            this.txtboxUsuario.Size = new System.Drawing.Size(393, 23);
            this.txtboxUsuario.TabIndex = 0;
            this.txtboxUsuario.TextChanged += new System.EventHandler(this.txtboxUsuario_TextChanged);
            // 
            // txtboxPassword
            // 
            this.txtboxPassword.Location = new System.Drawing.Point(44, 207);
            this.txtboxPassword.Name = "txtboxPassword";
            this.txtboxPassword.Size = new System.Drawing.Size(393, 23);
            this.txtboxPassword.TabIndex = 1;
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelUsuario.Location = new System.Drawing.Point(44, 115);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(194, 30);
            this.labelUsuario.TabIndex = 2;
            this.labelUsuario.Text = "Nombre de Usuario";
            this.labelUsuario.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPassword.Location = new System.Drawing.Point(44, 174);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(118, 30);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Contraseña";
            // 
            // labelForgotPassword
            // 
            this.labelForgotPassword.AutoSize = true;
            this.labelForgotPassword.Location = new System.Drawing.Point(44, 264);
            this.labelForgotPassword.Name = "labelForgotPassword";
            this.labelForgotPassword.Size = new System.Drawing.Size(136, 15);
            this.labelForgotPassword.TabIndex = 4;
            this.labelForgotPassword.TabStop = true;
            this.labelForgotPassword.Text = "Olvidaste la Contraseña?";
            // 
            // labelSingIn
            // 
            this.labelSingIn.AutoSize = true;
            this.labelSingIn.Location = new System.Drawing.Point(44, 249);
            this.labelSingIn.Name = "labelSingIn";
            this.labelSingIn.Size = new System.Drawing.Size(118, 15);
            this.labelSingIn.TabIndex = 5;
            this.labelSingIn.TabStop = true;
            this.labelSingIn.Text = "No te has registrado?";
            this.labelSingIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelSingIn_LinkClicked);
            // 
            // BtnLogIn
            // 
            this.BtnLogIn.Location = new System.Drawing.Point(341, 236);
            this.BtnLogIn.Name = "BtnLogIn";
            this.BtnLogIn.Size = new System.Drawing.Size(83, 43);
            this.BtnLogIn.TabIndex = 6;
            this.BtnLogIn.Text = "Log In";
            this.BtnLogIn.UseVisualStyleBackColor = true;
            this.BtnLogIn.Click += new System.EventHandler(this.BtnLogIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(44, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 46);
            this.label1.TabIndex = 7;
            this.label1.Text = "Infraguard Back Office";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 304);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnLogIn);
            this.Controls.Add(this.labelSingIn);
            this.Controls.Add(this.labelForgotPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.txtboxPassword);
            this.Controls.Add(this.txtboxUsuario);
            this.Name = "Home";
            this.Text = "Log In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtboxUsuario;
        private TextBox txtboxPassword;
        private Label labelUsuario;
        private Label labelPassword;
        private LinkLabel labelForgotPassword;
        private LinkLabel labelSingIn;
        private Button BtnLogIn;
        private Label label1;
    }
}