using System.Collections;
using Api.Helpers;
using AutoMapper;
using Core.Interfaces;

namespace Api.Extensions;
public static class CollectionExtensions{
    //* Implementacion del sistema de paginacion por medio de un extencion method
    public static IPager<Dto> GetPaged<Dto,Entity>(this IEnumerable<Entity> sourse, IMapper Mapper, IParam param) where Dto: class{        
        // validar sourse
        if(sourse == null)
            throw new ArgumentNullException(nameof(sourse));
        //mapear registros
        var records = Mapper.Map<List<Dto>>(sourse);
        //tomar paginado
        records = records.Skip((param.PageIndex - 1) * param.PageSize)
            .Take(param.PageSize)
            .ToList();        
        //retornar paginado
        return new Pager<Dto>(records, records.Count, param);
    }
}
