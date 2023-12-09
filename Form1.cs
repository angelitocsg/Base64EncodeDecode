using System;
using System.Text;
using System.Windows.Forms;

namespace Base64EncodeDecode
{
    public partial class Form1 : Form
    {
        public enum Action
        {
            Encode,
            Decode
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            Action action = rdEncode.Checked ? Action.Encode : Action.Decode;

            switch (action)
            {
                case Action.Encode:
                    txtOutput.Text = EncodeToBase64(txtInput.Text);
                    break;

                case Action.Decode:
                    txtOutput.Text = DecodeFrom64(txtInput.Text);
                    break;
            }
        }

        private string EncodeToBase64(string text)
        {
            try
            {
                byte[] textAsBytes = Encoding.ASCII.GetBytes(text);
                return Convert.ToBase64String(textAsBytes);
            }
            catch
            {
                return string.Empty;
            }
        }

        private string DecodeFrom64(string data)
        {
            try
            {
                byte[] dataAsBytes = Convert.FromBase64String(data);
                return Encoding.ASCII.GetString(dataAsBytes);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
