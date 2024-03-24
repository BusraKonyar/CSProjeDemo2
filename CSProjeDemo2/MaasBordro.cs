using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public static class MaasBordro
    {
        public static void Olustur(List<Personel> personeller)
        {
            foreach (var personel in personeller)
            {
                // Maaş hesabı yapılır
                decimal salary = personel.CalculateSalary();

                // Maaş bilgileri JSON formatında oluşturulur
                var maasBilgisi = new
                {
                    PersonelIsmi = personel.Name,
                    CalismaSaati = personel.WorkHours,
                    AnaOdeme = salary,
                    ToplamOdeme = salary
                };

                // Maaş bilgileri ilgili personelin klasörüne kaydedilir
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, personel.Title);
                Directory.CreateDirectory(folderPath); // Eğer klasör yoksa oluşturulur
                string fileName = $"{personel.Name}MaasBordrosu{DateTime.Now:MMMM_yyyy}.json";
                string filePath = Path.Combine(folderPath, fileName);
                File.WriteAllText(filePath, JsonConvert.SerializeObject(maasBilgisi, Formatting.Indented));
            }
        }

        public static void AzCalisanlariRaporla(List<Personel> personeller)
        {
            Console.WriteLine("Az Çalışan Personellerin Bilgileri:");
            foreach (var personel in personeller)
            {
                if (personel.WorkHours < 150)
                {
                    Console.WriteLine($"Personel Adı: {personel.Name}, Çalışma Saati: {personel.WorkHours}");
                }
            }
        }
    }
}