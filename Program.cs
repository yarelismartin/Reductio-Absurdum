// See https://aka.ms/new-console-template for more information
using Reductio___Absurdum;

Console.WriteLine("Hello, World!");

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType("apparel", 01),
    new ProductType("potions", 02),
    new ProductType("enchanted objects", 03),
    new ProductType("wands", 04),
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
    new Product("Wand", 50M, true, GetProductTypeById(02, productTypes )),
    new Product("Invisibility Cloak", 200M, false, GetProductTypeById(03, productTypes )),
    new Product("Armor", 100M, true, GetProductTypeById(04, productTypes )),
    new Product("Love Potion", 75M, true, GetProductTypeById(02, productTypes )),
    new Product("SpellBook", 80M, false, GetProductTypeById(01, productTypes )),
};

string choice = null;
while( choice != "0")
{
    Console.WriteLine(@" Choose an Option:
        1. View All Products
        2. Add A Product 
        3. Delete A Product
        4. Update Product's Detail
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
        throw new NotImplementedException("add products");
    }
    else if ( choice == "3")
    {
        throw new NotImplementedException("delete product");
    }
    else if( choice == "4")
    {
        throw new NotImplementedException("update product's detail");
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
        Console.WriteLine($"{i + 1}. {product.Name} is a {product.ProductTypedId.Name} that is currently{(product.IsAvilable ? $" avilable for {product.Price}" : " not avilable")}.");
    }
}
