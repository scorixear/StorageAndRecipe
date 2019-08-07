using System;
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
                Language l = StorageAndRecipe.Language.Load(file);
                string[] s = file.Substring(0,file.Length-4).Split("\\".ToCharArray());
                l.LanguageName = s[s.Length - 1];
                languages.Add(l);
            }
            InitializeComponent();
            LanguageMenuItem.Items.Clear();
            foreach (Language l in languages)
            {
                RadioButton rb = new RadioButton();
                rb.Content = l.LanguageName;
                rb.Click += LanguageRadioButtonClick;
                LanguageMenuItem.Items.Add(rb);
            }
        }

        private void LanguageRadioButtonClick(object sender, RoutedEventArgs e)
        {
            RadioButton senderRB = (RadioButton)sender;
            foreach(RadioButton rb in LanguageMenuItem.Items)
            {
                if(rb.Equals(senderRB) ==false)
                {
                    rb.IsChecked = false;
                }
            }
            senderRB.IsChecked = true;
            foreach(Language l in languages)
            {
                if(l.LanguageName == (string)senderRB.Content)
                {
                    SetLanguage(l);
                    return;
                }
            }
            throw new Exception("Language not found");

        }

        private void SetLanguage(Language l)
        {
            this.Title = l.WindowTitle;
            StorageButton.Content = l.StorageButton;
            RecipeButton.Content = l.RecipeButton;
            LanguageMenuItem.Header = l.LanguageMenu;
        }

        private void StorageButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
