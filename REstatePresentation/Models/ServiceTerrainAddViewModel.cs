using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace REstatePresentation.Models
{
    public class ServiceTerrainAddViewModel
    {
        public ServiceTerrain ServiceTerrain { get; set; }
        public ServicePhoto ServicePhoto { get; set; }
        public ServiceMap ServiceMap { get; set; }
        public ServiceInfo ServiceInfo { get; set; }

    }
}
