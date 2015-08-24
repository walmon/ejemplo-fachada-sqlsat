using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wm.sqlsat.alt.svc
{
    /// <summary>
    /// esta capa de fachada puede ser reemplazada por una librería de clases
    /// Permite ocultar la verdadera implementación de las solicitudes de datos
    /// </summary>
    [ServiceContract]
    public interface IFacade
    {
        void InsertClassRoom(int number, int building, int floor, int capacity, string description);

        List<entity.ClassRoomEntity> GetClassRooms();

        IEnumerable<entity.ClassesEntity> GetStudentsDistribution();
    }
}
