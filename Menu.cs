using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrCodeGenerator
{
    internal class Menu
    {
        // Objekt för att hålla inställningar om du vill utöka
        public string LastInput { get; set; } = "";

        // Metod som visar välkomstmenyn
        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Welcome to QR-kod Generator ===");
                Console.WriteLine("1. Create QR-code");
                Console.WriteLine("2. Exit");
               
                

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateQRCode();
                        break;
                    case "2":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void CreateQRCode()
        {
            Console.Write("Enter text or Link: ");
            string input = Console.ReadLine();
            

            Console.Write("Enter a file name for the QR-Code? ");
            string fileNameInput = Console.ReadLine();
            string fileName = fileNameInput + ".png";

            // Hämta absolut sökväg
            string fullPath = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                    {
                        qrCodeImage.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
                        Console.WriteLine($"You can find your QR-Code in: {fullPath}");
                    }
                }
            }

            Console.WriteLine("Enter any key to go back to the menu...");
            Console.ReadKey();
        }

    }
}

