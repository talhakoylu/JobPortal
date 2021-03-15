using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.Messages
{
    public static class Messages
    {
        public static class Advertisement
        {
            public static string GetAllSuccess = "İlanlar başarılı bir şekilde getirildi.";
            public static string GetByIdSuccess = "İlan başarılı bir şekilde getirildi.";
            public static string GetByIdErrorNull = "Bu id değerine sahip bir sonuç bulunmamaktadır.";
            public static string GetByCompanyIdSuccess = "Şirkete ait ilanlar başarılı bir şekilde getirildi.";
            public static string GetByCategoryIdSuccess = "Kategoriye ait ilanlar başarılı bir şekilde getirildi.";

            public static string AddSuccess = "Ekleme işlemi başarılı.";
            public static string DeleteSuccess = "Silme işlemi başarılı.";
            public static string UpdateSuccess = "Güncelleme işlemi başarılı.";
        }

        public static class Category
        {
            public static string GetAllSuccess = "Kategoriler başarılı bir şekilde getirildi.";
            public static string GetByIdSuccess = "Kategori başarılı bir şekilde getirildi.";
            
            public static string AddSuccess = "Kategori başarılı bir şekilde eklendi.";
            public static string DeleteSuccess = "Kategori başarılı bir şekilde eklendi.";
            public static string UpdateSuccess = "Kategori başarılı bir şekilde eklendi.";
        }

        public static class Company
        {
            public static string GetAllSuccess = "Şirketler başarılı bir şekilde getirildi.";
            public static string GetByIdSuccess = "Belirtilen id değerine sahip şirket getirildi";
            public static string GetAllByUserIdSuccess = "Kullanıcıya ait şirketler getirildi.";
            
            public static string AddSuccess = "Şirket başarılı bir şekilde eklendi.";
            public static string DeleteSuccess = "Şirket başarılı bir şekilde silindi.";
            public static string UpdateSuccess = "Şirket başarılı bir şekilde güncellendi.";
        }

        public static class CurriculumVitae
        {
            public static string GetAllSuccess = "CVler başarılı bir şekilde getirildi.";
            public static string GetByIdSuccess = "Id değerine ait CV başarılı bir şekilde getirildi.";
            public static string GetAllByUserIdSuccess = "Kullanıcı Id değerine ait CVler başarılı bir şekilde getirildi.";

            public static string AddSuccess = "CV başarılı bir şekilde eklendi.";
            public static string DeleteSuccess = "CV başarılı bir şekilde silindi.";
            public static string UpdateSuccess = "CV başarılı bir şekilde güncellendi.";
        }

        public static class OperationClaim
        {
            public static string GetAllSuccess = "Yetki listesi başarılı bir şekilde getirildi.";
            public static string GetByIdSuccess = "Id değerine ait yetki başarılı bir şekilde getirildi.";

            public static string AddSuccess = "Yetki başarılı bir şekilde eklendi.";
            public static string DeleteSuccess = "Yetki başarılı bir şekilde silindi.";
            public static string UpdateSuccess = "Yetki başarılı bir şekilde güncellendi.";

        }

        public static class User
        {
            public static string GetAllSuccess = "Kullanıcıların listesi başarılı bir şekilde getirildi.";
            public static string GetByIdSuccess = "Id değerine ait kullanıcı detayları başarılı bir şekilde getirildi.";
            public static string GetByMailSuccess = "Emaile ait kullanıcı detayları başarılı bir şekilde getirildi.";

            public static string AddSuccess = "Kullanıcı ekleme işlemi başarılı.";
            public static string DeleteSuccess = "Kullanıcı silme işlemi başarılı.";
            public static string UpdateSuccess = "Kullanıcı güncelleme işlemi başarılı.";
        }

        public static class UserOperationClaim
        {
            public static string GetAllSuccess = "Kullanıcıların yetkileri başarılı bir şekilde getirildi.";
            public static string GetByIdSuccess = "Id değerine ait yetki detayları başarılı bir şekilde getirildi.";
            public static string GetAllByUserIdSuccess = "Kullanıcıya ait yetki detayları başarılı bir şekilde getirildi.";
            public static string GetAllByOperationClaimIdSuccess = "Yetki değerine ait kullanıcı yetkilerinin detayları başarılı bir şekilde getirildi.";

            public static string AddSuccess = "Kullanıcıya yetki ekleme işlemi başarılı.";
            public static string DeleteSuccess = "Kullanıcıya ait yetki silme işlemi başarılı.";
            public static string UpdateSuccess = "Kullanıcıya ait yetki güncelleme işlemi başarılı.";
        }
    }
}
