using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser:IdentityUser<int> //identity kütüphanesi id yi string oalrak alıyor defautl olarak ben projede int olarak çalıştığım için <int> diyorum.
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
