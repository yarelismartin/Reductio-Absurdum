// See https://aka.ms/new-console-template for more information
using Reductio___Absurdum;

Console.WriteLine("Hello, World!");

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType("apparel", 01),
    new ProductType("potion", 02),
    new ProductType("enchanted object", 03),
    new ProductType("wand", 04),
};


ProductType GetProductTypeById(int id, List<ProductType> productToDisplay)
// This will return a ProductType, need to pass the the int that is the id
// The list of ProductType objects to search within
{
    return productTypes.FirstOrDefault(p => p.Id == id);
    // grab the product tyoe list and find the first instance where the id matches 
    // we are doing this so that we can dot notate into this Product type instance 
}

List<Product> products = new List<Product>()
{
    new Product("Wand", 50M, true, GetProductTypeById(02, productTypes ), new DateTime(2024,2,17)),
    new Product("Invisibility Cloak", 200M, false, GetProductTypeById(02, productTypes ), new DateTime(2024,5,7)),
    new Product("Armor", 100M, true, GetProductTypeById(04, productTypes ), new DateTime(2024,4,10)),
    new Product("Love Potion", 75M, true, GetProductTypeById(02, productTypes ), new DateTime(2024,1,8)),
    new Product("SpellBook", 80M, false, GetProductTypeById(01, productTypes ), new DateTime(2024,7,7)),
};

string choice = null;
while( choice != "0")
{
    Console.WriteLine(@" Choose an Option:
        1. View All Products
        2. Add A Product 
        3. Delete A Product
        4. Update Product's Detail
        5. Search By Product Type
        6. View Availiable Products
        0. Exit");

    choice = Console.ReadLine();

    if ( choice == "0")
    {
        Console.WriteLine( "GoodBye!");
    }
    else if ( choice == "1")
    {
        ListProducts(products);
    }
    else if ( choice == "2") 
    {
        AddAProduct();
    }
    else if ( choice == "3")
    {
        DeleteProduct();
    }
    else if( choice == "4")
    {
        UpdateProductDetail();
    }
    else if (choice == "5")
    {
        SearchByProductType();
    }
    else if (choice == "6")
    {
        ListAllAvailableProducts();
    }
    else
    {
        Console.WriteLine("Invalid option. Please choose a valid option from the list.");
        Console.Clear();
    }
}   
 

void ListProducts( List<Product> productsToDisplay)
{
    for (int i = 0; i < productsToDisplay.Count; i++)
    {
        Product product = productsToDisplay[i];
        Console.WriteLine($"{i + 1}. {product.Name} is a {product.ProductTypedId.Name} that is currently{(product.IsAvilable ? $" avilable for {product.Price}" : " not avilable")}. Has a shelf life of {product.DaysOnShelf} days. ");
    }
}
void ListProductTypes()
{
    for ( int i = 0; i < productTypes.Count; i++) 
    {
        ProductType product = productTypes[i];
        Console.WriteLine($"{i + 1}. {product.Name}");
    } 
}

void ListAllAvailableProducts()
{
    List<Product> availableProducts = products.Where(p => !p.IsAvilable).ToList();
    ListProducts(availableProducts);
}

void AddAProduct()
{
    string productName;
    while (true)
    {
        Console.WriteLine("What is the name of your product?");
        productName = Console.ReadLine();
            //string is not null or whitespce and does not have any digit characters
        if (!string.IsNullOrWhiteSpace(productName) && !productName.Any(char.IsDigit))
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalis input. Please enter a name with no digits.");
        }
    }

    decimal productPrice;
    while (true)
    {
        Console.WriteLine($"What is the price of the {productName}");
        if(decimal.TryParse(Console.ReadLine(), out productPrice)) 
        { 
            break;
        }
        else
        {
            Console.WriteLine( "Invalid input. Please respond with a price ");
        }
    }

    while (true)
    {
        Console.WriteLine("Select the product type:");
        ListProductTypes();
        if (int.TryParse(Console.ReadLine(), out int productIndex))
        {
            ProductType selectedType = productTypes[productIndex - 1];
            //oducts.ProductTypedId = selectedType.Id;
            //Console.WriteLine($"{selectedType.Name}");
            Product newProduct = new Product(productName, productPrice, true, selectedType, DateTime.Now);
            products.Add(newProduct);
            break;
        } 
        else
        {
            Console.WriteLine("Invalid input. Enter a NUMBER within range. ");
        }
    }


}

