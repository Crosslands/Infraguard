namespace InfraGuard_BO
{
    partial class SessionLogsForm
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
            this.dgvSessionLogs = new System.Windows.Forms.DataGridView();
            this.btnActualizarLogs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSessionLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSessionLogs
            // 
            this.dgvSessionLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSessionLogs.Location = new System.Drawing.Point(15, 58);
            this.dgvSessionLogs.Name = "dgvSessionLogs";
            this.dgvSessionLogs.RowTemplate.Height = 25;
            this.dgvSessionLogs.Size = new System.Drawing.Size(738, 374);
            this.dgvSessionLogs.TabIndex = 0;
            // 
            // btnActualizarLogs
            // 
            this.btnActualizarLogs.Location = new System.Drawing.Point(605, 19);
            this.btnActualizarLogs.Name = "btnActualizarLogs";
            this.btnActualizarLogs.Size = new System.Drawing.Size(138, 31);
            this.btnActualizarLogs.TabIndex = 1;
            this.btnActualizarLogs.Text = "Actualizar";
            this.btnActualizarLogs.UseVisualStyleBackColor = true;
            this.btnActualizarLogs.Click += new System.EventHandler(this.btnActualizarLogs_Click);
            // 
            // SessionLogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnActualizarLogs);
            this.Controls.Add(this.dgvSessionLogs);
            this.Name = "SessionLogsForm";
            this.Text = "Logs Sesiones";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSessionLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvSessionLogs;
        private Button btnActualizarLogs;
    }
}