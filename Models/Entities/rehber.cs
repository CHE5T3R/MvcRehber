using MvcRehber2.Models;
using System.ComponentModel;

namespace Rehber.Models.Entities
{
    public class rehber
    {

        
        public int Id { get; set; }
        [DisplayName("Ad")]
        public string name { get; set; }
        [DisplayName("Soyad")]
        public string surname { get; set; }
        [DisplayName("Telefon Numarası")]
        public string phoneNumber { get; set; }
        [DisplayName("E-mail")]
        public string email { get; set; }
        [DisplayName("Adres")]
        public string adres { get; set; }
        [DisplayName("Şehir")]
        public int sehirId {  get; set; }
        public sehir sehir { get; set; }
        [DisplayName("User")]
        public int userId { get; set; }
        public user user { get; set; }

    }

}