void DeleteProduct()
{
    Console.WriteLine("Enter the number of the product that you want to delete.");
    ListProducts(products);

    while(true) 
    {
        if (int.TryParse(Console.ReadLine(), out int productIndex) && productIndex >= 1 && productIndex <= products.Count)
        {
            Console.WriteLine($"{products[productIndex -1 ].Name} has been deleted.");
            products.RemoveAt(productIndex -1 );
            break;
        }
        else
        {
            Console.WriteLine( "Invalid input please enter a valid number");
        }
    }

}

void SearchByProductType()
{
    Console.WriteLine("Enter the number corresponding to the product type you want to search for:");
    ListProductTypes();
while(true)
   {
    if (int.TryParse(Console.ReadLine(), out int productTypeSearch))
    {
        ProductType selectedType = productTypes[productTypeSearch - 1];
        //Console.WriteLine($"{selectedType.Name}");
        List<Product> productsBasedOnType = products.Where(p => p.ProductTypedId == selectedType).ToList();

        if(productsBasedOnType.Any())
        {
            Console.WriteLine( $"Products of {selectedType.Name}: ");
            ListProducts(productsBasedOnType);
        }
        else
        {
            Console.WriteLine($"No products found for type {selectedType.Name}.");
        }
      break;

     }
        else
    {
        Console.WriteLine("Invalid input. Enter a NUMBER within range. ");
    }
   }
}

void UpdateProductDetail()
{
    ListProducts(products);
    Console.WriteLine("Enter the number of the product you would like to update.");

   while(true)
    {
        if(int.TryParse(Console.ReadLine(), out int productIndex) && productIndex >= 1 && productIndex <= products.Count)
        {
            Product selectedProduct = products[productIndex - 1];

                Console.WriteLine($"Current product name: {selectedProduct.Name}");
                Console.WriteLine($"Enter the new name of this product.");
            while (true)
            {
                string productNewName = Console.ReadLine();
                //string is not null or whitespce and does not have any digit characters
                if (!string.IsNullOrWhiteSpace(productNewName) && !productNewName.Any(char.IsDigit))
                {
                    selectedProduct.Name = productNewName;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalis input. Please enter a name with no digits.");
                }
            }


                Console.WriteLine($"Current product price: ${selectedProduct.Price}. ");
                Console.WriteLine($"What is the new price?");
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal productNewPrice))
                {
                    selectedProduct.Price = productNewPrice;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please respond with a price ");
                }
            }

                Console.WriteLine($"Current product type: {selectedProduct.ProductTypedId.Name}");
                Console.WriteLine("Select the new product type:");
            while (true)
            {
                ListProductTypes();
                if (int.TryParse(Console.ReadLine(), out int productTypeIndex) && productTypeIndex >= 1 && productTypeIndex <= productTypes.Count)
                {
                    ProductType selectedType = productTypes[productTypeIndex - 1];
                    selectedProduct.ProductTypedId = selectedType;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a NUMBER within range. ");
                }
            }

                Console.WriteLine($"This product is currently: {(selectedProduct.IsAvilable ? "Available" : "Not Available")}");
                Console.WriteLine("Is this product available? yes/no");
            while(true)
            {
                string newAvailibility = Console.ReadLine();

                switch (newAvailibility.ToLower())
                {
                    case "yes":
                    case "y":
                        selectedProduct.IsAvilable = true; 
                        break;
                    case "no": 
                    case "n":
                         selectedProduct.IsAvilable = false;
                        break;
                        // breaks out of the switch loop
                    default:
                        Console.WriteLine("Invalid input. Please enter a \"yes\" or \"no\".");
                        // This jumps back to the beginning of the while loop
                        //After continue; is executed, the loop condition is evaluated again
                        // continue is specifically used within loops
                        continue;

                }
                // This breaks out of the while loop after a valid input
                break;
            
            }
            Console.WriteLine("Your product has be updated.");
            break;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number within range. ");
        }
    }




}