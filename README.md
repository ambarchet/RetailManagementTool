# RetailManagementTool<h1>RETAILMANAGEMENTTOOL</h1>

<h2>DESCRIPTION</h2>

<p>My goal was to create an MVC application for retail stores to be able to manage their products, as it relates to promotions and zone allocations. The target audience would be retail stores of any kind. This application could be used by, both, home office and associates on the sales floor. As someone who has worked in the retail industry, I realize how important it is to get information to customer-facing associates in as quick and user-friendly a manner as possible. 
  
  This project is designed to provide "back end" functionality for an administrator to be able to create, edit, update, and delete a product for sale, department, zone, size, and promotion. It also provides "front end" functionality that gives an Employee the ability to look up a product's department, style #, SKU #, name, zone, size, color, zone location, ticket price, and sales price. There is a SKU searchbar in place at the top of the products list page which allows an employee to retrieve a specific product based on its SKU #, much like what would happen if they scanned a product's barcode. </p>

<h2>DATABASE</h2>

<a id="Screenshot of db Layout " href="https://docs.google.com/document/d/e/2PACX-1vRz7zr7j0bL1stj24fZVAUSaPpmZ3_TMRh8-aSbcQNo7YkzfplcV_EEPYRCFsdOGbrLbEwThjm0YyVG/pub" target="blank">Screenshot of dbdiagram.io layout for RetailManagementTool</a>
   

<h4>Product</h4>
<ul>
  <li>int Id [pk]</li>
  <li>int Department [Foreign Key of DepartmentId]</li>
  <li>string Style</li>
  <li>string SKU</li>
  <li>string Name</li>
  <li>string Color</li>
  <li>int Size [Foreign Key of SizeId]</li>
  <li>decimal TicketPrice</li>
  <li>int Promotion [Foreign Key of PromotionId]</li>
  <li>int Zone [Foreign Key of ZoneId]</li>
</ul>

<h4>Department</h4>
<ul>
  <li>int Id [pk]</li>
  <li>string DepartmentNumber</li>
  <li>string DepartmentName</li>
  <li>int Promotion [Foreign Key of Promotion Id]</li>
  <li>virtual ICollection<Product> ProductsInDepartment</li>
</ul>

<h4>Zone</h4>
<ul>
  <li>int Id [pk]</li>
  <li>string Name</li>
</ul>

<h4>Promotion</h4>
<ul>
  <li>int Id[pk]</li>
  <li>string PromotionDescription</li>
  <li>int PromoTypeId [Foreign Key of PromotionTypeId]
  <li>decimal PromoValue
</ul>

<h4>PromotionType</h4>
<ul>
  <li>int Id[pk]</li>
  <li>string Type</li>
</ul>

<h4>Size</h4>
<ul>
  <li>int Id [pk]</li>
  <li>string SizeName</li>
</ul>

<h4>ApplicationUser</h4>
<ul>
  <li>guid Id [pk]</li>
  <li>string email</li>
  <li>string password</li>
  <li>string UserName</li>
</ul>

<h4>IdentityRole</h4>
<ul>
  <li>guid Id [pk]</li>
  <li>string Name</li>
</ul>

