namespace InfraGuard_BO
{
    partial class RolesForm
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
            this.txtRolName = new System.Windows.Forms.TextBox();
            this.btnAgregarRol = new System.Windows.Forms.Button();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.btnActualizarRoles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRolName
            // 
            this.txtRolName.Location = new System.Drawing.Point(12, 12);
            this.txtRolName.Name = "txtRolName";
            this.txtRolName.Size = new System.Drawing.Size(144, 23);
            this.txtRolName.TabIndex = 0;
            this.txtRolName.Text = "Nombre del rol";
            // 
            // btnAgregarRol
            // 
            this.btnAgregarRol.Location = new System.Drawing.Point(181, 12);
            this.btnAgregarRol.Name = "btnAgregarRol";
            this.btnAgregarRol.Size = new System.Drawing.Size(115, 26);
            this.btnAgregarRol.TabIndex = 1;
            this.btnAgregarRol.Text = "Agregar";
            this.btnAgregarRol.UseVisualStyleBackColor = true;
            this.btnAgregarRol.Click += new System.EventHandler(this.btnAgregarRol_Click);
            // 
            // dgvRoles
            // 
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Location = new System.Drawing.Point(12, 44);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.RowTemplate.Height = 25;
            this.dgvRoles.Size = new System.Drawing.Size(284, 310);
            this.dgvRoles.TabIndex = 2;
            // 
            // btnActualizarRoles
            // 
            this.btnActualizarRoles.Location = new System.Drawing.Point(12, 360);
            this.btnActualizarRoles.Name = "btnActualizarRoles";
            this.btnActualizarRoles.Size = new System.Drawing.Size(284, 66);
            this.btnActualizarRoles.TabIndex = 3;
            this.btnActualizarRoles.Text = "Actualizar";
            this.btnActualizarRoles.UseVisualStyleBackColor = true;
            // 
            // RolesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 450);
            this.Controls.Add(this.btnActualizarRoles);
            this.Controls.Add(this.dgvRoles);
            this.Controls.Add(this.btnAgregarRol);
            this.Controls.Add(this.txtRolName);
            this.Name = "RolesForm";
            this.Text = "RolesForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtRolName;
        private Button btnAgregarRol;
        private DataGridView dgvRoles;
        private Button btnActualizarRoles;
    }
}