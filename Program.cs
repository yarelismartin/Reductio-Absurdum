// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



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
        throw new NotImplementedException("Display all products");
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

