using System.Net.Http.Headers;
using System;
using LibGit2Sharp;
using System.Reflection;
using System.IO.Compression;
using System.Net;
using Microsoft.VisualBasic.ApplicationServices;
using System.Security.Cryptography;
using System.Reflection.Metadata;
using Microsoft.Win32;

namespace DiaSync
{
    public partial class Form1 : Form
    {
        string directoryName;
        // Create the full path for the directory
        string directoryPath;
        string extractPath;
        string extractedPath;
        string diatarDir;
        string dtxDir;
        public Form1()
        {
            InitializeComponent();
            directoryName = "~DiaSync";
            // Create the full path for the directory

            RegistryKey Diatar = Registry.CurrentUser;
            Diatar = Diatar.OpenSubKey("Software\\Diatar");

            if (Diatar != null)
            {
                dtxDir = Diatar.GetValue("DtxDir").ToString();
                diatarDir = Diatar.GetValue("DiaDir").ToString();
                directoryPath = Path.Combine(dtxDir, directoryName);
                extractPath = Path.Combine(directoryPath, "extract");
                extractedPath = Path.Combine(extractPath, "diatar-dtxs-main");

            }
            else
            {
                MessageBox.Show("Nem található a Diatár telepítés");
            }

        }

        private void btFetch_ClickAsync(object sender, EventArgs e)
        {
            StatusBar statusBar = new StatusBar();
            statusBar.SetMaximum(4);
            statusBar.SetStauts("Frissítés Elõkészítése");
            statusBar.SetValue(0);
            statusBar.Show();

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
            statusBar.SetStauts("Fájlok letöltése");
            statusBar.SetValue(1);
            string repoUrl = "https://github.com/diatar/diatar-dtxs/archive/refs/heads/main.zip"; ;
            string filePath = Path.Combine(directoryPath, "main.zip");
            using (var client = new WebClient())
            {
                client.DownloadFile(repoUrl, filePath);
            }
            statusBar.SetStauts("Fájlok kicsomagolása");
            statusBar.SetValue(2);

            // Kicsomagolás
            ZipFile.ExtractToDirectory(filePath, extractPath);

            string[] newlist = Directory.GetFiles(extractedPath, "*.dtx", SearchOption.AllDirectories).Select(Path.GetFileName).ToArray();
            string[] oldlist = Directory.GetFiles(dtxDir, "*.dtx", SearchOption.AllDirectories).Select(Path.GetFileName).ToArray();
            string[] check = newlist.Intersect(oldlist).ToArray();
            string[] newl = newlist.Except(oldlist).ToArray();

            statusBar.SetStauts("Frissítendõ tartalmak szûrése");
            statusBar.SetValue(3);
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
            statusBar.SetStauts("Lista kész");
            statusBar.SetValue(4);
            statusBar.Close();
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

            Directory.Delete(directoryPath, true);
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Directory.Delete(directoryPath, true);
        }
    }
}