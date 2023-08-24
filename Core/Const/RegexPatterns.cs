namespace Bookify.Web.Core.Consts
{
    public static class RegexPatterns
    {
        public const string Password = "(?=(.*[0-9]))(?=.*[\\!@#$%^&*()\\\\[\\]{}\\-_+=~`|:;\"'<>,./?])(?=.*[a-z])(?=(.*[A-Z]))(?=(.*)).{8,}";
        public const string url = "^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$";
        public const string Username = "^[a-zA-Z0-9-._@+]*$";
        public const string CharactersOnly_Eng = "^[a-zA-Z-_ ]*$";
        public const string CharactersOnly_Ar = "^[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FF ]*$";
        public const string NumbersAndChrOnly_ArEng = "^(?=.*[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z])[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z0-9 _-]+$";
        public const string DenySpecialCharacters = "^[^<>!#%$]*$";
        public const string MobileNumber = "^05[0,3,4,5,6,7,8,9][0-9]{7}$";
        public const string NumbersOnly = "^[0-9]*$";
        public const string IqamaNumber = @"^1.{9}$";
        public const string ArabicOnly = @"^[\u0621-\u064A\040]+$";
        public const string Eqrar = @"^(?:tru|fals)e$";

    }
}