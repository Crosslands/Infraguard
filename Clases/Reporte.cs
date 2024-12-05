using System;

namespace InfraGuard_BO.Models
{
    public class Reporte
    {
        public int ReporteId { get; set; } // Identificador único del reporte
        public DateTime ReportDate { get; set; } // Fecha del reporte
        public string ReportPicture { get; set; } // URL o ruta de la imagen del reporte
        public string ReportDescription { get; set; } // Descripción del reporte
        public string ReportLocation { get; set; } // Ubicación del reporte
        public int ReportTypeId { get; set; } // Identificador del tipo de reporte
        public string ReportResponsable { get; set; } // Responsable asignado al reporte
        public int UserId { get; set; } // Identificador del usuario que creó el reporte
        public int ReportChannelId { get; set; } // Canal por el que se reportó
        public string StatusInfo { get; set; } // Información sobre el estado del reporte

        // Constructor vacío para inicialización básica
        public Reporte()
        {
        }

        // Constructor con parámetros para inicialización completa
        public Reporte(int reporteId, DateTime reportDate, string reportPicture, string reportDescription,
                       string reportLocation, int reportTypeId, string reportResponsable, int userId,
                       int reportChannelId, string statusInfo)
        {
            ReporteId = reporteId;
            ReportDate = reportDate;
            ReportPicture = reportPicture;
            ReportDescription = reportDescription;
            ReportLocation = reportLocation;
            ReportTypeId = reportTypeId;
            ReportResponsable = reportResponsable;
            UserId = userId;
            ReportChannelId = reportChannelId;
            StatusInfo = statusInfo;
        }

        // Método para representar el reporte como cadena (opcional)
        public override string ToString()
        {
            return $"ReporteID: {ReporteId}, Fecha: {ReportDate}, Descripción: {ReportDescription}, " +
                   $"Ubicación: {ReportLocation}, Tipo: {ReportTypeId}, Responsable: {ReportResponsable}, " +
                   $"UsuarioID: {UserId}, Canal: {ReportChannelId}, Estado: {StatusInfo}";
        }
    }
}
