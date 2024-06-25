using System.ComponentModel.DataAnnotations;

namespace WebNailWarehouseAutomation.Models.ClassEnums
{
    /// <summary>
    /// материалы из которых произведены гвозди
    /// </summary>
    public enum NailMaterials
    {
        /// <summary>Медь</summary>
        [Display(Name = "Медь")]
        Copper,
        /// <summary>Сталь</summary>
        [Display(Name = "Сталь")]
        Steel,
        /// <summary>Железо</summary>
        [Display(Name = "Железо")]
        Iron,
        /// <summary>Хром</summary>
        [Display(Name = "Хром")]
        Chrome
    }
}
