using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfraGuard_BO
{
    public partial class ReportesForm : Form
    {
        private static readonly string SupabaseUrl = "https://onneeshuosforolbksrv.supabase.co";
        private static readonly string SupabaseApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im9ubmVlc2h1b3Nmb3JvbGJrc3J2Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3MjU5MzE3NTYsImV4cCI6MjA0MTUwNzc1Nn0.rEPlct9wdl-91k5zX6X6gmUDqFPV9yqVzI6pC2xh8GQ";

        public ReportesForm()
        {
            InitializeComponent();
        }

        private async void ReportesForm_Load(object sender, EventArgs e)
        {
            await LoadReportesAsync();
        }
        private async void btnActualizar_Click_1(object sender, EventArgs e)
        {
            // Inicializar el ComboBox con los estados deseados
            LoadEstados();

            // Cargar los reportes
            await LoadReportesAsync();
        }

        // Método para inicializar los estados en el ComboBox
        private void LoadEstados()
        {
            cbEstado.Items.Clear(); // Limpiar cualquier valor anterior
            cbEstado.Items.Add("Enviado");
            cbEstado.Items.Add("Evaluacion");
            cbEstado.Items.Add("En reparacion");
            cbEstado.Items.Add("Default");

            cbEstado.SelectedIndex = 0; // Seleccionar el primer estado por defecto
        }

        // Cargar todos los reportes en el DataGridView
        private async Task LoadReportesAsync()
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("apikey", SupabaseApiKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {SupabaseApiKey}");

            try
            {
                var response = await httpClient.GetAsync($"{SupabaseUrl}/rest/v1/reportes");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    // Deserializar el JSON en una lista de diccionarios (clave-valor)
                    var reportes = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json);

                    if (reportes != null)
                    {
                        // Convertir la lista de diccionarios a un DataTable
                        var dataTable = ConvertToDataTable(reportes);

                        // Asignar el DataTable al DataGridView
                        dgvReportes.DataSource = dataTable;
                    }
                }
                else
                {
                    MessageBox.Show($"Error al cargar reportes: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar reportes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para convertir una lista de diccionarios en un DataTable
        private DataTable ConvertToDataTable(List<Dictionary<string, object>> list)
        {
            var dataTable = new DataTable();

            if (list.Count > 0)
            {
                // Crear columnas basadas en las claves del primer diccionario
                foreach (var key in list[0].Keys)
                {
                    dataTable.Columns.Add(key);
                }

                // Agregar filas
                foreach (var dict in list)
                {
                    var row = dataTable.NewRow();
                    foreach (var key in dict.Keys)
                    {
                        row[key] = dict[key]?.ToString() ?? string.Empty; // Convertir a string o asignar vacío
                    }
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }

        // Cambiar el estado del reporte seleccionado
        private async void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (dgvReportes.SelectedRows.Count > 0)
            {
                var selectedRow = dgvReportes.SelectedRows[0];
                int reporteId = Convert.ToInt32(selectedRow.Cells["ReporteId"].Value);
                string nuevoEstado = cbEstado.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(nuevoEstado))
                {
                    MessageBox.Show("Selecciona un estado válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("apikey", SupabaseApiKey);
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {SupabaseApiKey}");

                try
                {
                    var body = new { StatusInfo = nuevoEstado };
                    var jsonContent = JsonSerializer.Serialize(body);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    var response = await httpClient.PatchAsync($"{SupabaseUrl}/rest/v1/reportes?reporteid=eq.{reporteId}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Estado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadReportesAsync(); // Recargar la tabla
                    }
                    else
                    {
                        MessageBox.Show($"Error al actualizar estado: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar estado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecciona un reporte para cambiar su estado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ReportelogLinks_Click(object sender, EventArgs e)
        {
            // Instanciar el formulario
            var reportesLogsForm = new ReportesLogs();

            // Mostrar el formulario
            reportesLogsForm.Show();
        }

        private void logLinkSession_Click(object sender, EventArgs e)
        {
            // Instanciar el formulario
            var sessionLogsForm = new SessionLogsForm();

            // Mostrar el formulario
            sessionLogsForm.Show();
        }

        private void btnCrearRoles_Click(object sender, EventArgs e)
        {
            // Instanciar el formulario de roles
            var rolesForm = new RolesForm();

            // Mostrar el formulario
            rolesForm.Show();
        }

        private void btnGestionarUsuarios_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario UsuariosForm
            UsuariosForm usuariosForm = new UsuariosForm();

            // Mostrar el formulario como ventana modal
            usuariosForm.ShowDialog();
        }
    }

    // Clase para representar un reporte
    public class Reporte
    {
        public int ReporteId { get; set; }
        public DateTime ReportDate { get; set; }
        public List<string> ReportPicture { get; set; } // Cambiado a List<string>
        public string ReportDescription { get; set; }
        public List<string> ReportLocation { get; set; } // Cambiado a List<string>
        public int ReportTypeId { get; set; }
        public string ReportResponsable { get; set; }
        public int UserId { get; set; }
        public int ReportChannelId { get; set; }
        public string StatusInfo { get; set; }
    }
}
