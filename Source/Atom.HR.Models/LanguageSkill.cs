using System;

namespace Atom.HR.Models
{
    [Serializable]
    public class LanguageSkill
    {
        public string Name { get; set; }
        public string Level { get; set; }

        public static string[] Levels { get; set; } =
        {
            "Элементарное владение",
            "Самостоятельное владение",
            "Свободное владение",
            "Родной язык"
        };
    }
}
