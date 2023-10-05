using Core.Entities;
using Models.Dtos;

namespace Core.Interfaces;
public interface IProductCategoryRepository: IGenericRepositoryWithIntId<ProductCategory>{
    bool ItAlreadyExists(ProductCategoryDto recordDto);
    bool HasChanged(ProductCategoryDto recordDto);
}