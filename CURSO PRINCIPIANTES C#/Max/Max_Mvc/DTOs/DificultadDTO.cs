using Max_Mvc.Models;

namespace Max_Mvc.DTOs
{
    public class DificultadDTO
    {
        public int Id { get; set; }
		public string Descripcion { get; set; }
		public DificultadDTO(MDificultad entity)
        {
            if (entity == null)
            {
                return;
            }
			Id = entity.Id;
			Descripcion = entity.Descripcion;
        }
        public DificultadDTO()
        {

        }
	}
}
