using System.ComponentModel.DataAnnotations;

namespace StoreCommon.Models;

public class Product {
    public int Id { get; set; }

    [Required, MinLength(2)]
    public string Name { get; set; }

    [Required, Range(0, 999999)]
    public float Price { get; set; }
}
