namespace LUG3WebApi.Authentication.Model
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public int? IdPostulant {get; set;}
        public string Dni {get;set;}
        public string UserName { get; set; }
        public string Password { get; set; }
        public int LoginType { get; set;}
        public bool TwoFactorEnabled { get; set; }
        public string SecurityStamp { get; set; }
    }
}
