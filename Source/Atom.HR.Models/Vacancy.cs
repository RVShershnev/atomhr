using Atom.HR.Professions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atom.HR.Models
{
    [Serializable]
    public class Vacancy
    {
        /// <summary>
        /// Id Вакансии в системе.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Ссылка на тесты.
        /// </summary>
        public string ChallengeId { get; set; }

        /// <summary>
        /// Дата создания вакансии.
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Опубликована на платформе.
        /// </summary>
        public bool IsPublish { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание в свободной форме.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Минимальная зарплата.
        /// </summary>
        public double MinSalary { get; set; }

        /// <summary>
        /// Максимальная зарплата.
        /// </summary>
        public double MaxSalary { get; set; }

        /// <summary>
        /// До какого числа нужно закрыть вакансию.
        /// </summary>
        public DateTime CloseVacancy { get; set; }

        /// <summary>
        /// Начало выхода на работу.
        /// </summary>
        public DateTime StartProject { get; set; }

        /// <summary>
        /// Окончательная дата работы (проекта). Если безсрочно, то значение по умолчанию 01.01.0001 0:00:00.
        /// </summary>
        public DateTime FinishProject { get; set; }

        /// <summary>
        /// Тип вакансии.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Название команды.
        /// </summary>
        public string TeamName { get; set; }
             

        /// <summary>
        /// Набор навыков.
        /// </summary>
        public List<Skill> Skills { get; set; }
        public List<TestWork> TestWorks { get; set; }
    }
}
