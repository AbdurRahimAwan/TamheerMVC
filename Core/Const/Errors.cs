namespace Core.Const
{
    public static class Errors
    {
        public const string RequiredField = " {0} حقل اجبارى  ";
        public const string MaxLength = " 500 يجب الا تزيد الحروف عن ";
        public const string MaxMinLength = "وبحد ادنى {2} {1} يجب ان تحتوى {0} بحد اقصى على .";
        public const string MaxMinLength2 = "يجب أن يكون عدد الأحرف {0} على الأقل {2} والحد الأقصى {1} من الأحرف.";
        public const string Duplicated = " {0} مسجل من قبل !";
        public const string DuplicatedBook = "الكتاب بنفس العنوان موجود بالفعل مع نفس المؤلف!";
        public const string NotAllowedExtension = "فقط الملفات .png، .jpg، .jpeg مسموح بها!";
        public const string MaxSize = "!يحب ان يكون حجم الملف لا يزيد عن 2 مجيا";
        public const string NotAllowFutureDates = "التاريخ لا يمكن أن يكون في المستقبل!";
        public const string InvalidRange = "{0} يجب أن يكون بين {1} و {2}!";
        public const string ConfirmPasswordNotMatch = "كلمة المرور وتأكيد كلمة المرور غير متطابقتان.";
        public const string WeakPassword = "تحتوي كلمة المرور على أحرف كبيرة وأحرف صغيرة ورقم وأحرف غير أبجدية . يجب أن تتكون كلمات المرور من 8 أحرف على الأقل";
        public const string InvalidUsername = "اسم المستخدم لابد ان يحتوى على ارقام وحروف فقط.";
        public const string OnlyEnglishLetters = "مسموح فقط باستخدام الحروف الإنجليزية.";
        public const string OnlyArabicLetters = "مسموح فقط باستخدام الحروف العربية.";
        public const string OnlyNumbersAndLetters = "اكتب الأحرف العربية فقط ، ويسمح باستخدام الأحرف أو الأرقام الإنجليزية.";
        public const string DenySpecialCharacters = "يمنع استعمال الرموز.";
        public const string InvalidMobileNumber = "رقم الجوال المدخل غير صحيح.";
        public const string InvalidNumbersOnly = "برجاء كتابة ارقام فقط.";
        public const string EgeLimit = "الرجاء إدخال عمر صالح";
        public const string Eqrar = "الرجاء قبول إِقْرار";
        public const string invalidUrl = "اكتب الرابط الصحيح";
    }
}