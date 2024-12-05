using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BCrypt.Net; // Necesitas instalar el paquete BCrypt.Net-Next desde NuGet

namespace InfraGuard_BO.Funciones
{
    internal class LogIn
    {
        private static readonly string SupabaseUrl = "https://onneeshuosforolbksrv.supabase.co";
        private static readonly string SupabaseApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im9ubmVlc2h1b3Nmb3JvbGJrc3J2Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3MjU5MzE3NTYsImV4cCI6MjA0MTUwNzc1Nn0.rEPlct9wdl-91k5zX6X6gmUDqFPV9yqVzI6pC2xh8GQ";

        public static async Task<bool> AuthenticateUserAsync(string username, string password)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("apikey", SupabaseApiKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {SupabaseApiKey}");

            try
            {
                // Construir la URL para obtener los datos del usuario
                var url = $"{SupabaseUrl}/rest/v1/usuario?username=eq.{username}&select=userpassword,rolid";

                // Realizar la solicitud GET
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Deserializar la respuesta como un array de objetos
                    var users = JsonSerializer.Deserialize<JsonElement>(responseContent);

                    if (users.GetArrayLength() > 0)
                    {
                        // Extraer los datos del usuario
                        var user = users[0];
                        var hash = user.GetProperty("userpassword").GetString();
                        var rolid = user.GetProperty("rolid").GetInt32();

                        // Comparar la contraseña ingresada con el hash usando BCrypt
                        if (BCrypt.Net.BCrypt.Verify(password, hash))
                        {
                            if (rolid == 1)
                            {
                                // Registrar el log de sesión exitosa
                                await RegisterLogAsync(username, "[BackOffice] Inicio de sesión exitoso.");

                                Console.WriteLine("Inicio de sesión exitoso.");
                                return true;
                            }
                            else
                            {
                                // Registrar el log de intento fallido por permisos
                                await RegisterLogAsync(username, "[BackOffice] Usuario sin permisos para iniciar sesión.");
                                Console.WriteLine("No cuenta con los permisos para hacer esto.");
                                return false;
                            }
                        }
                        else
                        {
                            // Registrar el log de intento fallido por contraseña
                            await RegisterLogAsync(username, "[BackOffice] Contraseña incorrecta.");
                            Console.WriteLine("Credenciales incorrectas.");
                            return false;
                        }
                    }
                    else
                    {
                        // Registrar el log de intento fallido por usuario no encontrado
                        await RegisterLogAsync(username, "[BackOffice] Usuario no encontrado.");
                        Console.WriteLine("Usuario no encontrado.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine($"Error en la autenticación: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al autenticar al usuario: {ex.Message}");
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

    class Program
    {
        static async Task Main(string[] args)
        {
            // Prueba de autenticación
            bool isAuthenticated = await LogIn.AuthenticateUserAsync("admin", "123456");

            Console.WriteLine(isAuthenticated ? "Usuario autenticado." : "Fallo en la autenticación.");
        }
    }
}
