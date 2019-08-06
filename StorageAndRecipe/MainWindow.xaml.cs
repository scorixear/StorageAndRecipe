using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace StorageAndRecipe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Language> languages;
        public MainWindow()
        {
            languages = new List<Language>();
            string[] paths = Directory.GetFiles("Languages");
            foreach(string file in paths)
            {
                languages.Add(StorageAndRecipe.Language.Load(file));
            }
            InitializeComponent();
            LanguageMenuItem.Items.Clear();
            foreach (Language l in languages)
            {
                RadioButton rb = new RadioButton();
                rb.Content = l.LanguageName;
                LanguageMenuItem.Items.Add(rb);
            }
        }
    }
}
