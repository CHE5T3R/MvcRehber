using MvcRehber2.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rehber.Models.Entities
{
    public class rehber
    {

        
        public int Id { get; set; }
        [DisplayName("Ad")]
        [Required]
        public string name { get; set; }
        [DisplayName("Soyad")]
        public string surname { get; set; }
        [DisplayName("Telefon Numarası")]
        [MaxLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string phoneNumber { get; set; }
        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-mail girin")]
        public string email { get; set; }
        [DisplayName("Adres")]
        public string adres { get; set; }
        [DisplayName("Şehir")]
        public int sehirId {  get; set; }
        public sehir sehir { get; set; }
        [Required]
        public int userId { get; set; }
        public user user { get; set; }

    }

}
