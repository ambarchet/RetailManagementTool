# RetailManagementTool<h1>RETAILMANAGEMENTTOOL</h1>

<h2>DESCRIPTION</h2>

<p>My goal was to create an MVC application for retail stores to be able to manage their products, as it relates to promotions and zone allocations. The target audience would be retail stores of any kind. This application could be used by, both, home office and associates on the sales floor. As someone who has worked in the retail industry, I realize how important it is to get information to customer-facing associates in as quick and user-friendly a manner as possible.</p>

<h2>DATABASE</h2>

<h4>Product</h4>
<ul>
  <li>int Id [pk]</li>
  <li>int Department [Foreign Key of Department Id]</li>
  <li>string SKU</li>
  <li>string Style</li>
  <li>string Color</li>
  <li>int Size [Foreign Key of Size Id]</li>
  <li>string Name</li>
  <li>decimal TicketPrice</li>
  <li>decimal SalesPrice</li>
  <li>int Promotion [Foreign Key of Promotion Id]</li>
  <li>int ZoneLocation [Foreign Key of Zone Id]</li>
</ul>

<h4>Department</h4>
<ul>
  <li>int Id [pk]</li>
  <li>string DepartmentNumber</li>
  <li>string DepartmentName</li>
  <li>int Promotion [Foreign Key of Promotion Id]</li>
  <li>List<Product> DepartmentProducts</li>
</ul>

<h4>Zone</h4>
<ul>
  <li>int Id [pk]</li>
  <li>string Name</li>
</ul>

<h4>Promotion</h4>
<ul>
  <li>int Id[pk]</li>
  <li>string Description</li>
</ul>

<h4>Size</h4>
<ul>
  <li>int Id [pk]</li>
  <li>string Name</li>
</ul>


<h2>ENDPOINTS</h2>

<h4>FUNCTIONALITY I WOULD LIKE TO ACCOMPLISH:<h4>

1.	Full CRUD for Product, Department, Promotion, Zone, Role)
2.	Get all products 
3.	Get product by Id
4.	Get all products by Department #
5.	Get all products by Zone #
6.	Get all products by Promotion
7.	Edit product by Id
8.	Edit multiple products' promotion by Department #

<h2>ACKNOWLEDGEMENTS</h2>

<h4>User Roles</h4>
https://www.c-sharpcorner.com/UploadFile/asmabegam/Asp-Net-mvc-5-security-and-creating-user-role/

<h4>Seeding</h4>
https://stackoverflow.com/questions/51819260/seeding-data-in-startup-cs

<h4>Dropdown List</h4>
https://stackoverflow.com/questions/14049098/mvc4-razor-drop-down-list-binding-with-foreign-key


<h4>Troubleshooting</h4>
https://stackoverflow.com/questions/19204979/system-invalidcastexception-unable-to-cast-object-of-type-system-int32-to-typ/19205653
