using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using GessiWebApp.API.DTOs;  // Verifica che questo namespace esista e sia corretto

namespace GessiWebApp.Web.Services
{
    public class ReportService
    {
        public byte[] GenerateMissionReport(MissionDto mission)
        {
            using (var ms = new MemoryStream())
            {
                using (var pdfWriter = new PdfWriter(ms))
                using (var pdf = new PdfDocument(pdfWriter))
                using (var document = new Document(pdf))
                {
                    document.Add(new Paragraph($"Missione: {mission.Id}")
                        .SetFontSize(16)
                        .SetBold()
                        .SetTextAlignment(TextAlignment.CENTER));

                    document.Add(new Paragraph($"Tipo di destinazione: {mission.DestinationType}")
                        .SetFontSize(12));

                    document.Add(new Paragraph($"Descrizione: {mission.Description}")
                        .SetFontSize(12));

                    // Aggiungi una tabella per i materiali della missione
                    if (mission.Items != null && mission.Items.Count > 0)
                    {
                        var table = new Table(3).UseAllAvailableWidth();
                        table.AddHeaderCell("Codice Materiale");
                        table.AddHeaderCell("Descrizione");
                        table.AddHeaderCell("Quantità");

                        foreach (var item in mission.Items)
                        {
                            if (item != null)
                            {
                                table.AddCell(item.MaterialCode ?? "");
                                table.AddCell(item.MaterialDescription?? "");
                                table.AddCell(item.Quantity.ToString());
                            }
                        }

                        document.Add(new Paragraph("Materiali prelevati:").SetFontSize(14).SetBold());
                        document.Add(table);
                    }

                    document.Add(new Paragraph($"Data generazione report: {DateTime.Now}")
                        .SetFontSize(10)
                        .SetTextAlignment(TextAlignment.RIGHT));
                }

                return ms.ToArray();
            }
        }
    }
}
