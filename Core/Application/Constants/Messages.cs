﻿namespace Application.Constants
{
    public static class Messages<T>
    {
        private static readonly string EntityName = typeof(T).Name;

        public static string EntityAdded => $"{EntityName} başarıyla eklendi";
        public static string EntityUpdated => $"{EntityName} başarıyla güncellendi.";
        public static string EntityDeleted => $"{EntityName} verisi silindi.";
        public static string EntityNotFound => $"Girdiğiniz id değerine sahip {EntityName} verisi bulunamadı.";
        public static string EntityNameDuplicated => $"Bu isme sahip bir {EntityName} zaten var, lütfen ismi değiştirin.";
        public static string EntityAlreadyDeleted => $"Girdiğiniz id değerine sahip {EntityName} zaten silinmiş.";
        public static string EntityCantMathes => $"Email veya Şifreyi Yanlış Girdiniz";
    }
}
