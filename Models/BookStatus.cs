using System.ComponentModel.DataAnnotations;

namespace MiniLibrary.Models
{
    public enum BookStatus
    {
        [Display(Name = "Да се прочете")]
        ToRead,

        [Display(Name = "Чета в момента")]
        Reading,

        [Display(Name = "Прочетена")]
        Read
    }
}

// използвам enumeration (enum) за статус на книга, да може да се избира между трите опции