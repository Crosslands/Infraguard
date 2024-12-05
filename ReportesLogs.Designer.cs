namespace InfraGuard_BO
{
    partial class ReportesLogs
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
            this.dgvReportesLogs = new System.Windows.Forms.DataGridView();
            this.btnActualizarLogs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportesLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReportesLogs
            // 
            this.dgvReportesLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportesLogs.Location = new System.Drawing.Point(27, 65);
            this.dgvReportesLogs.Name = "dgvReportesLogs";
            this.dgvReportesLogs.RowTemplate.Height = 25;
            this.dgvReportesLogs.Size = new System.Drawing.Size(717, 355);
            this.dgvReportesLogs.TabIndex = 0;
            // 
            // btnActualizarLogs
            // 
            this.btnActualizarLogs.Location = new System.Drawing.Point(612, 16);
            this.btnActualizarLogs.Name = "btnActualizarLogs";
            this.btnActualizarLogs.Size = new System.Drawing.Size(115, 43);
            this.btnActualizarLogs.TabIndex = 1;
            this.btnActualizarLogs.Text = "Actualizar";
            this.btnActualizarLogs.UseVisualStyleBackColor = true;
            this.btnActualizarLogs.Click += new System.EventHandler(this.btnActualizarLogs_Click);
            // 
            // ReportesLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnActualizarLogs);
            this.Controls.Add(this.dgvReportesLogs);
            this.Name = "ReportesLogs";
            this.Text = "ReportesLogs";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportesLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvReportesLogs;
        private Button btnActualizarLogs;
    }
}