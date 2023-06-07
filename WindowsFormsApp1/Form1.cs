using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Resources;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ResourceManager resourceManager;
        public Form1()
        {
            InitializeComponent();

            resourceManager = new ResourceManager("WindowsFormsApp1.Resource", typeof(Form1).Assembly);

            this.BackgroundImageLayout = ImageLayout.Stretch;

            Image ukraineImage = Image.FromFile("ukraine.png");
            Image englandImage = Image.FromFile("england.png");
            Image deutschlandImage = Image.FromFile("germany.png");

            button1.BackgroundImage = ukraineImage;
            button2.BackgroundImage = englandImage;
            button3.BackgroundImage = deutschlandImage;

            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button3.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("uk-UA");
            UpdateUI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            UpdateUI();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
            UpdateUI();
        }

        private void UpdateUI()
        {
            string titleText = resourceManager.GetString("Name");
            string backgroundImagePath = resourceManager.GetString("ImageAdress");

            this.Text = titleText;

            if (!string.IsNullOrEmpty(backgroundImagePath))
            {
                try
                {
                    this.BackgroundImage = Image.FromFile(backgroundImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки фонового изображения: " + ex.Message);
                }
            }
        }
    }
}
