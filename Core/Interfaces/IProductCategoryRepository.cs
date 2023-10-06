using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IProductCategoryRepository: IGenericRepositoryWithIntId<ProductCategory>{
    bool ItAlreadyExists(ProductCategoryDto recordDto);    
}