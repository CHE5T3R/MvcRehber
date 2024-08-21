using MvcRehber2.Models;
using System.ComponentModel;

namespace Rehber.Models.Entities
{
    public class rehberList
    {
        public int IdList { get; set; }
        public string nameList { get; set; }
        public string surnameList { get; set; }
        public string phoneNumberList { get; set; }
        public string emailList { get; set; }
        public string adresList { get; set; }
        public int sehirIdList { get; set; }

        public sehir sehir { get; set; }
        public int userIdList { get; set; }
        public user user { get; set; }

    }
}
