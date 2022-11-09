using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace lab3_task1_nhom10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static String inputHash;
        public static byte[] arrayBytes;
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("File");
            comboBox1.Items.Add("Text string");
            comboBox1.Items.Add("Hex string");
            comboBox1.SelectedIndex = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {
                button1.Enabled = false;
                textBox1.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
                textBox1.Text = "";
                textBox1.Enabled = false;
            }
        }

        public static string CreateMD5(byte[] inputBytes)
        {
            // Use input string to calculate MD5 hash
            MD5 md5 = MD5.Create();
            {
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static byte[] FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return bytes;
        }

        public static string CreateSHA1(byte[] inputBytes)
        {
            // Use input string to calculate MD5 hash
            SHA1 sha1 = SHA1.Create();
            {
                byte[] hashBytes = sha1.ComputeHash(inputBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                return hash;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs);
                string content = sr.ReadToEnd();
                textBox1.Text = content;
                fs.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
