using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSTracker.Utility
{
    
    public class VacancyType
    {
        private static IDictionary<int, string> dictVacancyType = new Dictionary<int, string>();

        static VacancyType()
        {
            dictVacancyType.Add(1, "New");
            dictVacancyType.Add(2, "Replacement");
        }
        public static string GetVacancyType(int id)
        {
            string vacancyType = string.Empty;
            if (id != 0)
            {
                vacancyType = dictVacancyType.FirstOrDefault(x => x.Key == id).Value;
            }
            return vacancyType;
        }

        public static IDictionary<int, string> GetAllVacancyType()
        {
            return dictVacancyType;
        }
    }
}