/* SDP Group 2
 * ICKIER Furniture System
 * Ada, Rui Min, Zi Ying, Christina
 */

//ada's program testing

using ICKIER_Furniture_Retailer_System;
//testing furniture creation for factory pattern
FurnitureCreator creator = new TableCreator();

FurnitureItem table = creator.OrderFurniture();

// abstract factrory
FurnitureFactory oakFactory =
    new OakFurnitureFactory();

Table oakTable =
    oakFactory.CreateTable();

Chair oakChair =
    oakFactory.CreateChair();

BookShelf oakShelf =
    oakFactory.CreateBookShelf();


Console.WriteLine(
    oakTable.GetDescription());

Console.WriteLine(
    oakChair.GetDescription());

Console.WriteLine(
    oakShelf.GetDescription());