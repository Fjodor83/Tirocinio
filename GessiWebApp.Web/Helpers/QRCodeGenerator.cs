using DocumentFormat.OpenXml.Drawing;
using QRCoder;
using SixLabors.ImageSharp.Formats;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace GessiWebApp.Web.Helpers
{
    public static class QRCodeGenerator
    {
        public static byte[] GenerateQRCode(string content)
        {
            using (var qrGenerator = new QRCoder.QRCodeGenerator())
            {
                var qrCodeData = qrGenerator.CreateQrCode(content, QRCoder.QRCodeGenerator.ECCLevel.Q);
                using (var qrCode = new QRCoder.PngByteQRCode(qrCodeData))
                {
                    return qrCode.GetGraphic(10);
                }
            }
        }

        public static byte[] GenerateLabel(string code, string description, string imagePath, byte[] qrCode)
        {
            using (var bitmap = new Bitmap(400, 200))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);

                // Disegna l'immagine principale
                if (File.Exists(imagePath))
                {
                    using (var image = Image.FromFile(imagePath))
                    {
                        graphics.DrawImage(image, new System.Drawing.Rectangle(10, 10, 80, 80));
                    }
                }

                // Disegna il codice materiale
                graphics.DrawString(code, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new PointF(100, 10));

                // Disegna la descrizione materiale
                graphics.DrawString(description, new Font("Arial", 10), Brushes.Black, new RectangleF(100, 30, 200, 60));

                // Disegna il QR Code
                using (var qrCodeImage = Image.FromStream(new MemoryStream(qrCode)))
                {
                    graphics.DrawImage(qrCodeImage, new System.Drawing.Rectangle(310, 10, 80, 80));
                }

                using (var ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }

        public static byte[] GenerateMinimalLabel(byte[] qrCode)
        {
            using (var bitmap = new Bitmap(100, 100))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);

                // Disegna solo il QR Code
                using (var qrCodeImage = Image.FromStream(new MemoryStream(qrCode)))
                {
                    graphics.DrawImage(qrCodeImage, new System.Drawing.Rectangle(10, 10, 80, 80));
                }

                using (var ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }
    }
}