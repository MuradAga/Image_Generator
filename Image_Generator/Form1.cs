using OpenAI.GPT3.Managers;
using OpenAI.GPT3;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;

namespace Image_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = "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"
            });

            var imageResult = await openAiService.Image.CreateImage(new ImageCreateRequest
            {
                Prompt = textBox1.Text,
                N = 6,
                Size = StaticValues.ImageStatics.Size.Size256,
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Base64,
                User = "TestUser"
            });

            pictureBox1.Image = Base64ToImage(imageResult.Results[0].B64);
            pictureBox2.Image = Base64ToImage(imageResult.Results[1].B64);
            pictureBox3.Image = Base64ToImage(imageResult.Results[2].B64);
            pictureBox4.Image = Base64ToImage(imageResult.Results[3].B64);
            pictureBox5.Image = Base64ToImage(imageResult.Results[4].B64);
            pictureBox6.Image = Base64ToImage(imageResult.Results[5].B64);
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
    }
}