using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shop.Production.Api.Infrastructure.Services.Contracts;
using Shop.Production.Api.Infrastructure.Repository.Contracts;
using Shop.Production.Api.Infrastructure.Services.ServicesResult.Core;
using Shop.Production.Api.Infrastructure.Data.Entities;
using Shop.Production.Api.Infrastructure.Services.ServicesResult.Models.Product;

namespace Shop.Production.Api.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _ProductRepository;
        private readonly ISupplierRepository _SupplierRepository;
        private readonly ICategoryRepository _CategoryRepository;
        private readonly ILogger<ProductService> _logger;
        
        public ProductService(IProductRepository productRepository,
                              ISupplierRepository supplierRepository,
                              ICategoryRepository categoryRepository,
                              ILogger<ProductService> logger
                              )
        {
            this._ProductRepository = productRepository;
            this._SupplierRepository = supplierRepository;
            this._CategoryRepository = categoryRepository;
            this._logger = logger;
        }

        public ProductServiceResultCore GetProducts()
        {
            ProductServiceResultCore productServiceResult = new ProductServiceResultCore();
            try
            {
                var query = (from product in _ProductRepository.FindAll()
                             join supplier in _SupplierRepository.FindAll()
                             on product.SupplierId equals supplier.SupplierId
                             join category in _CategoryRepository.FindAll()
                             on product.CategoryId equals category.CategoryId
                             select new ProductServiceResultGetModel
                             {
                                 ProductId = product.ProductId,
                                 ProductName = product.ProductName,
                                 CategoryName = category.CategoryName,
                                 CompanyName = supplier.CompanyName,
                                 UnitPrice = product.UnitPrice,
                                 Discontinued = product.Discontinued,
                             }).ToList();

                productServiceResult.Data = query;
                productServiceResult.Success = true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error {e.Message}");
                productServiceResult.Success = false;
                productServiceResult.Message = "Error obteniendo los productos";
            }

            return productServiceResult;
        }

        /*
             Verifica todos los nombres de los productos tanto los eliminados como los existentes.
            Si existe y esta eliminado como quiera dira que existe.
        */
        public async Task<ProductServiceResultCore> SaveProduct(ProductServiceResultAddModel oProductServiceResultModel)
        {
            ProductServiceResultCore productServiceResult = new ProductServiceResultCore();

            try
            {
                if (await ValidateProduct(oProductServiceResultModel.ProductName))
                {
                    productServiceResult.Success = false;
                    productServiceResult.Message = $"Este modelo {oProductServiceResultModel.ProductName} ya esta registrado";
                    return productServiceResult;
                }

                Product newProduct = new Product()
                {
                    ProductName = oProductServiceResultModel.ProductName,
                    SupplierId = oProductServiceResultModel.SupplierId,
                    CategoryId = oProductServiceResultModel.CategoryId,
                    UnitPrice = oProductServiceResultModel.UnitPrice,
                    Discontinued = oProductServiceResultModel.Discontinued,
                    Creation_User = oProductServiceResultModel.CreationUser,
                    Creation_Date = oProductServiceResultModel.CreationDate
                };
                await _ProductRepository.Add(newProduct);
                await _ProductRepository.Commit();

                productServiceResult.Success = true;
                productServiceResult.Data = oProductServiceResultModel;
                productServiceResult.Message = "Producto agregado";

            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message}");
                productServiceResult.Success = false;
                productServiceResult.Message = "Error agregando el producto";
                productServiceResult.Data = null;
            }
            return productServiceResult;
        }
        
        /*
         Puedo editar un cliente con una categoria que no existe, lo mejor es realizar una clase
        con las validaciones y llamar esta en el modelo del servicio para que no permita
        colocar datos de entidades que no existe o  que esten eliminadas
         */

        public async Task<ProductServiceResultCore> UpdateProduct(ProductServiceResultModifyModel oProductServiceResultModifyModel)
        {
            ProductServiceResultCore resultProduct = new ProductServiceResultCore();

            try
            {
                Product productUpdated = await _ProductRepository.GetById(oProductServiceResultModifyModel.ProductId);

                if (productUpdated == null || productUpdated.Deleted == true)
                {
                    resultProduct.Message = "El producto no existe";
                    return resultProduct;
                }
                else
                {
                    if (await ValidateProduct(oProductServiceResultModifyModel.ProductName))
                    {

                        resultProduct.Message = $"Este producto '{oProductServiceResultModifyModel.ProductName}' ya esta registrado";
                        resultProduct.Success = false;
                    }
                    else
                    {
                        productUpdated.ProductName = oProductServiceResultModifyModel.ProductName;
                        productUpdated.SupplierId = oProductServiceResultModifyModel.SupplierId;
                        productUpdated.CategoryId = oProductServiceResultModifyModel.CategoryId;
                        productUpdated.UnitPrice = oProductServiceResultModifyModel.UnitPrice;
                        productUpdated.Discontinued = oProductServiceResultModifyModel.Discontinued;
                        productUpdated.Modify_User = oProductServiceResultModifyModel.UserMod;
                        productUpdated.Modify_Date = oProductServiceResultModifyModel.ModifyDate;

                        _ProductRepository.Update(productUpdated);
                        await _ProductRepository.Commit();

                        resultProduct.Data = productUpdated;
                        resultProduct.Message = "Producto actualizado correctamente.";
                    }

                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error:{e.Message}");
                resultProduct.Success = false;
                resultProduct.Message = "Error agregando la informacion del producto";
            }
            return resultProduct;
        }
        public async Task<ProductServiceResultCore> RemoveProduct(int id)
        {
            ProductServiceResultCore productServiceResult = new ProductServiceResultCore();
            ProductServiceResultDeletedModel productDeleteModel = new ProductServiceResultDeletedModel();
            try
            {
                Product oProduct = await _ProductRepository.GetById(id);

                if (oProduct == null || oProduct.Deleted == true)
                {
                    productServiceResult.Message = "El producto no existe";
                    return productServiceResult;
                }
                oProduct.Deleted = true;
                oProduct.Delete_User = productDeleteModel.UserDeleted;
                oProduct.Delete_Date = productDeleteModel.DeletedDate;

                _ProductRepository.Update(oProduct);
                await _ProductRepository.Commit();

                productServiceResult.Success = true;
                productServiceResult.Message = "Producto eliminado";

            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message}");
                productServiceResult.Success = false;
                productServiceResult.Message = "Error eliminando el producto";
            }
            return productServiceResult;
        }
     
        
        /*
         Da problemas cuando hay un producto con una categoria eliminada o inexistente. Se agrego una validacion en el metodo de eliminar
           de categoria para que verifique si aun existe un producto con data de categoria antes de eliminar la misma. Pero esta correcto
            de esta forma?
         */
        public async Task<ProductServiceResultCore> GetProductById(int id)
        {
            ProductServiceResultCore productServiceResult = new ProductServiceResultCore();
            ProductServiceResultGetModel productGetModel = new ProductServiceResultGetModel();
            try
            {
                var oProduct = await _ProductRepository.GetById(id);


                if (oProduct ==null || oProduct.Deleted == true)
                {
                    productServiceResult.Message = "El producto no existe";
                    productServiceResult.Data = null;
                    productServiceResult.Success = true;
                    return productServiceResult;
                }
                else
                {
                    var query = (from product in _ProductRepository.FindAll().Where(c => c.ProductId == oProduct.ProductId)
                                 join category in _CategoryRepository.FindAll().Where(c => c.CategoryId == oProduct.CategoryId)
                                 on product.CategoryId equals category.CategoryId
                                 join supplier in _SupplierRepository.FindAll().Where(c => c.SupplierId == oProduct.SupplierId)
                                 on product.SupplierId equals supplier.SupplierId
                                 select new ProductServiceResultGetModel
                                 {
                                     ProductId = product.ProductId,
                                     ProductName = product.ProductName,
                                     UnitPrice = product.UnitPrice,
                                     Discontinued = product.Discontinued,
                                     CategoryName = category.CategoryName,
                                     CompanyName = supplier.CompanyName
                                 });
                    productServiceResult.Data = query;
                    productServiceResult.Message = "Producto encontrado";
                    productServiceResult.Success = true;
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message}");
                productServiceResult.Message = "Error filtrando el producto";
                productServiceResult.Success = false;
            }
            return productServiceResult;
        }

        public async Task<bool> ValidateProduct(string productName)
        {

            return await _ProductRepository.Exists(Product => Product.ProductName == productName);

        }

    }
}