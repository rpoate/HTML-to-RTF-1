using System;
using System.Windows.Forms;

namespace HTML_to_RTF_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Rtf = ClipConvert.ConvertHtmlToRtf(this.htmlEditControl1.DocumentHTML);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ClipConvert.ConvertRtfToHtml(this.richTextBox1.Rtf, ref this.htmlEditControl1);
        }
    }
    public static class ClipConvert
    {
        public static string ConvertHtmlToRtf(string html)
        {
            var webBrowser = new WebBrowser { DocumentText = html };
            while (webBrowser.DocumentText != html)
                Application.DoEvents();

            if (webBrowser.Document == null)
                return null;

            webBrowser.Document.ExecCommand("SelectAll", false, null);
            webBrowser.Document.ExecCommand("Copy", false, null);

            var richTextbox = new RichTextBox();
            richTextbox.Paste();

            return richTextbox.Rtf;
        }
        public static void ConvertRtfToHtml(string rtf, ref Zoople.HTMLEditControl Editor)
        {
            var rtfbox = new RichTextBox { Rtf = rtf };
            rtfbox.SelectAll();
            rtfbox.Copy();

            Editor.SelectAll_Document();
            Editor.Document.ExecCommand("paste", false, null);

            return;
        }
    }
}


