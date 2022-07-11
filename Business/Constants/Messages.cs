using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BookAdded = "Kitap Eklendi";
        public static string BookNameInvalid = "Kitap ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string BooksListed = "Kitaplar listelendi";
        public static string BookPriceInvalid = "Fiyat geçersiz. 0 girilemez";
        public static string CustomerAdded = "Müşteri eklendi";
        //public static string CarAlreadyRented = "Araba daha önceden kiralanmıştır";
        //public static string RentalSucceed = "Kiralama başarılı bir şekilde gerçekleşti";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kayıt oldu.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Yanlış şifre";
        public static string SuccessfulLogin = "Başarıyla giriş yapıldı.";
        public static string UserAlreadyExists = "Bu kullanıcı zaten var.";
        public static string AccessTokenCreated = "Token oluşturuldu.";
    }
}
