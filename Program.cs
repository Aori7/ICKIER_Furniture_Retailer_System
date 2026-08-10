/* SDP Group 2
 * ICKIER Furniture System
 * Ada, Rui Min, Zi Ying, Christina
 */

using ICKIER_Furniture_Retailer_System;
//testing furniture creation for factory pattern
FurnitureCreator creator = new TableCreator();

FurnitureItem table = creator.OrderFurniture();

