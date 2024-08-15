using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GessiWebApp.Web.Services
{
    public class ComputerVisionService
    {
        private readonly ComputerVisionClient _client;

        public ComputerVisionService(string endpoint, string key)
        {
            _client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
            {
                Endpoint = endpoint
            };
        }

        public async Task<string> AnalyzeImageAsync(Stream imageStream)
        {
            var features = new List<VisualFeatureTypes?>()
            {
                VisualFeatureTypes.Objects,
                VisualFeatureTypes.Tags
            };

            try
            {
                var results = await _client.AnalyzeImageInStreamAsync(imageStream, visualFeatures: features);

                // Implementa la logica per interpretare i risultati e identificare il materiale
                // Questo è solo un esempio di base
                var topTag = results.Tags.OrderByDescending(t => t.Confidence).FirstOrDefault();
                return topTag != null ? $"{topTag.Name} (Confidenza: {topTag.Confidence:P2})" : "Materiale non identificato";
            }
            catch (Exception ex)
            {
                // Gestione degli errori
                Console.WriteLine($"Errore nell'analisi dell'immagine: {ex.Message}");
                return "Errore nell'analisi dell'immagine";
            }
        }
    }
}