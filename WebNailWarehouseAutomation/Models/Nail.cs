using System.ComponentModel.DataAnnotations;

namespace WebNailWarehouseAutomation.Models
{
    /// <summary>Модель гвоздей</summary>
    public class Nail : ICloneable
    {
        /// <summary>
        ///  Минимальное значение для поля  <see cref="Quantity"/>
        /// </summary>

        public const int minQuantity = 10;
        /// <summary>
        /// Максимальное количество символов в  поле <see cref="Name"/>
        /// </summary>
        public const int maxStringLength = 70;
        /// <summary>
        /// Минимальное количество символов в поле  <see cref="Name"/>
        /// </summary>
        public const int minStringLength = 1;
        /// <summary>
        /// Первичный ключ для БД
        /// </summary>
        public Guid id { set; get; } = Guid.NewGuid();
        /// <summary>
        /// Наименование гвоздей
        /// </summary>
        [Required(ErrorMessage = "Не указанно имя товара")]
        [StringLength(maxStringLength,
            MinimumLength = minStringLength,
            ErrorMessage = "Имя должно иметь длину от 1 и до 70 символов")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        /// <summary>
        /// Диаметр гвоздя
        /// </summary>
        [Required(ErrorMessage = "Не указан диаметр товара")]
        [Range(0.001, double.MaxValue, ErrorMessage = "Недопустимый диаметр товара")]
        [Display(Name = "Диаметр")]
        public double Diameter { get; set; }
        /// <summary>
        /// Высота гвоздя
        /// </summary>
        [Required(ErrorMessage = "Не указана длина товара")]
        [Range(0.001, double.MaxValue, ErrorMessage = "Недопустимая длина товара")]
        [Display(Name = "Длина")]
        public double Length { get; set; }
        /// <summary>
        /// <see cref="Models.ClassEnums.NailMaterials"/>
        /// </summary>
        [Required(ErrorMessage = "Не указан материал из которого изготовлен товар")]
        [Display(Name = "Материал")]
        public ClassEnums.NailMaterials Material { get; set; }
        /// <summary>
        /// Количество гвоздей
        /// </summary>
        [Required(ErrorMessage = "Не указано количество товара")]
        [Range(minQuantity, int.MaxValue, ErrorMessage = "Недопустимое количество товара")]
        [Display(Name = "Количество")]
        public int Quantity { get; set; }
        /// <summary>
        /// Цена без НДС
        /// </summary>
        [Required(ErrorMessage = "Не указана цена одного экземпляра товара без учёта НДС")]
        [Range(0, double.MaxValue, ErrorMessage = "Недопустимая цена товара(без учёта НДС)")]
        [Display(Name = "Цена без НДС")]
        public double PriceExcludingVAT { get; set; }

        /// <summary>
        /// реализация метода интерфейса <see cref="ICloneable"/>
        /// </summary>
        /// <returns>копия экземпляра класса <see cref="Nail"/></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
        /// <summary>
        /// Рассчитывает цену товара с указанным НДС
        /// </summary>
        /// <param name="VAT">НДС</param>
        /// <returns>Возвращает стоимость товара с НДС</returns>
        public double PriceIncludingVAT(double VAT) => (PriceExcludingVAT / 100 * VAT) + PriceExcludingVAT;
    }
}
