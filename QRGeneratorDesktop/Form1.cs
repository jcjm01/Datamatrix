using Newtonsoft.Json;
using QRGeneratorDesktop.Models;
using QRGeneratorDesktop.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZXing.Common;
using ZXing.Windows.Compatibility;
using ZXing;

namespace QRGeneratorDesktop
{
    public partial class Form1 : Form
    {
        private readonly NameplateService _nameplateService;

        public Form1()
        {
            InitializeComponent();
            _nameplateService = new NameplateService();
            this.Load += new EventHandler(Form1_Load); // Asegúrate de que el evento Load esté asignado aquí
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                List<Nameplate> nameplates = await _nameplateService.GetNameplateAsync();
                if (nameplates.Count > 0)
                {
                    var nameplate = nameplates[0]; // Tomar el primer nameplate para mostrar
                    MessageBox.Show(JsonConvert.SerializeObject(nameplate)); // Añade esto para ver los datos recuperados
                    DisplayNameplate(nameplate);
                }
                else
                {
                    MessageBox.Show("No nameplates available.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching nameplates: {ex.Message}");
            }
        }

        private void DisplayNameplate(Nameplate nameplate)
        {
            // Serializar el objeto Nameplate a JSON
            var dataMatrixContent = JsonConvert.SerializeObject(nameplate);

            var writer = new BarcodeWriter<Bitmap>
            {
                Format = BarcodeFormat.DATA_MATRIX,
                Options = new EncodingOptions
                {
                    Height = pictureBox1.Height,
                    Width = pictureBox1.Width,
                    Margin = 0
                },
                Renderer = new BitmapRenderer()
            };

            var dataMatrix = writer.Write(dataMatrixContent);
            pictureBox1.Image = dataMatrix;
            label1.Text = nameplate.SerialNumber;
            label2.Text = nameplate.CustomerPartNumber;
        }
    }
}
