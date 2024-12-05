using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfraGuard_BO.Funciones
{
    internal class UserRegistration
    {
        private static readonly string SupabaseUrl = "https://onneeshuosforolbksrv.supabase.co";
        private static readonly string SupabaseApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im9ubmVlc2h1b3Nmb3JvbGJrc3J2Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3MjU5MzE3NTYsImV4cCI6MjA0MTUwNzc1Nn0.rEPlct9wdl-91k5zX6X6gmUDqFPV9yqVzI6pC2xh8GQ";

        public static async Task<bool> RegisterUserAsync(string username, string password, string useridcard, int nationalityid, int rolid, int barrioid, string usermail)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("apikey", SupabaseApiKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {SupabaseApiKey}");

            try
            {
                // Generar la fecha de creación del usuario
                string usercreationdate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");

                // Cifrar la contraseña antes de enviarla
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                // Crear el cuerpo del usuario para la solicitud
                var newUser = new
                {
                    username = username,
                    userpassword = hashedPassword,
                    useridcard = useridcard,
                    nationalityid = nationalityid,
                    usercreationdate = usercreationdate,
                    rolid = rolid,
                    barrioid = barrioid,
                    userstate = true, // Usuario habilitado por defecto
                    usermail = usermail
                };

                var jsonContent = JsonSerializer.Serialize(newUser);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Realizar la solicitud POST a la tabla `usuario`
                var response = await httpClient.PostAsync($"{SupabaseUrl}/rest/v1/usuario", content);

                if (response.IsSuccessStatusCode)
                {
                    // Registrar log de éxito
                    await RegisterLogAsync(username, "[BackOffice] Registro de usuario exitoso.");
                    Console.WriteLine("Usuario registrado exitosamente.");
                    return true;
                }
                else
                {
                    // Registrar log de fallo
                    var errorContent = await response.Content.ReadAsStringAsync();
                    await RegisterLogAsync(username, $"[BackOffice] Error al registrar usuario. Detalle: {errorContent}");
                    Console.WriteLine($"Error al registrar el usuario: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar el usuario: {ex.Message}");
                await RegisterLogAsync(username, $"[BackOffice] Excepción al registrar usuario. Detalle: {ex.Message}");
                throw;
            }
        }

        private static async Task RegisterLogAsync(string username, string message)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("apikey", SupabaseApiKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {SupabaseApiKey}");

            try
            {
                // Construir el cuerpo del log
                var logEntry = new
                {
                    username = username,
                    message = message,
                    timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")
                };

                var jsonContent = JsonSerializer.Serialize(logEntry);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Realizar la solicitud POST a la tabla `sessionlogs`
                var response = await httpClient.PostAsync($"{SupabaseUrl}/rest/v1/sessionlogs", content);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error al registrar el log: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar el log: {ex.Message}");
            }
        }
    }
}
