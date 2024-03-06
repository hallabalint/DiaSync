using System.Net.Http.Headers;
using System;
using LibGit2Sharp;
using System.Reflection;
using System.IO.Compression;
using System.Net;
using Microsoft.VisualBasic.ApplicationServices;
using System.Security.Cryptography;
using System.Reflection.Metadata;

namespace DiaSync
{
    public partial class Form1 : Form
    {
        string directoryName;
        // Create the full path for the directory
        string directoryPath;
        string extractPath;
        string extractedPath;
        string dtxDir;
        public Form1()
        {
            InitializeComponent();
             directoryName = "DiaSync";
            // Create the full path for the directory
             directoryPath = Path.Combine(@"C:\Users\Public\Documents\Diatar", directoryName);
             extractPath = Path.Combine(directoryPath, "extract");
             extractedPath = Path.Combine(extractPath, "diatar-dtxs-main");
             dtxDir = "C:\\Users\\Public\\Documents\\Diatar\\DTXs";
            
        }

        private void btFetch_ClickAsync(object sender, EventArgs e)
        {
            btFetch.Enabled = false;
            try
            {
                if (Directory.Exists(directoryPath))
                {

                    Directory.Delete(directoryPath, true);
                }
                Directory.CreateDirectory(directoryPath);

                Directory.CreateDirectory(extractPath);
            }
            catch (Exception ex)
            {
                btFetch.Enabled = true;
            }

            string repoUrl = "https://github.com/diatar/diatar-dtxs/archive/refs/heads/main.zip"; ;
            string filePath = Path.Combine(directoryPath, "main.zip");
            using (var client = new WebClient())
            {
                client.DownloadFile(repoUrl, filePath);
            }

            // Kicsomagolás
            ZipFile.ExtractToDirectory(filePath, extractPath);
            
            string[] newlist = Directory.GetFiles(extractedPath, "*.dtx", SearchOption.AllDirectories).Select(Path.GetFileName).ToArray();
            string[] oldlist = Directory.GetFiles(dtxDir, "*.dtx", SearchOption.AllDirectories).Select(Path.GetFileName).ToArray();
            string[] check = newlist.Intersect(oldlist).ToArray();
            string[] newl = newlist.Except(oldlist).ToArray();

            checkedListBox1.Items.Clear();
            foreach (var item in check)
            {
                //make item only contain filename
                string filename = Path.GetFileName(item);

                if (CalculateMD5(Path.Combine(dtxDir, filename)) != CalculateMD5(Path.Combine(extractedPath, filename)))
                {
                    checkedListBox1.Items.Add(filename);
                }
            }
            foreach (var item in newl)
            {
                checkedListBox1.Items.Add(item, true);
            }
            btFetch.Enabled = true;
        }

        static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            foreach (var checkedItem in checkedListBox1.CheckedItems)
            {
                File.Copy(Path.Combine(extractedPath, checkedItem.ToString()), Path.Combine(dtxDir, checkedItem.ToString()), true);
            }
            checkedListBox1.Items.Clear();
            MessageBox.Show("Frissítés kész!");
        }
    }
}