using ServiceReference2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trabalho1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            this.output.Text = "Querying the web service...";
            int a = int.Parse(this.shortDescription.Text);
            int b = int.Parse(this.handle.Text);
            CalculatorSoapClient soap = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap);
            int result = await soap.AddAsync(a, b);
            this.output.Text += "\nResultado soma: " + result.ToString();
            result = await soap.DivideAsync(a, b);
            this.output.Text += "\nResultado divisão: " + result.ToString();
            result = await soap.MultiplyAsync(a, b);
            this.output.Text += "\nResultado multiplicação: " + result.ToString();
            result = await soap.SubtractAsync(a, b);
            this.output.Text += "\nResultado subtração: " + result.ToString();

        }

        private void queryBtn_Click(object sender, EventArgs e)
        {
            //https://zoo-animal-api.herokuapp.com/animals/rand
            restOutput.Text = "Querying the REST API...";
            RestClient client = new RestClient();
            string endpoint = zoaQuery.Text;
            string response = client.MakeRequest(endpoint);
            restOutput.Text = response;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
