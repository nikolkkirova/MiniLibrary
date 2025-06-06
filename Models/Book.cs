using System.ComponentModel.DataAnnotations; // за атрибути като [Required], [Display], [Range]
using System.ComponentModel.DataAnnotations.Schema; // за атрибути като [ForeignKey]
using Microsoft.AspNetCore.Identity; // за достъп до Identity модели като ApplicationUser

namespace MiniLibrary.Models
{
    public class Book
    {
        public int Id { get; set; } // Уникален индентификатор на книгата, първичен ключ (Primary Key)

        [Required] // Задължително поле, не може да бъде null или празно
        [Display(Name = "Заглавие")] // така ще се показва на екрана
        [StringLength(200)] // Максимална дължина на заглавието
        public string Title { get; set; } = string.Empty; // Заглавие на книгата

        [Required] // Задължително поле, не може да бъде null или празно
        [Display(Name = "Автор")] // така ще се показва на екрана
        [StringLength(100)] // Максимална дължина на името на автора
        public string Author { get; set; } = string.Empty; // Автор на книгата

        [Display(Name = "Жанр")] // така ще се покаже на екрана
        public string Genre { get; set; } = string.Empty; // Жанр на книгата

        [Required] // Задължително поле, не може да бъде null или празно
        [Display(Name = "Статус")] // така ще се покаже на екрана
        public BookStatus Status { get; set; } // "Да се прочете", "Чета в момента", "Прочетена"

        [Range(0, 5)] // позволява стойности от 0 до 5
        [Display(Name = "Рейтинг")] // така ще се покаже на екрана
        public int? Rating { get; set; } // Рейтинг на книгата от 0 до 5


        // Така всяка книга ще може да бъде свързана с потребител
        
        public string UserId { get; set; } = string.Empty; // Идентификатор на потребителя, който притежава книгата

        [ForeignKey("UserId")] // UserId е външен ключ
        public ApplicationUser? User { get; set; } // връзка към AspNetUsers таблицата
    }
}

// Използването на string.Empty избягва null стойности
// ? означава, че полето може да бъде null