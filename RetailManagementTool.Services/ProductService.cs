using RetailManagementTool.Data;
using RetailManagementTool.Models.Product;
using RetailManagementTool.Models.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Services
{
    public class ProductService
    {
        public ProductService()
        {

        }

        //CREATE
        public bool CreateProduct(ProductCreate model)
        {
            var entity = new Product()
            {
                ProductDepartmentId = model.DepartmentId,
                Style = model.Style,
                SKU = model.SKU,
                Color = model.Color,
                ProductSizeId = model.SizeId,
                ProductName = model.ProductName,
                TicketPrice = model.TicketPrice,
                ProductPromotionId = model.PromotionId,
                //ProductPromotionId = CalculatePromotionId(model, model.DepartmentId),
                ProductZoneId = model.ZoneId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET ALL
        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Products.Select(
                             e =>
                                  new ProductListItem
                                  {
                                      ProductId = e.ProductId,
                                      DepartmentNumber = e.ProductDepartment.DepartmentNumber,
                                      Style = e.Style,
                                      SKU = e.SKU,
                                      ProductName = e.ProductName,
                                      ZoneName = e.ProductZone.ZoneName,
                                      PromotionDescription = e.ProductPromotion.PromotionDescription,
                                      PromotionId = e.ProductPromotionId
                                  }
                                       
                                  );
                query.ToList();
                List<ProductListItem> orderedBySKU = query.OrderBy(e => e.SKU).ToList();
                return orderedBySKU;
            }
        }

        //GET BY SKU
        public IEnumerable<ProductListItem> GetProductBySKU(string SKU)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Products.Where(e => e.SKU == SKU).Select(e => new ProductListItem
                     {
                         ProductId = e.ProductId,
                         DepartmentNumber = e.ProductDepartment.DepartmentNumber,
                         Style = e.Style,
                         SKU = e.SKU,
                         ProductName = e.ProductName,
                         ZoneName = e.ProductZone.ZoneName,
                         PromotionDescription = e.ProductPromotion.PromotionDescription,
                         PromotionId = e.ProductPromotionId
                     });

                return query.ToList();                  
            }
        }

        //GET BY ZONE
        public IEnumerable<ProductEditDetail> GetProductByZone(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Products.Where(e => e.ProductZoneId == id).Select(e => new ProductEditDetail
                    {
                        ProductId = e.ProductId,
                        DepartmentId = e.ProductDepartmentId,
                        DepartmentNumber = e.ProductDepartment.DepartmentNumber,
                        Style = e.Style,
                        SKU = e.SKU,
                        ProductName = e.ProductName,
                        Color = e.Color,
                        SizeId = e.ProductSizeId,
                        Size = e.ProductSize.SizeName,
                        TicketPrice = e.TicketPrice,
                        PromotionId = e.ProductPromotionId,
                        PromotionDescription = e.ProductPromotion.PromotionDescription,
                        ZoneId = e.ProductZoneId,
                        ZoneName = e.ProductZone.ZoneName,
                    });

                return query.ToList();
            }
        }

        //GET BY SIZE
        public IEnumerable<ProductEditDetail> GetProductBySize(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Products.Where(e => e.ProductSizeId == id).Select(e => new ProductEditDetail
                    {
                        ProductId = e.ProductId,
                        DepartmentId = e.ProductDepartmentId,
                        DepartmentNumber = e.ProductDepartment.DepartmentNumber,
                        Style = e.Style,
                        SKU = e.SKU,
                        ProductName = e.ProductName,
                        Color = e.Color,
                        SizeId = e.ProductSizeId,
                        Size = e.ProductSize.SizeName,
                        TicketPrice = e.TicketPrice,
                        PromotionId = e.ProductPromotionId,
                        PromotionDescription = e.ProductPromotion.PromotionDescription,
                        ZoneId = e.ProductZoneId,
                        ZoneName = e.ProductZone.ZoneName,
                    });

                return query.ToList();
            }
        }

        //GET Edit Detail BY Department
        public IEnumerable<ProductEditDetail> GetProductEditDetailByDepartment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Products.Where(e => e.ProductDepartmentId == id).Select(e => new ProductEditDetail
                    {
                        ProductId = e.ProductId,
                        DepartmentId = e.ProductDepartmentId,
                        DepartmentNumber = e.ProductDepartment.DepartmentNumber,
                        Style = e.Style,
                        SKU = e.SKU,
                        ProductName = e.ProductName,
                        Color = e.Color,
                        SizeId = e.ProductSizeId,
                        Size = e.ProductSize.SizeName,
                        TicketPrice = e.TicketPrice,
                        PromotionId = e.ProductPromotionId,
                        PromotionDescription = e.ProductPromotion.PromotionDescription,
                        ZoneId = e.ProductZoneId,
                        ZoneName = e.ProductZone.ZoneName,
                    });

                return query.ToList();
            }
        }

        //GET BY PROMOTION
        public IEnumerable<ProductEditDetail> GetProductByPromotion(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Products.Where(e => e.ProductPromotionId == id).Select(e => new ProductEditDetail
                    {
                        ProductId = e.ProductId,
                        DepartmentId = e.ProductDepartmentId,
                        DepartmentNumber = e.ProductDepartment.DepartmentNumber,
                        Style = e.Style,
                        SKU = e.SKU,
                        ProductName = e.ProductName,
                        Color = e.Color,
                        SizeId = e.ProductSizeId,
                        Size = e.ProductSize.SizeName,
                        TicketPrice = e.TicketPrice,
                        PromotionId = e.ProductPromotionId,
                        PromotionDescription = e.ProductPromotion.PromotionDescription,
                        ZoneId = e.ProductZoneId,
                        ZoneName = e.ProductZone.ZoneName,
                    });

                return query.ToList();
            }
        }



        //GET BY ID
        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Products.Single(e => e.ProductId == id);


                return new ProductDetail
                {
                    ProductId = entity.ProductId,
                    DepartmentId = entity.ProductDepartmentId,
                    DepartmentNumber = entity.ProductDepartment.DepartmentNumber,
                    Style = entity.Style,
                    SKU = entity.SKU,
                    Color = entity.Color,
                    SizeId = entity.ProductSizeId,
                    Size = entity.ProductSize.SizeName,
                    ProductName = entity.ProductName,
                    TicketPrice = entity.TicketPrice,
                    //  PromotionId = CalculatePromotionId(entity.ProductPromotion, entity.ProductDepartment),
                    PromotionId = CalculatePromotionId(entity.ProductPromotion, entity.ProductDepartment),
                    PromotionDescription = CalculatePromotionDescription(entity.ProductPromotion, entity.ProductDepartment),
                    //PromotionDescription = entity.ProductPromotion.PromotionDescription,
                    SalesPrice = CalculateSalesPrice(entity.TicketPrice, entity.ProductDepartment.DepartmentPromotionId),
                    IndividualSalesPrice = CalculateIndividualSalesPrice(entity.TicketPrice, entity.ProductPromotion),
                    ZoneId = entity.ProductZoneId,
                    ZoneName = entity.ProductZone.ZoneName,
                    DepartmentPromotionDescription = entity.ProductDepartment.DepartmentPromotion.PromotionDescription
                };
            }
        }

        public ProductEditDetail GetProductForEdit(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Products.Single(e => e.ProductId == id);


                return new ProductEditDetail
                {
                    ProductId = entity.ProductId,
                    DepartmentId = entity.ProductDepartmentId,
                    DepartmentNumber = entity.ProductDepartment.DepartmentNumber,
                    Style = entity.Style,
                    SKU = entity.SKU,
                    ProductName = entity.ProductName,
                    Color = entity.Color,
                    SizeId = entity.ProductSizeId,
                    Size = entity.ProductSize.SizeName,
                    TicketPrice = entity.TicketPrice,
                    PromotionId = entity.ProductPromotionId,
                    PromotionDescription = entity.ProductPromotion.PromotionDescription,
                    ZoneId = entity.ProductZoneId,
                    ZoneName = entity.ProductZone.ZoneName,
                };
            }
        }


        //GET My Bids
        public IEnumerable<ProductListItem> GetProductsByDepartment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Products
                    .Where(e => e.ProductDepartment.DepartmentId == id)
                    .Select(e => new ProductListItem
                    {
                        ProductId = e.ProductId,
                        DepartmentNumber = e.ProductDepartment.DepartmentNumber,
                        Style = e.Style,
                        SKU = e.SKU,
                        ProductName = e.ProductName,
                        ZoneName = e.ProductZone.ZoneName,
                        PromotionDescription = e.ProductPromotion.PromotionDescription,
                        PromotionId = e.ProductPromotionId
                    }
                    );

                query.ToList();
                List<ProductListItem> orderedBySKU = query.OrderBy(e => e.SKU).ToList();
                return orderedBySKU;

            }
        }



        //UPDATE
        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.ProductId == model.ProductId);

                entity.ProductDepartmentId = model.ProductDepartmentId;
                entity.Style = model.Style;
                entity.SKU = model.SKU;
                entity.ProductName = model.ProductName;
                entity.Color = model.Color;
                entity.ProductSizeId = model.ProductSizeId;
                entity.TicketPrice = model.TicketPrice;
                entity.ProductPromotionId = model.ProductPromotionId;
                entity.ProductZoneId = model.ProductZoneId;

                return ctx.SaveChanges() == 1;
            }
        }


        //DELETE
        public bool DeleteProduct(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Products.Single(e => e.ProductId == id);

                ctx.Products.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        
        private decimal CalculateSalesPrice(decimal ticketPrice, int? promoId) //int promoID
        {
            var service = new PromotionService();
            var promotion = service.GetPromotionById(promoId);

            switch (promotion.PromoType)

            {
                case "No Promo":
                    return ticketPrice;
                case "Percent Off":
                    return (ticketPrice * (100 - promotion.PromotionValue) / 100);
                case "New Dollar Amount":
                    return promotion.PromotionValue;

                default:
                    return ticketPrice;
            }
        }

        private decimal CalculateIndividualSalesPrice(decimal ticketPrice, Promotion promotion)
        {
            {
                switch (promotion.PromoType.Type)

                {
                    case "No Promo":

                        return ticketPrice;
                    case "Percent Off":
                        return (ticketPrice * (100 - promotion.PromoValue) / 100);
                    case "New Dollar Amount":
                        return promotion.PromoValue;

                    default:
                        return ticketPrice;
                }
            }
        }

        private int? CalculatePromotionId(Promotion promotion, Department department)
        {
            switch (department.DepartmentPromotion.PromoType.Type) //PromotionDescription)

            {
                case "No Promo":

                    return promotion.PromoTypeId;
                default:
                    return department.DepartmentPromotionId;
            }
        }

        private string CalculatePromotionDescription(Promotion promotion, Department department)
        {
            switch (department.DepartmentPromotion.PromoType.Type) //PromotionDescription)

            {
                case "No Promo":

                    return promotion.PromotionDescription;
                default:
                    return department.DepartmentPromotion.PromotionDescription;
            }
        }
    }
}

    

/*
        //Update List of Products
        public IEnumerable<ProductListItem> UpdateListOfProducts(ProductPromoEdit model)//IEnumerable<ProductListItem> listOfProducts, int promotionId)  you may need a model that will have listOfProducts and a promotion ID in it.
        {
            //foreach through list of products, and change the Promotion.PromotionType.Id to the new promotionId
            using (var ctx = new ApplicationDbContext())
            {
                foreach (var product in model.ProductsInDepartment)//listOfProducts    change to model.ProductsInDepartment)
                {
                    var productToChange = ctx.Products.Where(e => e.ProductId == product.ProductId).FirstOrDefault();
                    if (productToChange != null)
                    {
                        productToChange.ProductPromotionId = model.PromotionId;
                    }
                }
                ctx.SaveChanges();
                return model.ProductsInDepartment;
            }

        }
        */