<h4>IdentityUserRole</h4>
<ul>
  <li>UserId guid [Foreign Key of ApplicationUserId</li>
  <li>RoleId guid [Foreign Key of IdentityRoleId</li>
</ul>

<h2>Usage</h2>

<Through the Startup.cs class, two types of Roles get seeded when you run this program (Admin and Employee).
There is one seeded Admin that can be used for testing:
<ul>
  <li>UserName: Master</li>
  <li>Email:    master@gmail.com</li>
  <li>Password: Master1!</li>
          
 Any other user that is created using the Register functionality, must select the Role, Employee.
 
 Employee's access and ability to see certain Views and hyperlinks is limited to only seeing List and Details pages for Product, Department, Zone, Size, Promotion, and PromotionType. Employees cannot edit, create or delete anything.
 
 The program also is seeded with Sizes, Zones, and PromotionTypes.
 
 Upon cloning, a promotion (using a seeded PromotionType) and a department (using a newly created promotion) will have to be created  before a user can create a product.
 <ul>
  <li>Create a Promotion, using a seeded PromotionType.</li>
    <ul>
      <li>Recommendation: Create at least 2 Promotions</li>
      <ul>
      <li> Promotion 1:</li>
        <ul>
      <li> Promotion Type Id: No Promo</li>
      <li> Promotion Description: No Promotion</li>
      <li> Promotion Value 0 (although value shouldn't matter for No Promo. **See Sales Price methods below**</li>
        </ul>  
      <li> Promotion 2:</li>
              <ul>
      <li> Promotion Type Id: Percent Off</li>
      <li> Promotion Description: 30% Off</li>
      <li> Promotion Value: 30 </li>
      </ul>
      </ul>
  </ul>
  <li>Create a Department, using a newly created Promotion</li>
      <ul>
      <li>Recommendation: Create at least 1 Department</li>
      <ul>
      <li> Department 1:</li>
        <ul>
      <li> Department Number: 94</li>
      <li> Department Name: Dresses</li>
      <li> Department Promotion Id: Select either No Promo or 30% Off and then select the opposite for the product's Promotion Id when you create the product</li>
        </ul>  
        </ul>
  </ul>
<li> A screenshot of my local db for Department, Promotion, and PromotionType is provided, in case there are any issues with seeding/testing. This will also give you several real life examples to use.</li>
        <ul>
          <li><a id="Local db RMT" href="https://docs.google.com/document/d/e/2PACX-1vTBKNs5qwMTI1_0aT9BtyjeoiUwVVLevOcDFH6dnyJetVFhOF4Gm8MUM3BMWhHpvVJpwWvR1nUnAHn9/pub" target="blank">Screenshot of local db for RMT</a></li>
        </ul>
 </ul>
    

<h2>FUNCTIONALITY/ENDPOINTS</h2>

<h4>FUNCTIONALITY I WOULD LIKE TO ACCOMPLISH:<h4>

1.	Full CRUD for Product, Department, Promotion, Zone, Size, PromotionType)
2.	Get all Products 
3.	Get Product by Id
4.	Get all Products by Department #
5.	Search for a Product by SKU
6.	Edit Product by Id
7.	Edit multiple Products' Promotion by DepartmentPromotion
8.	Calculate SalesPrice based on Product’s TicketPrice, DepartmentPromotion, and Individual Product’s Promotion
9.  Create Roles for Admin and Employee
10. Limit Employee access and view to only be able to access and/or see List and Details views

<h4>Sales Price Calculation</h4>

Sales Price and Promotion Description are calculated in the ProductDetail view. It first finds out what the product's department promotion is. Then, through a switch case it does one of the following:
<ul>
  <li>Department's promotion's promotiontype is set to No Promo: Use the product's individual promotion and description.</li>
  <li>Department's promotion's promotion type is set to anything else: Use the product's department promotion and description.</li>
</ul>

Once the promotion has been determined, the switch case uses TicketPrice, PromoType, and PromotionValue to calculate the Sales Price.


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

<h2>ACKNOWLEDGEMENTS</h2>

<h4>User Roles</h4>
https://www.c-sharpcorner.com/UploadFile/asmabegam/Asp-Net-mvc-5-security-and-creating-user-role/

<h4>Seeding</h4>
https://stackoverflow.com/questions/51819260/seeding-data-in-startup-cs

<h4>Viewbag Dropdown List</h4>
https://stackoverflow.com/questions/14049098/mvc4-razor-drop-down-list-binding-with-foreign-key


<h4>Troubleshooting</h4>
https://stackoverflow.com/questions/19204979/system-invalidcastexception-unable-to-cast-object-of-type-system-int32-to-typ/19205653

<h4>Multiplying Decimals</h4>
https://stackoverflow.com/questions/26240428/convert-decimal-to-integer-without-losing-monetary-value
