using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfraGuard_BO
{
    public partial class SessionLogsForm : Form
    {
        private static readonly string SupabaseUrl = "https://onneeshuosforolbksrv.supabase.co";
        private static readonly string SupabaseApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im9ubmVlc2h1b3Nmb3JvbGJrc3J2Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3MjU5MzE3NTYsImV4cCI6MjA0MTUwNzc1Nn0.rEPlct9wdl-91k5zX6X6gmUDqFPV9yqVzI6pC2xh8GQ";

        public SessionLogsForm()
        {
            InitializeComponent();
        }

        private async void SessionLogsForm_Load(object sender, EventArgs e)
        {
            await LoadSessionLogsAsync();
        }

        private async void btnActualizarLogs_Click(object sender, EventArgs e)
        {
            await LoadSessionLogsAsync();
        }

        // Método para cargar los datos de la tabla `sessionlogs`
        private async Task LoadSessionLogsAsync()
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("apikey", SupabaseApiKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {SupabaseApiKey}");

            try
            {
                var response = await httpClient.GetAsync($"{SupabaseUrl}/rest/v1/sessionlogs");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    // Deserializar los datos en una lista de diccionarios
                    var sessionLogs = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json);

                    if (sessionLogs != null)
                    {
                        // Convertir a DataTable para el DataGridView
                        var dataTable = ConvertToDataTable(sessionLogs);
                        dgvSessionLogs.DataSource = dataTable;
                    }
                }
                else
                {
                    MessageBox.Show($"Error al cargar session logs: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar session logs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para convertir una lista de diccionarios a un DataTable
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
                        row[key] = dict[key]?.ToString() ?? string.Empty; // Convertir a texto
                    }
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }
    }
}
