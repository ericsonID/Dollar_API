using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace CotacaoDolarHG
{
    public partial class Frmcotacaodolar : Form
    {
        public Frmcotacaodolar()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strURL = "https://api.hgbrasil.com/finance?array_limit=1&fields=only_results,USD&key=73d70bed";
            using(HttpClient client = new  HttpClient() )
            {
                try
                {
                    var response = client.GetAsync(strURL).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        Market market = JsonConvert.DeserializeObject<Market>(result);
                        lblBuy.Text = string.Format(CultureInfo.GetCultureInfo("pt-Br"), "{0:C}", market.Currency.Buy);
                        lblSell.Text = string.Format(CultureInfo.GetCultureInfo("pt-Br"), "{0:C}", market.Currency.Sell);
                        lblVariation.Text = string.Format(CultureInfo.GetCultureInfo("pt-Br"), "{0:P}", market.Currency.Variation / 100);
                    }
                    else
                    {
                        lblBuy.Text = "-";
                        lblSell.Text = "-";
                        lblVariation.Text = "-";

                    }
                }
                catch (Exception ex)
                {
                    lblBuy.Text = "-";
                    lblSell.Text = "-";
                    lblVariation.Text = "-";
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
