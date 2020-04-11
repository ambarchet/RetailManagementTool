# RetailManagementTool<h1>RETAILMANAGEMENTTOOL</h1>

<h2>DESCRIPTION</h2>

<p>My goal was to create an MVC application for retail stores to be able to manage their products, as it relates to promotions and zone allocations. The target audience would be retail stores of any kind. This application could be used by, both, home office and associates on the sales floor. As someone who has worked in the retail industry, I realize how important it is to get information to customer-facing associates in as quick and user-friendly a manner as possible.</p>

<h2>DATABASE</h2>

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


<h2>ENDPOINTS</h2>

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


<h2>ACKNOWLEDGEMENTS</h2>

<h4>User Roles</h4>
https://www.c-sharpcorner.com/UploadFile/asmabegam/Asp-Net-mvc-5-security-and-creating-user-role/

<h4>Seeding</h4>
https://stackoverflow.com/questions/51819260/seeding-data-in-startup-cs

<h4>Dropdown List</h4>
https://stackoverflow.com/questions/14049098/mvc4-razor-drop-down-list-binding-with-foreign-key


<h4>Troubleshooting</h4>
https://stackoverflow.com/questions/19204979/system-invalidcastexception-unable-to-cast-object-of-type-system-int32-to-typ/19205653

<h4>Multiplying Decimals</h4>
https://stackoverflow.com/questions/26240428/convert-decimal-to-integer-without-losing-monetary-value
