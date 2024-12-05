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
    public partial class UsuariosForm : Form
    {
        private static readonly string SupabaseUrl = "https://onneeshuosforolbksrv.supabase.co";
        private static readonly string SupabaseApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im9ubmVlc2h1b3Nmb3JvbGJrc3J2Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3MjU5MzE3NTYsImV4cCI6MjA0MTUwNzc1Nn0.rEPlct9wdl-91k5zX6X6gmUDqFPV9yqVzI6pC2xh8GQ";

        public UsuariosForm()
        {
            InitializeComponent();
        }

        private async void UsuariosForm_Load(object sender, EventArgs e)
        {
            await LoadUsuariosAsync();
            await LoadRolesAsync();
            await LoadEstadosAsync();
        }

        private async Task LoadUsuariosAsync()
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("apikey", SupabaseApiKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {SupabaseApiKey}");

            try
            {
                var response = await httpClient.GetAsync($"{SupabaseUrl}/rest/v1/usuario");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var usuarios = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json);

                    if (usuarios != null)
                    {
                        var dataTable = ConvertToDataTable(usuarios);
                        dgvUsuarios.DataSource = dataTable;
                    }
                }
                else
                {
                    MessageBox.Show($"Error al cargar usuarios: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        cmbRoles.Items.Clear();
                        foreach (var role in roles)
                        {
                            cmbRoles.Items.Add($"{role["id"]} - {role["rol"]}");
                        }
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

        private async Task LoadEstadosAsync()
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("apikey", SupabaseApiKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {SupabaseApiKey}");

            try
            {
                var response = await httpClient.GetAsync($"{SupabaseUrl}/rest/v1/estado_usuario");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var estados = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json);

                    if (estados != null)
                    {
                        cmbEstados.Items.Clear();
                        foreach (var estado in estados)
                        {
                            cmbEstados.Items.Add($"{estado["id"]} - {estado["nombre"]}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Error al cargar estados: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                btnActualizar.Enabled = false; // Deshabilitar el botón mientras se actualizan los datos

                // Cargar datos en el DataGridView
                await LoadUsuariosAsync();

                // Cargar roles en el ComboBox
                await LoadRolesAsync();

                // Cargar estados en el ComboBox
                await LoadEstadosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnActualizar.Enabled = true; // Habilitar el botón nuevamente
            }
        }


        private async void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var selectedRow = dgvUsuarios.SelectedRows[0];

                string userIdString = selectedRow.Cells["userid"].Value?.ToString();
                if (string.IsNullOrEmpty(userIdString))
                {
                    MessageBox.Show("El ID de usuario no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int userId = int.Parse(userIdString);

                if (cmbEstados.SelectedItem == null || cmbRoles.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un estado y un rol.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string estadoSeleccionado = cmbEstados.SelectedItem.ToString();
                string rolSeleccionado = cmbRoles.SelectedItem.ToString();

                Console.WriteLine($"Estado seleccionado: {estadoSeleccionado}");
                Console.WriteLine($"Rol seleccionado: {rolSeleccionado}");

                int newState = int.Parse(estadoSeleccionado.Split('-')[0].Trim());
                int newRole = int.Parse(rolSeleccionado.Split('-')[0].Trim());

                Console.WriteLine($"Actualizando usuario con ID: {userId}, Estado: {newState}, Rol: {newRole}");

                await UpdateUsuarioAsync(userId, newState, newRole);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private async Task UpdateUsuarioAsync(int userId, int userState, int roleId)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("apikey", SupabaseApiKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {SupabaseApiKey}");

            try
            {
                var body = new { userstate = userState, rolid = roleId };
                var jsonContent = JsonSerializer.Serialize(body);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Cambiar 'id' por 'userid' en la URL
                var response = await httpClient.PatchAsync($"{SupabaseUrl}/rest/v1/usuario?userid=eq.{userId}", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUsuariosAsync();
                }
                else
                {
                    var errorDetails = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al actualizar usuario: {response.StatusCode}\nDetalles: {errorDetails}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var selectedRow = dgvUsuarios.SelectedRows[0];
                string username = selectedRow.Cells["username"].Value?.ToString() ?? "Ninguno";
                lblUsuarioSeleccionado.Text = $"Usuario seleccionado: {username}";

                // Mostrar el estado actual
                if (selectedRow.Cells["userstate"].Value != null)
                {
                    string currentState = selectedRow.Cells["userstate"].Value.ToString();
                    cmbEstados.SelectedItem = cmbEstados.Items.Cast<string>().FirstOrDefault(item => item.StartsWith(currentState));
                }

                // Mostrar el rol actual
                if (selectedRow.Cells["rolid"].Value != null)
                {
                    string currentRole = selectedRow.Cells["rolid"].Value.ToString();
                    cmbRoles.SelectedItem = cmbRoles.Items.Cast<string>().FirstOrDefault(item => item.StartsWith(currentRole));
                }
            }
            else
            {
                lblUsuarioSeleccionado.Text = "No hay usuario seleccionado";
                cmbEstados.SelectedItem = null;
                cmbRoles.SelectedItem = null;
            }
        }


        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
