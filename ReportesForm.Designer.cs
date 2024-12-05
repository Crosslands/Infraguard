namespace InfraGuard_BO
{
    partial class ReportesForm
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
            this.dgvReportes = new System.Windows.Forms.DataGridView();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.btnCambiarEstado = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.ReportelogLinks = new System.Windows.Forms.Button();
            this.logLinkSession = new System.Windows.Forms.Button();
            this.btnCrearRoles = new System.Windows.Forms.Button();
            this.btnGestionarUsuarios = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReportes
            // 
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Location = new System.Drawing.Point(12, 82);
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.RowTemplate.Height = 25;
            this.dgvReportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportes.Size = new System.Drawing.Size(739, 423);
            this.dgvReportes.TabIndex = 0;
            // 
            // cbEstado
            // 
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(549, 53);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(121, 23);
            this.cbEstado.TabIndex = 1;
            // 
            // btnCambiarEstado
            // 
            this.btnCambiarEstado.Location = new System.Drawing.Point(676, 53);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(75, 23);
            this.btnCambiarEstado.TabIndex = 2;
            this.btnCambiarEstado.Text = "Aplicar";
            this.btnCambiarEstado.UseVisualStyleBackColor = true;
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(468, 52);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
            // 
            // ReportelogLinks
            // 
            this.ReportelogLinks.Location = new System.Drawing.Point(771, 53);
            this.ReportelogLinks.Name = "ReportelogLinks";
            this.ReportelogLinks.Size = new System.Drawing.Size(171, 68);
            this.ReportelogLinks.TabIndex = 4;
            this.ReportelogLinks.Text = "Logs de Reportes";
            this.ReportelogLinks.UseVisualStyleBackColor = true;
            this.ReportelogLinks.Click += new System.EventHandler(this.ReportelogLinks_Click);
            // 
            // logLinkSession
            // 
            this.logLinkSession.Location = new System.Drawing.Point(771, 139);
            this.logLinkSession.Name = "logLinkSession";
            this.logLinkSession.Size = new System.Drawing.Size(171, 68);
            this.logLinkSession.TabIndex = 5;
            this.logLinkSession.Text = "Logs de Sesiones";
            this.logLinkSession.UseVisualStyleBackColor = true;
            this.logLinkSession.Click += new System.EventHandler(this.logLinkSession_Click);
            // 
            // btnCrearRoles
            // 
            this.btnCrearRoles.Location = new System.Drawing.Point(771, 424);
            this.btnCrearRoles.Name = "btnCrearRoles";
            this.btnCrearRoles.Size = new System.Drawing.Size(171, 68);
            this.btnCrearRoles.TabIndex = 6;
            this.btnCrearRoles.Text = "Crear Roles";
            this.btnCrearRoles.UseVisualStyleBackColor = true;
            this.btnCrearRoles.Click += new System.EventHandler(this.btnCrearRoles_Click);
            // 
            // btnGestionarUsuarios
            // 
            this.btnGestionarUsuarios.Location = new System.Drawing.Point(771, 213);
            this.btnGestionarUsuarios.Name = "btnGestionarUsuarios";
            this.btnGestionarUsuarios.Size = new System.Drawing.Size(171, 68);
            this.btnGestionarUsuarios.TabIndex = 7;
            this.btnGestionarUsuarios.Text = "Gestionar usuarios";
            this.btnGestionarUsuarios.UseVisualStyleBackColor = true;
            this.btnGestionarUsuarios.Click += new System.EventHandler(this.btnGestionarUsuarios_Click);
            // 
            // ReportesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 532);
            this.Controls.Add(this.btnGestionarUsuarios);
            this.Controls.Add(this.btnCrearRoles);
            this.Controls.Add(this.logLinkSession);
            this.Controls.Add(this.ReportelogLinks);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnCambiarEstado);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.dgvReportes);
            this.Name = "ReportesForm";
            this.Text = "ReportesForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvReportes;
        private ComboBox cbEstado;
        private Button btnCambiarEstado;
        private Button btnActualizar;
        private Button ReportelogLinks;
        private Button logLinkSession;
        private Button btnCrearRoles;
        private Button btnGestionarUsuarios;
    }
}