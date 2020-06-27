using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingWithMaps.Modelo
{
    class EpayCoModelo
    {
        public bool success { get; set; }
        public string title_response { get; set; }
        public string text_response { get; set; }
        public string last_action { get; set; }
        public EpayCoModeloData data { get; set; }

    }
    class EpayCoModeloData
    {
        public string x_transaction_date { get; set; }
        public string x_response { get; set; }
        public string x_id_invoice { get; set; }
        public string x_response_reason_text { get; set; }
        public string x_transaction_id { get; set; }
        public string x_bank_name { get; set; }
        public string x_approval_code { get; set; }
        public string x_amount { get; set; }
        public string x_currency_code { get; set; }
    }
}
