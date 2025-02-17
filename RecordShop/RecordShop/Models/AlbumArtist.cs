﻿using System.ComponentModel.DataAnnotations;

namespace RecordShop.Models
{
    public class AlbumArtist
    {
        [Key]
        public int Id { get; set; }

        public int AlbumID { get; set; }
        public Album Album { get; set; }

        public int ArtistID { get; set; }
        public Artist Artist { get; set; }
    }
}