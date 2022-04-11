using Converter;
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
            string method = methodTxtBox.Text;
            string response = "";
            switch (method)
            {
                case "GET":
                    response = client.MakeRequest(endpoint,httpVerb.GET);
                    break;
                case "POST":
                    response = client.MakeRequest(endpoint,httpVerb.POST);
                    break;
                case "PUT":
                    response = client.MakeRequest(endpoint,httpVerb.PUT);
                    break;
                case "DELETE":
                    response = client.MakeRequest(endpoint,httpVerb.DELETE);
                    break;
            }

            restOutput.Text = response;
        }

        private async void ConverterSubmitBtn_Click(object sender, EventArgs e)
        {
            this.converterOutput.Text = "Querying the web service...";
            float celsius = float.Parse(this.celsiusTxtBox.Text);
            float farenheit = float.Parse(this.farenheitTxtBox.Text);
            ConverterPortTypeClient soap = new ConverterPortTypeClient(ConverterPortTypeClient.EndpointConfiguration.ConverterHttpSoap11Endpoint);
            float result = await soap.celsiusToFarenheitAsync(celsius);
            this.converterOutput.Text += "\nResultado Conversão Celsius to Farenheit: " + result.ToString();
            result = await soap.farenheitToCelsiusAsync(farenheit);
            this.converterOutput.Text += "\nResultado Conversão Farenheit to Celsius: " + result.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
