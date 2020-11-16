using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Bertoni.ViewModels
{
    public class AlbumsViewModel {
        public int AlbumId { get; set;}
        public List<SelectListItem> Albums { get; set; }
    }
}