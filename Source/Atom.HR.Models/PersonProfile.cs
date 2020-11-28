using System;
using System.Collections.Generic;
using System.Text;

namespace Atom.HR.Models
{
    [Serializable]
    public class PersonProfile
    {
        public string Id { get; set; }

        #region Personal information
        /// <summary>
        /// Полное имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// День рождение.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Гражданство.
        /// </summary>
        public string Сitizenship { get; set; }

        /// <summary>
        /// Местоположение.
        /// </summary>
        public string Situated { get; set; }

        /// <summary>
        /// Рассказ о себе.
        /// </summary>
        public string About { get; set; }


        /// <summary>
        /// Семейное положение.
        /// </summary>
        public bool IsMarried { get; set; }

        /// <summary>
        /// Дети.
        /// </summary>
        public int Childrens { get; set; }
        #endregion

        /// <summary>
        /// Водительские права.
        /// </summary>
        public string DriveCard { get; set; }

        /// <summary>
        /// Наличие автомобиля.
        /// </summary>
        public bool HasCar { get; set; }

        public List<Education> EducationSkills { get; set; }
        public List<Experience> ExperienceSkills { get; set; }
        public List<LanguageSkill> LanguageSkills { get; set; }
        public List<Contact> Contacts { get; set; }
        public string HardEvaluate { get; set; }
        public string SoftEvaluate { get; set; }
        public string LanguageEvaluate { get; set; }
        public string TypeCompanyRelation { get; set; }

        public string Telephone { get; set; }
        public string Email { get; set; }

        public string ChallengeId { get; set; }
    }

  
    public class Contact
    {
        public string NameOfContact { get; set; }
        public string Value { get; set; }
        public ContactTypes Type { get; set; }
    }
  
    public enum ContactTypes
    {
        Telephone,
        Email,
        Messenger
    }
}
