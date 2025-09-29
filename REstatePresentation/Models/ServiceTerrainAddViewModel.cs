using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REstatePresentation.Models
{
    public class ServiceTerrainAddViewModel
    {
        public ServiceTerrain ServiceTerrain { get; set; }
        public ServiceTerrainPhoto ServiceTerrainPhoto { get; set; }
        public ServiceMap ServiceMap { get; set; }
        public ServiceInfo ServiceInfo { get; set; }
        [NotMapped]
        public List<IFormFile> Photos { get; set; }
        //public FormFile Gorsel {  get; set; }
        public string GorselYolu { get; set; }
        public List<string> PhotoPaths { get; set; }
    }
}
