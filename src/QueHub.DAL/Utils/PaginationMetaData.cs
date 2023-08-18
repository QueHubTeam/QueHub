namespace QueHub.DAL.Utils;

public class PaginationMetaData
{
    // Navigatsiya uchun "OLDINGI" sahifa mavjudligini ko'rsatadigan mantiqiy qiymat.
    public bool HasPrevious { get; set; }

    // Navigatsiya uchun "KEYINGI" sahifa mavjudligini ko'rsatadigan mantiqiy qiymat.
    public bool HasNext { get; set; }

    // Ko'rsatilayotgan joriy sahifa raqamini ifodalovchi butun son.
    public int CurrentPage { get; set; }

    // Faqat joriy sahifani emas, balki butun ma'lumotlar to'plamidagi
    // elementlarning umumiy sonini ifodalovchi butun son
    public int TotalPages { get; set; }

    // Bu bitta sahifada qancha element ko'rsatilishini belgilaydigan butun son.
    public int PageSize { get; set; }

    // Har bir sahifada ko'rsatilgan elementlar va elementlarning umumiy
    // soniga asoslangan sahifalarning umumiy sonini ko'rsatadigan butun son.
    public int TotalItems { get; set; }
}
