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
    public partial class RolesForm : Form
    {
        private static readonly string SupabaseUrl = "https://onneeshuosforolbksrv.supabase.co";
        private static readonly string SupabaseApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im9ubmVlc2h1b3Nmb3JvbGJrc3J2Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3MjU5MzE3NTYsImV4cCI6MjA0MTUwNzc1Nn0.rEPlct9wdl-91k5zX6X6gmUDqFPV9yqVzI6pC2xh8GQ";

        public RolesForm()
        {
            InitializeComponent();
        }

        private async void RolesForm_Load(object sender, EventArgs e)
        {
            await LoadRolesAsync();
        }

        private async void btnActualizarRoles_Click(object sender, EventArgs e)
        {
            await LoadRolesAsync();
        }

        private async void btnAgregarRol_Click(object sender, EventArgs e)
        {
            string rolName = txtRolName.Text.Trim();

            if (string.IsNullOrEmpty(rolName))
            {
                MessageBox.Show("Por favor, ingresa un nombre para el rol.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("apikey", SupabaseApiKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {SupabaseApiKey}");

            try
            {
                // Construir el objeto para enviar (sin el campo id)
                var body = new { rol = rolName };
                var jsonContent = JsonSerializer.Serialize(body);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Realizar el POST al endpoint de Supabase
                var response = await httpClient.PostAsync($"{SupabaseUrl}/rest/v1/rol", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Rol agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRolName.Clear();
                    await LoadRolesAsync(); // Actualizar la lista de roles
                }
                else
                {
                    // Mostrar un mensaje de error si algo falla
                    var errorDetails = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al agregar el rol: {response.StatusCode}\nDetalles: {errorDetails}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el rol: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadRolesAsync()
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("apikey", SupabaseApiKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {SupabaseApiKey}");

            try
            {
                var response = await httpClient.GetAsync($"{SupabaseUrl}/rest/v1/rol");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var roles = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json);

                    if (roles != null)
                    {
                        var dataTable = ConvertToDataTable(roles);
                        dgvRoles.DataSource = dataTable;
                    }
                }
                else
                {
                    MessageBox.Show($"Error al cargar roles: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ConvertToDataTable(List<Dictionary<string, object>> list)
        {
            var dataTable = new DataTable();

            if (list.Count > 0)
            {
                foreach (var key in list[0].Keys)
                {
                    dataTable.Columns.Add(key);
                }

                foreach (var dict in list)
                {
                    var row = dataTable.NewRow();
                    foreach (var key in dict.Keys)
                    {
                        row[key] = dict[key]?.ToString() ?? string.Empty;
                    }
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }
    }
}
