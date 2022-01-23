using System.ComponentModel;

namespace EPaczuchaWeb.Models
{
    public class SendMethodViewModel
    {
        public int Id { get; set; }
        [DisplayName("Sposób wysyłki")]
        public string MethodName { get; set; }
        [DisplayName("Cena za wysyłke")]
        public decimal Price { get; set; }
    }
}