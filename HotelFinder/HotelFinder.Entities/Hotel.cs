﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HotelFinder.Entities
{
    // veritabanı tablo entity class'ları bu katmanda tanımlanıyor
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string City { get; set; }
    }
}
