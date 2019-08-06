using System;
using System.IO;
using System.Xml.Serialization;

namespace StorageAndRecipe
{
    [Serializable]
    public class Language
    {
        public string WindowTitle { get; set; }
        public string RecipeButton { get; set; }
        public string StorageButton { get; set; }
        public string LanguageMenu { get; set; }
        public string LanguageName { get; set; }

        public void Save(string file)
        {
            if (!Directory.Exists("Languages"))
                Directory.CreateDirectory("Languages");
            using(var writer = new StreamWriter("Languages/"+file))
            {
                var serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(writer, this);
                writer.Flush();
            }
        }

        public static Language Load(string file)
        {
            using (var stream = File.OpenRead(file))
            {
                var serializer = new XmlSerializer(typeof(Language));
                return serializer.Deserialize(stream) as Language;
            }
        }
    }
}
