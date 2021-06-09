using System;
using System.IO;
using System.Windows;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Lab18
{
    public partial class MainWindow : Window
    {
        private const string FolderName = "Folder_";

        private const int MaxFolder = 100;
        
        private const string Path = @"C:\Users\Fiede\";
        
        public MainWindow()
        {
            InitializeComponent();
        }


        private void CreateFolders_OnClick(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(Path);
            
            for (int i = 0; i < MaxFolder; i++)
            {
                directoryInfo.CreateSubdirectory(FolderName + i);
            }
        }

        private void RemoveFolders_OnClick(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Path))
            {
                Directory.Delete(Path, true);
            }
        }

        private void CreateSubFolders_OnClick(object sender, RoutedEventArgs e)
        {
            ShowMaxNumberSubFolder();
        }
        
        private void ShowMaxNumberSubFolder()
        {
            string path = "D:";
            int count = 0;

            try
            {
                while (true)
                {
                    path += @"\" + 'a';
                    if (count == 50)
                    {
                        if (MessageBox.Show("Программа уже создала 500 вложеных папок. Вы хотите продолжить?",
                            "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.No)
                        {
                            break;
                        }
                    } 
                    count++;
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Максимальное количество папок " + count);
            }

            Directory.Delete(@"D:\a",true);
        }

        private void CheckMaxFolderName_Onlick(object sender, RoutedEventArgs e)
        {
            string name = "1";
            int count = 0;
            try
            {
                while (true)
                {
                    Directory.CreateDirectory(Path+name);
                    count++;
                    Directory.Delete(Path+name);
                    name += "1";
                    
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Максимальная длина названия папки: " + (count-1));
            }
        }


        private void FindFileButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(FileNameTextBox.Text) && !string.IsNullOrEmpty(FilePathTextBox.Text))
            {
                foreach (string FindedFile in FindAllFiles(FilePathTextBox.Text, FileNameTextBox.Text))
                {
                    try
                    {
                        using (StreamReader streamReader = new StreamReader(FindedFile))
                        {
                                FileOuputText.Text = streamReader.ReadToEnd();
                                break;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось открыть файл");
                    }
                }
            }
        }
        
        private static IEnumerable<string> FindAllFiles(string path, string pattern)
        { 
            IEnumerable<string> files = null;
            try
            {
                files = Directory.EnumerateFiles(path, pattern);
            }
            catch
            {
               
            }

            if (files != null)
            {
                foreach (var file in files) yield return file;
            }

            IEnumerable<string> directories = null;
            try
            {
                directories = Directory.EnumerateDirectories(path);
            }
            catch
            {
                
            }

            if (directories != null)
            {
                foreach (var file in directories.SelectMany(d => FindAllFiles(d, pattern)))
                {
                    yield return file;
                }
            }
        }

        private void ClearAllFieldsButton_OnClick(object sender, RoutedEventArgs e)
        {
            FileNameTextBox.Text = String.Empty;
            FilePathTextBox.Text = String.Empty;
            FileOuputText.Text = String.Empty;
        }
    }
}